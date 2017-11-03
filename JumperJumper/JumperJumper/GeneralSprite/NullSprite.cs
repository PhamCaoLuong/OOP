using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class NullSprite : IAnimatedSprite
    {
        public int UpdateSpeed { get; set; }
        public NullSprite()
        {
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
        public void Update(GameTime gametime) { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
        }
    }
}
