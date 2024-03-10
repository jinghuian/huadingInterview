using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreeFiveSevenGame
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        Operation currentUser;//当前应操作玩家
        //三个盒子中物品初始的数量
        int treeBoxCount = 3;
        int fiveBoxCount = 5;
        int sevenBoxCount = 7;
        bool isStart = false;
        int loopNum = 0;//每轮抽取的次数
        int loopCount = 1;//抽取轮数
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnTree.Text = treeBoxCount.ToString();
            btnFive.Text = fiveBoxCount.ToString();
            btnSeven.Text = sevenBoxCount.ToString();
        }



        private void menuStart_Click(object sender, EventArgs e)
        {

            if (menuStart.Text == "重新开始")
            {
                txtUserOne.Text = "One";
                txtUserTwo.Text = "Two";
                txtUserOne.Enabled = true;
                txtUserTwo.Enabled = true;
                reSet();
                menuStart.Text = "开始";
                isStart = false;
                statusMessage.Text = "等待游戏开始";
                return;
            }
            txtUserOne.Text = txtUserOne.Text.Trim();
            txtUserTwo.Text = txtUserTwo.Text.Trim();
            if (string.IsNullOrEmpty(txtUserOne.Text))
            {
                statusMessage.Text = $"玩家名称不能为空。";
                return;
            }
            if (string.IsNullOrEmpty(txtUserTwo.Text))
            {
                statusMessage.Text = $"玩家名称不能为空。";
                return;
            }
            if (txtUserOne.Text == txtUserTwo.Text)
            {
                statusMessage.Text = $"玩家名称不能相同。";
                return;
            }
            txtUserOne.Enabled = false;
            txtUserTwo.Enabled = false;
            menuStart.Text = "重新开始";
            reSet();

        }
        private void menuHelp_Click(object sender, EventArgs e)
        {
            FrmHelp frmHelp = new FrmHelp();
            frmHelp.ShowDialog();
        }

        private void menuReset_Click(object sender, EventArgs e)
        {
            if (isStart == false)
            {
                MessageBox.Show("请先开始游戏");
                return;
            }
            reSet();
        }


        private void btnTree_Click(object sender, EventArgs e)
        {
            Extract(3, currentUser);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            Extract(5, currentUser);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            Extract(7, currentUser);
        }

        void Extract(int intWhich, Operation optWho)
        {
            if (isStart == false)
            {
                MessageBox.Show($"请先开始游戏");
                return;
            }
            switch (intWhich)
            {
                case 3:
                    treeBoxCount--;
                    break;
                case 5:
                    fiveBoxCount--;
                    break;
                case 7:
                    sevenBoxCount--;
                    break;


            }
            //如果为零 则禁用
            btnTree.Enabled = !(treeBoxCount == 0);
            btnFive.Enabled = !(fiveBoxCount == 0);
            btnSeven.Enabled = !(sevenBoxCount == 0);
            btnTree.Text = treeBoxCount.ToString();
            btnFive.Text = fiveBoxCount.ToString();
            btnSeven.Text = sevenBoxCount.ToString();
            string _userName = currentUser == Operation.userOne ? txtUserOne.Text : txtUserTwo.Text;
            //判断输赢
            if (treeBoxCount + fiveBoxCount + sevenBoxCount == 1)
            {
                
                MessageBox.Show($"游戏结束,玩家{_userName}获胜");
                reSet();
                return;
            }
            if (optWho == Operation.userOne)
            {
                currentUser = Operation.userTwo;
            }
            else
            {
                currentUser = Operation.userOne;

            }
            _userName = currentUser == Operation.userOne ? txtUserOne.Text : txtUserTwo.Text;
            loopNum++;
            if (loopNum == 2)
            {
                loopCount++;
                loopNum = 0;
            }
            statusMessage.Text = $"游戏第{loopCount}轮,玩家{_userName}抽取";
        }
        private void reSet()
        {
            loopNum = 0;//每轮抽取的次数
            loopCount = 1;//抽取轮数
            treeBoxCount = 3;
            fiveBoxCount = 5;
            sevenBoxCount = 7;
            btnTree.Text = treeBoxCount.ToString();
            btnFive.Text = fiveBoxCount.ToString();
            btnSeven.Text = sevenBoxCount.ToString();
            btnTree.Enabled = !(treeBoxCount == 0);
            btnFive.Enabled = !(fiveBoxCount == 0);
            btnSeven.Enabled = !(sevenBoxCount == 0);
            Random ran = new Random();
            int userSelected = ran.Next(1, 3);
            if (userSelected == 1)
            {
                statusMessage.Text = $"游戏开始，玩家{txtUserOne.Text}先抽。";
                currentUser = Operation.userOne;
            }
            else
            {
                statusMessage.Text = $"游戏开始，玩家{txtUserTwo.Text}先抽";
                currentUser = Operation.userTwo;
            }
            isStart = true;
        }
        /// <summary>
        /// 操作人枚举
        /// </summary>
        public enum Operation
        {
            userOne = 1,
            userTwo = 2
        }
    }
}
