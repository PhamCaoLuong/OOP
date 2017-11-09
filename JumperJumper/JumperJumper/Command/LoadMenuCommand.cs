using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LoadMenuCommand : ICommands
    {
        Game1 game;
        public LoadMenuCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.gameState = new TitleScreenGameState(game);
            game.isTitle = true;
        }
    }
}