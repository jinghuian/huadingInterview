using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeFiveSevenGameCore
{

    public class ThreeFiveSevenGame
    {
        /// <summary>
        /// 一轮游戏结束后发生
        /// </summary>
        public event EventHandler<string> GameCompleted;
        /// <summary>
        /// 游戏状态说明出现变化后发生
        /// </summary>
        public event EventHandler<string> StatusDescriptionChanged;
        /// <summary>
        /// 当前用户发生变化后发生
        /// </summary>
        public event EventHandler<string> CurrentUserChanged;
        /// <summary>
        /// 盒子中数量发生变化后发生
        /// </summary>
        public event EventHandler BoxCountChanged;

        /// <summary>
        /// 盒子中数量发生变化后发生
        /// </summary>
        public event EventHandler CurrentSelectedBoxChanged;




        //备份上一次数量，为撤销操作保存数据
        int exTreeBoxCount;
        int exFiveBoxCount;
        int exSevenBoxCount;


        int loopNum = 0;//每轮抽取的次数
        int loopCount = 1;//抽取轮数
        bool isStart = false;//游戏是否开始




        string statusDescription = string.Empty;
        string currentUser = string.Empty;

        BoxType currentSelectedBox = BoxType.NoBox;




        //三个盒子中物品初始的数量
        /// <summary>
        /// 放有3个物品的盒子
        /// </summary>
        public int TreeBoxCount { get; private set; } = 3;
        /// <summary>
        /// 放有5个物品的盒子
        /// </summary>
        public int FiveBoxCount { get; private set; } = 5;
        /// <summary>
        /// 放有7个物品的盒子
        /// </summary>
        public int SevenBoxCount { get; private set; } = 7;


        /// <summary>
        /// 用户One名称
        /// </summary>
        public string GameUserOneName { get; set; }
        /// <summary>
        /// 用户Two名称
        /// </summary>
        public string GameUserTwoName { get; set; }
        /// <summary>
        /// 游戏是否开始
        /// </summary>
        public bool IsStart { get { return isStart; } }
        /// <summary>
        /// 游戏的当前状态说明
        /// </summary>
        public string StatusDescription
        {
            get { return statusDescription; }

            private set
            {
                statusDescription = value;
                if (StatusDescriptionChanged != null)
                {
                    StatusDescriptionChanged(this, statusDescription);
                }
            }
        }

        /// <summary>
        /// 当前操作玩家
        /// </summary>
        public string CurrentUser
        {
            get { return currentUser; }

            private set
            {
                currentUser = value;
                //触发事件
                if (CurrentUserChanged != null)
                {
                    CurrentUserChanged(this, CurrentUser);
                }
            }
        }
        /// <summary>
        /// 当前选择的盒子
        /// </summary>
        public BoxType CurrentSelectedBox
        {
            get { return currentSelectedBox; }

            private set
            {
                currentSelectedBox = value;
                //触发事件
                if (CurrentSelectedBoxChanged != null)
                {
                    CurrentSelectedBoxChanged(this, EventArgs.Empty);
                }
            }
        }

        public ThreeFiveSevenGame()
        {
            BackupCount();
        }



        public void Start()
        {
            isStart = true;

            Random ran = new Random();
            int userSelected = ran.Next(1, 3);
            if (userSelected == 1)
            {
                StatusDescription = $"游戏开始，玩家{GameUserOneName}先抽取。";
                CurrentUser = GameUserOneName;
            }
            else
            {
                StatusDescription = $"游戏开始，玩家{GameUserTwoName}先抽取";
                CurrentUser = GameUserTwoName;
            }


        }
        /// <summary>
        /// 重新开始
        /// </summary>
        public void ReStart()
        {
            isStart = false;

            ReSet();
        }
        /// <summary>
        /// 重置各项参数
        /// </summary>
        private void ReSet()
        {


            loopNum = 0;//每轮抽取的次数
            loopCount = 1;//抽取轮数
            TreeBoxCount = 3;
            FiveBoxCount = 5;
            SevenBoxCount = 7;
            BackupCount();

            //触发事件
            if (BoxCountChanged != null)
            {
                BoxCountChanged(this, EventArgs.Empty);
            }
            CurrentUser = string.Empty;
            currentSelectedBox = BoxType.NoBox;
            StatusDescription = $"等待游戏开始";

        }
        /// <summary>
        /// 一次抽取
        /// </summary>
        /// <param name="whichBox"></param>
        public void Extract(BoxType whichBox)
        {
            //修改数量
            switch ((int)whichBox)
            {
                case 3:
                    TreeBoxCount--;
                    break;
                case 5:
                    FiveBoxCount--;
                    break;
                case 7:
                    SevenBoxCount--;
                    break;


            }
            //触发事件
            if (BoxCountChanged != null)
            {
                BoxCountChanged(this, EventArgs.Empty);
            }
            CurrentSelectedBox = whichBox;


            //判断输赢
            if (TreeBoxCount + FiveBoxCount + SevenBoxCount == 1)
            {
                if (GameCompleted != null)
                {
                    GameCompleted(this, $"游戏结束,玩家{CurrentUser}获胜");
                }
                ReSet();
                Random ran = new Random();
                int userSelected = ran.Next(1, 3);
                if (userSelected == 1)
                {
                    StatusDescription = $"游戏重新开始，玩家{GameUserOneName}先抽。";
                    CurrentUser = GameUserOneName;
                }
                else
                {
                    StatusDescription = $"游戏重新开始，玩家{GameUserTwoName}先抽";
                    CurrentUser = GameUserTwoName;
                }
                return;
            }




        }
        /// <summary>
        /// 玩家确认抽取完成
        /// </summary>
        /// <param name="userName"></param>
        public void UserConfirm(string userName)
        { 
            //改变当前用户
            CurrentUser = GameUserOneName == userName.Trim() ? GameUserTwoName : GameUserOneName;

            CurrentSelectedBox = 0;

            loopNum++;
            if (loopNum == 2)
            {
                loopCount++;
                loopNum = 0;
            }
            BackupCount();
            StatusDescription = $"游戏第{loopCount}轮,请玩家{CurrentUser}抽取";

        }
        /// <summary>
        /// 玩家撤销操作
        /// </summary>
        /// <param name="userName"></param>
        public void UserCancel(string userName)
        {
            CurrentSelectedBox = 0;

            CancelCount();
            if (BoxCountChanged != null)
            {
                BoxCountChanged(this, EventArgs.Empty);
            }

        }
        /// <summary>
        /// 备份数量
        /// </summary>
        private void BackupCount()
        {
            exTreeBoxCount = TreeBoxCount;
            exFiveBoxCount = FiveBoxCount;
            exSevenBoxCount = SevenBoxCount;
        }
        /// <summary>
        /// 还原数量
        /// </summary>
        private void CancelCount()
        {
            TreeBoxCount = exTreeBoxCount;
            FiveBoxCount = exFiveBoxCount;
            SevenBoxCount = exSevenBoxCount;
        }
        /// <summary>
        /// 盒子类型
        /// </summary>
        public enum BoxType
        {

            NoBox = 0,

            TreeBox = 3,


            FiveBox = 5,


            SevenBox = 7



        }
    }


}
