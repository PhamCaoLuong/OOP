using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace JumperJumper
{
    public interface IBlockState
    {
        void Update(GameTime gametime, Block block);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle GetBoundingBox(Vector2 location);
        void Reaction(Block block);
    }
}
