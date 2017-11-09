using System;
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

        public GameOverState(Game1 game)
        {
            this.game = game;
            game.isGameOver = true;
            font = game.Content.Load<SpriteFont>(StringHolder.bigTextFont);
        }

        public void Update(GameTime gameTime)
        {
            songTimer--;
            if (songTimer < 0)
            {
                game.level = new Level(game, StringHolder.levelOne);
                game.background.CurrentSprite = game.background.H1Sprite;
                game.gameState = new TitleScreenGameState(game);
                game.isTitle = true;
                game.gameHUD.Coins = 0;
                game.gameHUD.Lives = 3;
                game.gameHUD.Score = 0;
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
