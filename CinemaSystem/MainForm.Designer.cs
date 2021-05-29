
namespace CinemaSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.影院管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvMovie = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbSeat = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCalcPrice = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMovieType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblActor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMovieName = new System.Windows.Forms.Label();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c教程分享ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更多教程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请关注我油管ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配套视频ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.影院管理ToolStripMenuItem,
            this.系统ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 影院管理ToolStripMenuItem
            // 
            this.影院管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c教程分享ToolStripMenuItem,
            this.更多教程ToolStripMenuItem,
            this.请关注我油管ToolStripMenuItem});
            this.影院管理ToolStripMenuItem.Name = "影院管理ToolStripMenuItem";
            this.影院管理ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.影院管理ToolStripMenuItem.Text = "影院管理";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配套视频ToolStripMenuItem,
            this.关于我ToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.系统ToolStripMenuItem.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvMovie);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 479);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "放映列表";
            // 
            // tvMovie
            // 
            this.tvMovie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMovie.Location = new System.Drawing.Point(3, 47);
            this.tvMovie.Name = "tvMovie";
            this.tvMovie.Size = new System.Drawing.Size(216, 429);
            this.tvMovie.TabIndex = 1;
            this.tvMovie.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMovie_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 30);
            this.panel2.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(132, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbSeat);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(222, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 479);
            this.panel1.TabIndex = 2;
            // 
            // gbSeat
            // 
            this.gbSeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSeat.Location = new System.Drawing.Point(0, 183);
            this.gbSeat.Name = "gbSeat";
            this.gbSeat.Size = new System.Drawing.Size(528, 296);
            this.gbSeat.TabIndex = 1;
            this.gbSeat.TabStop = false;
            this.gbSeat.Text = "选择观影座位";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCalcPrice);
            this.groupBox2.Controls.Add(this.lblPrice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblDuration);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblMovieType);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblActor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblDirector);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblMovieName);
            this.groupBox2.Controls.Add(this.picPoster);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 183);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "影片详情";
            // 
            // lblCalcPrice
            // 
            this.lblCalcPrice.AutoSize = true;
            this.lblCalcPrice.ForeColor = System.Drawing.Color.Red;
            this.lblCalcPrice.Location = new System.Drawing.Point(232, 155);
            this.lblCalcPrice.Name = "lblCalcPrice";
            this.lblCalcPrice.Size = new System.Drawing.Size(53, 12);
            this.lblCalcPrice.TabIndex = 2;
            this.lblCalcPrice.Text = "优惠价：";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(232, 132);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 12);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "原价：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(173, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "优惠价：";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(232, 109);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(41, 12);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "时长：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "原价：";
            // 
            // lblMovieType
            // 
            this.lblMovieType.AutoSize = true;
            this.lblMovieType.Location = new System.Drawing.Point(232, 86);
            this.lblMovieType.Name = "lblMovieType";
            this.lblMovieType.Size = new System.Drawing.Size(41, 12);
            this.lblMovieType.TabIndex = 2;
            this.lblMovieType.Text = "类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "时长：";
            // 
            // lblActor
            // 
            this.lblActor.AutoSize = true;
            this.lblActor.Location = new System.Drawing.Point(232, 63);
            this.lblActor.Name = "lblActor";
            this.lblActor.Size = new System.Drawing.Size(41, 12);
            this.lblActor.TabIndex = 2;
            this.lblActor.Text = "主演：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "类型：";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(232, 40);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(41, 12);
            this.lblDirector.TabIndex = 2;
            this.lblDirector.Text = "导演：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "主演：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "导演：";
            // 
            // lblMovieName
            // 
            this.lblMovieName.AutoSize = true;
            this.lblMovieName.Location = new System.Drawing.Point(81, 22);
            this.lblMovieName.Name = "lblMovieName";
            this.lblMovieName.Size = new System.Drawing.Size(41, 12);
            this.lblMovieName.TabIndex = 2;
            this.lblMovieName.Text = "label2";
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(35, 39);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(113, 130);
            this.picPoster.TabIndex = 1;
            this.picPoster.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "片名：";
            // 
            // c教程分享ToolStripMenuItem
            // 
            this.c教程分享ToolStripMenuItem.Name = "c教程分享ToolStripMenuItem";
            this.c教程分享ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.c教程分享ToolStripMenuItem.Text = "C#教程分享";
            this.c教程分享ToolStripMenuItem.Click += new System.EventHandler(this.c教程分享ToolStripMenuItem_Click);
            // 
            // 更多教程ToolStripMenuItem
            // 
            this.更多教程ToolStripMenuItem.Name = "更多教程ToolStripMenuItem";
            this.更多教程ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.更多教程ToolStripMenuItem.Text = "更多教程";
            this.更多教程ToolStripMenuItem.Click += new System.EventHandler(this.更多教程ToolStripMenuItem_Click);
            // 
            // 请关注我油管ToolStripMenuItem
            // 
            this.请关注我油管ToolStripMenuItem.Name = "请关注我油管ToolStripMenuItem";
            this.请关注我油管ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.请关注我油管ToolStripMenuItem.Text = "请关注我油管";
            this.请关注我油管ToolStripMenuItem.Click += new System.EventHandler(this.请关注我油管ToolStripMenuItem_Click);
            // 
            // 配套视频ToolStripMenuItem
            // 
            this.配套视频ToolStripMenuItem.Name = "配套视频ToolStripMenuItem";
            this.配套视频ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.配套视频ToolStripMenuItem.Text = "配套视频";
            this.配套视频ToolStripMenuItem.Click += new System.EventHandler(this.配套视频ToolStripMenuItem_Click);
            // 
            // 关于我ToolStripMenuItem
            // 
            this.关于我ToolStripMenuItem.Name = "关于我ToolStripMenuItem";
            this.关于我ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关于我ToolStripMenuItem.Text = "关于我";
            this.关于我ToolStripMenuItem.Click += new System.EventHandler(this.关于我ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "影院管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 影院管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvMovie;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbSeat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCalcPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMovieType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblActor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMovieName;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem c教程分享ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更多教程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请关注我油管ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配套视频ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我ToolStripMenuItem;
    }
}

