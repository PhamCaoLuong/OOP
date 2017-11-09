using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
   /* public class ExclaminationBlockState : IBlockState  // không cần
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public ExclaminationBlockState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.exclamationBlock);
        }

        public void Update(GameTime gametime, Block block)
        {
            sprite.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void Reaction(Block block)
        {
            sprite = factory.build(SpriteFactory.sprites.usedBlock);
        }
    }*/
}
