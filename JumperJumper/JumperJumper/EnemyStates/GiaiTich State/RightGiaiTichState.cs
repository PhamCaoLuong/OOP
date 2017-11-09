﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace JumperJumper
{
    public class RightGiaiTichState : IEnemyState
    {
        IAnimatedSprite sprite;
        
        public RightGiaiTichState()
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightGiaiTich);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new RightDeadGiaiTichState();
            enemy.position.Y += 16;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.state = new LeftGiaiTichState();
        }
        public void GoRight(Enemy enemy)
        {
            enemy.position.X++;
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            enemy.position.Y++;
            enemy.physState.Update(enemy, gameTime);
            sprite.Update(gameTime);
            if (enemy.left)
            {
                enemy.GoLeft();
            }
            else
            {
                enemy.GoRight();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
