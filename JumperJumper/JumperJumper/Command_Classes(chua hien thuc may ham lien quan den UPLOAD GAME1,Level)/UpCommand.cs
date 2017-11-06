using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class UpCommand : ICommands
    {
        Teno teno;
        public UpCommand(Teno teno)
        {
            this.teno = teno;
        }
        public void Execute()
        {
            teno.Jump();
        }
    }
}
