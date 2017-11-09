using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class LeftDeadSXTKState : IEnemyState
    {
        IAnimatedSprite sprite;
        
        public LeftDeadSXTKState()
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftDeadSXTK);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            // null
        }
        public void GoLeft(Enemy enemy)
        {
            //null
        }
        public void GoRight(Enemy enemy)
        {
            //null
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            enemy.deathAnimationTimer--;
            if (enemy.deathAnimationTimer <= 0)
            {
                enemy.state = new NullEnemyState();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
