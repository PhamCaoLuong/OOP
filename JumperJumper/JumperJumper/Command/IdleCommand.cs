using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class IdleCommand : ICommands
    {
        Teno teno;
        public IdleCommand(Teno teno)
        {
            this.teno = teno;
        }
        public void Execute()
        {
            teno.Idle();
        }
    }
}
