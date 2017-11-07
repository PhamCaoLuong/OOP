using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JumperJumper
{
    public class HouseFactory
    {
        public enum HouseFacing
        {
            up, down, left, right
        }
        IHouseState state;

        public HouseFactory()
        {
        }

        public House build(HouseFacing type, Vector2 location)
        {
            /*if (type == HouseFacing.up)
            {
                state = new HouseState();
            }
            if (type == PipeFacing.down)
            {
                state = new DownPipeState();
            }
            if (type == PipeFacing.left)
            {
                state = new LeftPipeState();
            }*/
            House product = new House(state, location);
            return product;
        }
    }
}
