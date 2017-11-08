using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace JumperJumper
{
    public interface IHouseState
    {
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle GetBoundingBox(Vector2 location);
    }
}
