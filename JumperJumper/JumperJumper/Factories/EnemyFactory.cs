using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class EnemyFactory
    {
        public enum EnemyType { GiaiTich, SXTK, OOP, PPT, Ly2, HoaDC }
        IEnemyState state;

        public EnemyFactory()
        {
        }

        public Enemy build(EnemyType type, Vector2 location)
        {
            if (type == EnemyFactory.EnemyType.GiaiTich)
            {
                state = new LeftGiaiTichState();
            }
            if (type == EnemyFactory.EnemyType.SXTK)
            {
                state = new LeftSXTKState();
            }
            if (type == EnemyFactory.EnemyType.PPT)
            {
                state = new LeftPPTState();
            }
            if(type == EnemyFactory.EnemyType.OOP)
            {
                state = new BobOOPState();
            }
            if(type == EnemyType.Ly2)
            {
                state = new LeftLy2State();
            }

            Enemy product = new Enemy(location, state);
            return product;
        }
    }
}