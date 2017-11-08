using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class QuitCommand : ICommands
    {

        public QuitCommand()
        {
        }

        public void Execute()
        {
            Game1.GetInstance().Exit();
        }
    }
}
