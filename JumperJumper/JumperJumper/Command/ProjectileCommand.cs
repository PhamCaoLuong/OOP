using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class ProjectileCommand : ICommands
    {
        Teno teno;
        public ProjectileCommand(Teno teno)
        {
            this.teno = teno;
        }

        public void Execute()
        {
            //if (teno.isFire && !mario.isNinja)
            //{
            //    mario.MakeFireballMario();
            //}
            //if (mario.isNinja)
            //{
            //    mario.MakeNinjaMario();
            //}
        }
    }
}

