using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class QuitCommand : ICommands
    {
        Game1 game;
        public QuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
