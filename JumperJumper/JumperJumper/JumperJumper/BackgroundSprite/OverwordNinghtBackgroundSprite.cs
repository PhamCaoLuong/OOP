using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class OverwordNinghtBackgroundSprite : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public float xpos = 0, ypos = 0;
        public int UpdateSpeed { get; set; }

        public OverwordNinghtBackgroundSprite(Texture2D texure, int rows, int columns)
        {
            Texture = texure;
            Rows = rows;
            Columns = columns;
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }

        public void Update(GameTime gametime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 loaction, Color color)
        {
            spriteBatch.Draw(Texture, new Rectangle(0, 0, 800, 500), color);
        }
    }
}
