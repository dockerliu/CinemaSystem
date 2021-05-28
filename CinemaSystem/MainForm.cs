using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace CinemaSystem
{
    public partial class MainForm : Form
    {
        MovieManager movieManager = new MovieManager();
        ScheduleManager scheduleManager = new ScheduleManager();
        public MainForm()
        {
            InitializeComponent();
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
            List<Movie> moviesList = movieManager.GetAll();
            List<Schedule> scheduleList = scheduleManager.GetAll();
            //外层循环遍历影片信息 一对多
            foreach (Movie movie in moviesList)
            {
                TreeNode tn_Movie = new TreeNode(movie.MovieName);
                tn_Movie.Tag = movie;//每个影片的对象
                scheduleList.Where(s => s.MovieID == movie.MovieId &&
                s.PlayTime.Value.ToString("yyyyMMdd") == dateTimePicker1.Value.ToString("yyyyMMdd")).ToList();
                foreach (Schedule schedule  in scheduleList)
                {
                    TreeNode tn_schedule = new TreeNode(schedule.PlayTime.ToString());
                    tn_schedule.Tag = schedule;
                    tn_Movie.Nodes.Add(tn_schedule);
                }
                tvMovie.Nodes.Add(tn_Movie);
                tvMovie.ExpandAll();
            }
        }
    }
}
