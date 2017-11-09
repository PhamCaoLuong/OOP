using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class BobOOPState : IEnemyState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public BobOOPState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.OOP);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage(Enemy enemy)
        {
        }
        public void GoLeft(Enemy enemy)
        {
        }
        public void GoRight(Enemy enemy)
        {          
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
