using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class VVVVVVGameState : IGameState
    {
        Game1 game;

        public VVVVVVGameState()
        {
            game = Game1.GetInstance();
            game.level.mario.physState = new VVVVVVGroundState(game.level.teno, 1);
            game.keyboardController = new VVVVVVKeyController(game.level.teno);
            game.background.CurrentSprite = new NullSprite();
            game.gameHUD.PausedCheck = false;
            game.gameHUD.gameEnded = false;
            game.isVVVVVV = true;
            game.isTitle = false;
        }
        public void Update(GameTime gameTime)
        {
            game.keyboardController.Update();
            game.level.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
