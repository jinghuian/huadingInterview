﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeFiveSevenGameCore;

namespace ThreeFiveSevenGameUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        ThreeFiveSevenGame threeFiveSevenGame = new ThreeFiveSevenGame();
        private void frmMain_Load(object sender, EventArgs e)
        {
            threeFiveSevenGame.GameCompleted += ThreeFiveSevenGame_GameCompleted;
            threeFiveSevenGame.StatusDescriptionChanged += ThreeFiveSevenGame_StatusDescriptionChanged;
            threeFiveSevenGame.BoxCountChanged += ThreeFiveSevenGame_BoxCountChanged;
            btnTree.Text = threeFiveSevenGame.TreeBoxCount.ToString();
            btnFive.Text = threeFiveSevenGame.FiveBoxCount.ToString();
            btnSeven.Text = threeFiveSevenGame.SevenBoxCount.ToString();

            
        }

       



        private void menuStart_Click(object sender, EventArgs e)
        {

            if (menuStart.Text == "重新开始")
            {
                txtUserOne.Text = "One";
                txtUserTwo.Text = "Two";
                txtUserOne.Enabled = true;
                txtUserTwo.Enabled = true;
                threeFiveSevenGame.ReStart();
                menuStart.Text = "开始";

                return;
            }
            txtUserOne.Text = txtUserOne.Text.Trim();
            txtUserTwo.Text = txtUserTwo.Text.Trim();
            if (string.IsNullOrEmpty(txtUserOne.Text))
            {
                MessageBox.Show($"玩家名称不能为空。");
                return;
            }
            if (string.IsNullOrEmpty(txtUserTwo.Text))
            {
                MessageBox.Show($"玩家名称不能为空。");
                return;
            }
            if (txtUserOne.Text == txtUserTwo.Text)
            {
                MessageBox.Show($"玩家名称不能相同。");
                return;
            }
            txtUserOne.Enabled = false;
            txtUserTwo.Enabled = false;
            threeFiveSevenGame.GameUserOneName = txtUserOne.Text;
            threeFiveSevenGame.GameUserTwoName = txtUserTwo.Text;
            threeFiveSevenGame.Start();
            menuStart.Text = "重新开始";
        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.ShowDialog();
        }




        private void btnTree_Click(object sender, EventArgs e)
        {
            if (threeFiveSevenGame.IsStart == false)
            {
                MessageBox.Show($"请先开始游戏");
                return;
            }
            threeFiveSevenGame.Extract(ThreeFiveSevenGame.BoxType.TreeBox);

        }


        private void btnFive_Click(object sender, EventArgs e)
        {
            if (threeFiveSevenGame.IsStart == false)
            {
                MessageBox.Show($"请先开始游戏");
                return;
            }
            threeFiveSevenGame.Extract(ThreeFiveSevenGame.BoxType.FiveBox);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (threeFiveSevenGame.IsStart == false)
            {
                MessageBox.Show($"请先开始游戏");
                return;
            }
            threeFiveSevenGame.Extract(ThreeFiveSevenGame.BoxType.SevenBox);
        }




        private void ThreeFiveSevenGame_GameCompleted(string obj)
        {
            MessageBox.Show(obj);
           
            return;
        }
        private void ThreeFiveSevenGame_BoxCountChanged()
        {
            //如果为零 则禁用
            btnTree.Enabled = !(threeFiveSevenGame.TreeBoxCount == 0);
            btnFive.Enabled = !(threeFiveSevenGame.FiveBoxCount == 0);
            btnSeven.Enabled = !(threeFiveSevenGame.SevenBoxCount == 0);
            //赋值
            btnTree.Text = threeFiveSevenGame.TreeBoxCount.ToString();
            btnFive.Text = threeFiveSevenGame.FiveBoxCount.ToString();
            btnSeven.Text = threeFiveSevenGame.SevenBoxCount.ToString();
        }

        private void ThreeFiveSevenGame_StatusDescriptionChanged(string obj)
        {
            statusMessage.Text = obj;
        }
    }
}
