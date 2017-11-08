using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class TrampolineBlockState : IBlockState            /* Node : new class use for when teno jump in mushroom */
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        int timereaction;
        public TrampolineBlockState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.mushroom1);
            timereaction = 15;
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
            sprite = factory.build(SpriteFactory.sprites.touchmushroom);
            if (timereaction > 0)
            {

            }
            sprite = factory.build(SpriteFactory.sprites.mushroom1);
        }

        public void Update(GameTime gametime, Block block)
        {
            sprite.Update(gametime);
        }
    }
}
