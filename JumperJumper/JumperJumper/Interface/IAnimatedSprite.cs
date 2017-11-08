using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public interface IAnimatedSprite
    {
        int UpdateSpeed { get; set; }
        Rectangle GetBoundingBox(Vector2 location);
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
    }
}
