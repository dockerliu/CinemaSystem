using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using BLL;
using Model;

namespace CinemaSystem
{
    public partial class MainForm : Form
    {
        MovieManager movieManager = new MovieManager();
        ScheduleManager scheduleManager = new ScheduleManager();
        PlayHallManager hallManager = new PlayHallManager();
        TicketManager ticketManager = new TicketManager();
        List<PlayHall> playHalls = new List<PlayHall>();
        
        public MainForm()
        {
            InitializeComponent();

            //加载放映厅信息
            playHalls = hallManager.GetAll();
        }
        //查询按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindMovieTree();
        }

        /// <summary>
        /// 邦定影片方法
        /// </summary>
        void BindMovieTree()
        {
            tvMovie.Nodes.Clear();
            List<Movie> moviesList = movieManager.GetAll();//所有电影
            List<Schedule> scheduleList = scheduleManager.GetAllSchedule();//所有播放计划
            //外层循环遍历影片信息 一对多
            foreach (Movie movie in moviesList)
            {
                TreeNode tn_Movie = new TreeNode(movie.MovieName);
                tn_Movie.Tag = movie;//每个影片的对象

                //查询选择后的影片信息
              List<Schedule> list=  scheduleList.Where(s => s.MovieID == movie.MovieId &&
                s.PlayTime.Value.ToString("yyyyMMdd") == dateTimePicker1.Value.ToString("yyyyMMdd")).ToList();
                foreach (Schedule schedule  in list)
                {
                    TreeNode tn_schedule = new TreeNode(schedule.PlayTime.Value.ToString("t"));
                    tn_schedule.Tag = schedule;
                    tn_Movie.Nodes.Add(tn_schedule);
                }
                tvMovie.Nodes.Add(tn_Movie);
                tvMovie.ExpandAll();
            }
        }

        /// <summary>
        /// 选中树节点改变触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMovie_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvMovie.SelectedNode.Level==1)//判断二级节点
            {
                //显示信息
                ShowInfo();
            }
        }

        Movie objMovie;
        Schedule objSchedule;
        void ShowInfo()
        {
            objMovie= tvMovie.SelectedNode.Parent.Tag as Movie;//获取影片信息
            objSchedule = tvMovie.SelectedNode.Tag as Schedule;//获取放映计划

            //显示影片信息
            lblMovieName.Text = objMovie.MovieName;
            lblDirector.Text = objMovie.Director;
            lblDuration.Text = objMovie.Duration;
            lblActor.Text = objMovie.Actor;
            picPoster.ImageLocation = objMovie.Poster==""?null:objMovie.Poster;
            lblPrice.Text = objMovie.Price;
            lblCalcPrice.Text = (Convert.ToInt32(objMovie.Price) * (10-Convert.ToInt32(objSchedule.Discount)) / 10).ToString();
            BindSeat();
        }

        /// <summary>
        /// 绑定座位
        /// </summary>
        void BindSeat()
        {
            gbSeat.Controls.Clear();
            //在内存中查询
            PlayHall playHall= playHalls.Where(p => p.HallId == objSchedule.HallID).Single<PlayHall>();
          List<Ticket> tickets=   ticketManager.GetAll();
            List<string> seaList = (from s in tickets where s.ScheduleID == objSchedule.ID select s.SeatNo).ToList<string>();//查询选择放映厅的座位信息

            //加载xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(playHall.SeatList);
            XmlNode rootNode = xmlDocument.DocumentElement;//获取文档元素
            for (int i = 0; i < rootNode.ChildNodes.Count; i++) //获取6个Row节点
            {
                XmlNode rowNode= rootNode.ChildNodes[i];
                for (int j = 0; j < rowNode.ChildNodes.Count; j++)
                {
                    XmlNode colNode = rowNode.ChildNodes[j];
                    Label lblSeat = new Label();
                    lblSeat.Text = colNode.InnerText;
                    lblSeat.Size = new Size(50, 25);//大小
                    lblSeat.Location = new Point(j*60 + 20,i*40+20);
                    lblSeat.BackColor = Color.Gray;
                    lblSeat.TextAlign = ContentAlignment.MiddleCenter;

                   

                    if (seaList.Contains(lblSeat.Text))//已经卖出
                    {
                        lblSeat.BackColor = Color.Red;
                    }
                    else//未售出的
                    {
                        lblSeat.BackColor = Color.Gray;
                        lblSeat.Click += LblSeat_Click;//注册点击事件
                    }

                    gbSeat.Controls.Add(lblSeat);
                }
            }
        }

        private void LblSeat_Click(object sender, EventArgs e)
        {
            Label labelSeat = (Label)sender;
            if (MessageBox.Show("你确定出票吗?", "提示:", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Ticket ticket = new Ticket {
                    TicketID = objSchedule.ID,
                    ScheduleID=objSchedule.ID,
                    CreateTime=DateTime.Now,
                    Price = int.Parse(lblCalcPrice.Text),
                    SeatNo=labelSeat.Text
                };
                if (ticketManager.Add(ticket)>0)
                {
                    labelSeat.BackColor = Color.Red;
                    labelSeat.Click -= LblSeat_Click;
                    MessageBox.Show("出票成功!", "提示:");
                    //打印
                    Print(labelSeat.Text);

                }
                else MessageBox.Show("出票失败!", "提示:");
            };
        }

        /// <summary>
        /// 模拟打印电影票
        /// </summary>
        /// <param name="Seat"></param>
        void Print(string Seat)
        {
            //IO打印电影票 1-7-1-20210529
            string fileName = $"{Seat}-{objSchedule.ID}-{DateTime.Now.ToString("yyyyMMdd")}.txt";
            //创建文件流
            using (FileStream fs=new FileStream(fileName,FileMode.Create))
            {
                using (StreamWriter sw=new StreamWriter(fs,Encoding.Default))
                {
                    sw.WriteLine("**************************");
                    sw.WriteLine("\t 程序员影院");
                    sw.WriteLine("**************************");
                    sw.WriteLine($"电影名:{objMovie.MovieName}");
                    sw.WriteLine($"时长:{objMovie.Duration}");
                    sw.WriteLine($"放映时间:{objSchedule.PlayTime.Value.ToString("yyyy年mm月dd日 HH:MM")}");
                    sw.WriteLine($"票价:{lblCalcPrice.Text}");
                    sw.WriteLine($"座位:{Seat}");
                    sw.WriteLine("**************************");

                }
            }

        }

        /*
             广告预警
              视情况完善本程序
         */

        private void c教程分享ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl();
        }

        private void 更多教程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl();
        }

        private void 请关注我油管ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl();
        }

        private void 配套视频ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("IEXPLORE.EXE", "https://www.youtube.com/watch?v=bTiaRzi23TU&list=PLJgD_fXVXZKppT4stJ09s9nu3byvyMERE&index=46");
        }

        private void 关于我ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl();
        }

       
        public void OpenUrl()
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "iexplore.exe";
            pro.StartInfo.Arguments = "https://www.youtube.com/channel/UC50Db-4KpjBUiCULD9KRfiQ";
            pro.Start();
        }
    }
}
