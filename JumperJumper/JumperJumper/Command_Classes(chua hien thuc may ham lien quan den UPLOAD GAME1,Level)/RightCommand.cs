using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class RightCommand : ICommands
    {
        Teno teno;
        public RightCommand(Teno teno)
        {
            this.teno = teno;
        }

        public void Execute()
        {
            teno.GoRight();
        }
    }
}
