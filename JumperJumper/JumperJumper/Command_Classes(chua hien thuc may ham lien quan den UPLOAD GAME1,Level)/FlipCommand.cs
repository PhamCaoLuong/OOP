using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class FlipCommand : ICommands
    {
        Teno teno;
        public FlipCommand(Teno teno)
        {
            this.teno = teno;
        }
        public void Execute()
        {
            teno.physState.Flip();
        }
    }
}
