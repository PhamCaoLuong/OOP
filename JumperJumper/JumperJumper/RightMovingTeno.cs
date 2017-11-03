﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    class RightMovingTeno : ITenoState
    {
        Teno teno;
        public IAnimatedSprite Sprite { get; set; }

        public RightMovingTeno(Teno teno)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightMovingTeno);
            this.teno = teno;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void Up()
        {
            teno.state = new RightJumpingTeno(teno);
        }
        public void Down()
        {
            teno.state = new RightCrouchingTeno(teno);
        }
        public void GoLeft()
        {
            teno.state = new LeftMovingTeno(teno);
        }
        public void GoRight()
        {
            
        }
        public void Idle()
        {
            teno.state = new RightIdleTeno(teno);
        }
        public void Land()
        {

        }
        public void Fall()
        {
        }
        public void MakeTeno()
        {

        }


        public void MakeDeadTeno()
        {
            teno.state = new DeadTeno(teno);
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
    }
}

