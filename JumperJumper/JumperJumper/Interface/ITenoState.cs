using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public interface ITenoState
    {
        IAnimatedSprite Sprite { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Up();
        void Down();
        void GoLeft();
        void GoRight();
        void Idle();
        void Land();
        void Fall();
        void MakeTeno();
        void MakeDeadTeno();
        void Flip();
        Rectangle GetBoundingBox(Vector2 location);
    }
}
