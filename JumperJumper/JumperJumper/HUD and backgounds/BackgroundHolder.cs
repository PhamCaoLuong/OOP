using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class BackgroundHolder
    {
        Game1 game;
        ISpriteFactory factory;

        public IAnimatedSprite H1Sprite { get; set; }
        public IAnimatedSprite H2Sprite { get; set; }
        public IAnimatedSprite H3Sprite { get; set; }
        public IAnimatedSprite H6Sprite { get; set; }
        public IAnimatedSprite CurrentSprite { get; set; }

        public BackgroundHolder(Game1 game)
        {
            this.game = game;

            factory = new SpriteFactory();
            H1Sprite = factory.build(SpriteFactory.sprites.H1Background);
            H2Sprite = factory.build(SpriteFactory.sprites.H2Background);
            H3Sprite = factory.build(SpriteFactory.sprites.H3Background);
            H6Sprite = factory.build(SpriteFactory.sprites.H6Background);
            if (game.level.levelCurrent == "MapLevel1")
            {
                CurrentSprite = H1Sprite;
            }
            else
                CurrentSprite = H2Sprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentSprite.Draw(spriteBatch, new Vector2(0, 0), Color.White);
        }
    }
}
