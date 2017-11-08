using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LoadAchPageCommand : ICommands
    {
        public LoadAchPageCommand()
        {
        }
        public void Execute()
        {
            Game1.GetInstance().gameState = new AchievementMenuGameState();
        }
    }
}
