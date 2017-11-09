using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace JumperJumper
{
    /*public class ExplodingBlockState : IBlockState   // không cần
    {
        public IAnimatedSprite sprite;
        public ISpriteFactory factory;

        public ExplodingBlockState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.explosion);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }

        public void Update(GameTime gametime, Block block)
        {
            sprite.Update(gametime);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void Reaction(Block block)
        {
        }
    }*/
}
