using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class LeftCommand : ICommands
    {
        Teno teno;
        public LeftCommand(Teno teno)
        {
            this.teno = teno;
        }

        public void Execute()
        {
            teno.GoLeft();
        }
    }
}
