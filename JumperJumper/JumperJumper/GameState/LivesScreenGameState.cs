using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace JumperJumper
{
    class LivesScreenGameState : IGameState
    {
        int timer = 150;
        SpriteFont font;
        Game1 game;

        public LivesScreenGameState(Game1 game)
        {
            this.game = game;
            game.gameHUD.Lives--;
            font = game.Content.Load<SpriteFont>(StringHolder.bigTextFont);
            game.keyboardController = new PauseMenuKeyController(game);
            game.gameHUD.Time = ValueHolder.startingTime;
            game.gameHUD.textColor = ValueHolder.blackScreenText;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                game.level = new Level(game, StringHolder.levelOne);
                game.gameState = new TenoGameState(game);
                //SoundManager.currentSong = SoundManager.songs.nullSong;
                //SoundManager.PlaySong(SoundManager.songs.overworld);
                game.gameHUD.textColor = ValueHolder.normalScreenText;
            }
            game.keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, StringHolder.livesText + game.gameHUD.Lives, game.gameCamera.CenterScreen +
                ValueHolder.textPosition, Color.White);
        }
    }
}
