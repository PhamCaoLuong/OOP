using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LoadAchPageCommand : ICommands
    {
        Game1 game;
        public LoadAchPageCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.gameState = new AchievementMenuGameState(game);
        }
    }
}
