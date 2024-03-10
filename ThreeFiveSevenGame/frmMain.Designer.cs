namespace ThreeFiveSevenGameUI
{
    partial class frmMain
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
            this.btnTree = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMessage = new System.Windows.Forms.StatusBar();
            this.lblUserOne = new System.Windows.Forms.Label();
            this.txtUserOne = new System.Windows.Forms.TextBox();
            this.txtUserTwo = new System.Windows.Forms.TextBox();
            this.lblUserTwo = new System.Windows.Forms.Label();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTree
            // 
            this.btnTree.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTree.Location = new System.Drawing.Point(214, 50);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(188, 100);
            this.btnTree.TabIndex = 1;
            this.btnTree.Text = "3";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnFive
            // 
            this.btnFive.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFive.Location = new System.Drawing.Point(214, 180);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(188, 100);
            this.btnFive.TabIndex = 2;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = true;
            this.btnFive.Click += new System.EventHandler(this.btnFive_Click);
            // 
            // btnSeven
            // 
            this.btnSeven.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSeven.Location = new System.Drawing.Point(214, 310);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(188, 100);
            this.btnSeven.TabIndex = 3;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = true;
            this.btnSeven.Click += new System.EventHandler(this.btnSeven_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuMain.Size = new System.Drawing.Size(635, 25);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "菜单";
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 21);
            this.menuHelp.Text = "帮助";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // statusMessage
            // 
            this.statusMessage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusMessage.Location = new System.Drawing.Point(0, 437);
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(635, 62);
            this.statusMessage.SizingGrip = false;
            this.statusMessage.TabIndex = 5;
            this.statusMessage.Text = "等待游戏开始";
            // 
            // lblUserOne
            // 
            this.lblUserOne.AutoSize = true;
            this.lblUserOne.Location = new System.Drawing.Point(15, 50);
            this.lblUserOne.Name = "lblUserOne";
            this.lblUserOne.Size = new System.Drawing.Size(53, 12);
            this.lblUserOne.TabIndex = 6;
            this.lblUserOne.Text = "玩家名称";
            // 
            // txtUserOne
            // 
            this.txtUserOne.Location = new System.Drawing.Point(74, 47);
            this.txtUserOne.Name = "txtUserOne";
            this.txtUserOne.Size = new System.Drawing.Size(100, 21);
            this.txtUserOne.TabIndex = 7;
            this.txtUserOne.Text = "One";
            // 
            // txtUserTwo
            // 
            this.txtUserTwo.Location = new System.Drawing.Point(510, 47);
            this.txtUserTwo.Name = "txtUserTwo";
            this.txtUserTwo.Size = new System.Drawing.Size(100, 21);
            this.txtUserTwo.TabIndex = 10;
            this.txtUserTwo.Text = "Two";
            // 
            // lblUserTwo
            // 
            this.lblUserTwo.AutoSize = true;
            this.lblUserTwo.Location = new System.Drawing.Point(451, 50);
            this.lblUserTwo.Name = "lblUserTwo";
            this.lblUserTwo.Size = new System.Drawing.Size(53, 12);
            this.lblUserTwo.TabIndex = 9;
            this.lblUserTwo.Text = "玩家名称";
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(44, 21);
            this.menuStart.Text = "开始";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(635, 499);
            this.Controls.Add(this.txtUserTwo);
            this.Controls.Add(this.lblUserTwo);
            this.Controls.Add(this.txtUserOne);
            this.Controls.Add(this.lblUserOne);
            this.Controls.Add(this.statusMessage);
            this.Controls.Add(this.btnSeven);
            this.Controls.Add(this.btnFive);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.StatusBar statusMessage;
        private System.Windows.Forms.Label lblUserOne;
        private System.Windows.Forms.TextBox txtUserOne;
        private System.Windows.Forms.TextBox txtUserTwo;
        private System.Windows.Forms.Label lblUserTwo;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
    }
}

