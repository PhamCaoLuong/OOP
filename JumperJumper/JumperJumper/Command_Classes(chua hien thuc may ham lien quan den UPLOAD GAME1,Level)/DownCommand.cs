using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class DownCommand : ICommands
    {
        Teno teno;
        public DownCommand(Teno teno)
        {
            this.teno = teno;
        }
        public void Execute()
        {
            teno.Crouch();
        }
    }
}
