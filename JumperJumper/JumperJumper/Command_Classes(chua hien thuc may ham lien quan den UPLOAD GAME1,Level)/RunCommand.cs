using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class RunCommand : ICommands
    {
        Teno teno;
        public RunCommand(Teno teno)
        {
            this.teno = teno;
        }
        public void Execute()
        {
           teno.physState.Run();
        }
    }
}
