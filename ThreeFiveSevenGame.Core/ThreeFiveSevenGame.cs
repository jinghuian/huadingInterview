using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeFiveSevenGameCore
{
    
    public class ThreeFiveSevenGame
    {
        //三个盒子中物品初始的数量
        public int TreeBoxCount { get; private set; } = 3;
        
        public int FiveBoxCount { get; private set; } = 5;
        public int SevenBoxCount { get; private set; } = 7;

        int loopNum = 0;//每轮抽取的次数
        int loopCount = 1;//抽取轮数
        bool isStart = false;

        string statusDescription = string.Empty;


        public string GameUserOneName { get; set; }

        public string GameUserTwoName { get; set; }

        public bool IsStart { get { return isStart; } }

        public string StatusDescription { 
            get { return statusDescription; }
           
            private set 
            { 
                statusDescription = value;
                if (StatusDescriptionChanged != null)
                {
                    StatusDescriptionChanged(statusDescription);
                }
            }
        }

        public event Action<string> GameCompleted;

        public event Action<string> StatusDescriptionChanged;

        public event Action<string> CurrentUserChanged;

        public event Action BoxCountChanged;

        public string CurrentUser { get; private set; }
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
        public void ReStart()
        {
            isStart = false;
           
            ReSet();
        }
        private void ReSet()
        {

            loopNum = 0;//每轮抽取的次数
            loopCount = 1;//抽取轮数
            TreeBoxCount = 3;
            FiveBoxCount = 5;
            SevenBoxCount = 7;

            
             //触发事件
            if (BoxCountChanged != null)
            {
                BoxCountChanged();
            }
            StatusDescription = $"等待游戏开始";

        }

        public void Extract(BoxType whichBox)
        {
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

            if (BoxCountChanged != null)
            {
                BoxCountChanged();
            }
            //判断输赢
            if (TreeBoxCount + FiveBoxCount + SevenBoxCount == 1)
            {
                if (GameCompleted != null)
                {
                    GameCompleted($"游戏结束,玩家{CurrentUser}获胜");
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
            //改变当前用户
            CurrentUser = CurrentUser == GameUserOneName ? GameUserTwoName : GameUserOneName;
            //触发事件
            if (CurrentUserChanged != null)
            {
                CurrentUserChanged(CurrentUser);
            }

            loopNum++;
            if (loopNum == 2)
            {
                loopCount++;
                loopNum = 0;
            }
            StatusDescription = $"游戏第{loopCount}轮,请玩家{CurrentUser}抽取";
           
        }
        /// <summary>
        /// 操作人枚举
        /// </summary>
        public enum BoxType
        {

            TreeBox = 3,


            FiveBox = 5,


            SevenBox = 7

        }
    }


}
