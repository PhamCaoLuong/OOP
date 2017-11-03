using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class House
    {
        public Vector2 position;
        public IHouseState state {get; set;}
        public House exitHouse { get; set; }

        public House(IHouseState state, Vector2 location)
        {
            position = location;
            this.state = state;
        }

        public void Update(GameTime gametime)
        {
            state.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return state.GetBoundingBox(location);
        }
    }
}
