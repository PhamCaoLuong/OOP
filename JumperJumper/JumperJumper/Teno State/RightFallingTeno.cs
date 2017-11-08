﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class RightFallingTeno : ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        
        public RightFallingTeno(Teno teno)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightFallingTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            teno.TransitionState(teno.state, new RightFallingTeno(teno));
        }
        public void Up()
        {
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
            teno.state = new LeftFallingTeno(teno);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
        }
        public void Land()
        {
            teno.state = new RightMovingTeno(teno);
        }
        public void Fall()
        {
        }
        public void Flip() { }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }

        public void MakeTeno()
        {
            
        }

        public void MakeDeadTeno()
        {
            teno.state = new DeadTeno(teno);
        }
    }
}