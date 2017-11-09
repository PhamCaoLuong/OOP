﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class GameOverState : IGameState
    {
        Game1 game;
        SpriteFont font;
        int songTimer = 370;

        public GameOverState()
        {
            game = Game1.GetInstance();
            game.isGameOver = true;
            font = game.Content.Load<SpriteFont>(StringHolder.bigTextFont);
        }

        public void Update(GameTime gameTime)
        {
            songTimer--;
            if (songTimer < 0)
            {
                Game1.GetInstance().level = new Level(game, StringHolder.levelOne);
                Game1.GetInstance().background.CurrentSprite = Game1.GetInstance().background.OverworldSprite;
                Game1.GetInstance().gameState = new TitleScreenGameState();
                Game1.GetInstance().isTitle = true;
                Game1.GetInstance().gameHUD.Coins = 0;
                Game1.GetInstance().gameHUD.Lives = 3;
                Game1.GetInstance().gameHUD.Score = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, StringHolder.gameOverMessage, game.gameCamera.CenterScreen + ValueHolder.textPosition, 
                Color.White);
        }
    }
}
