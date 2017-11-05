using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper.GameState
{
    class TrasitionGameState : IGameState
    {
        Game1 game;
        Teno teno;
        int timer = 50, timeMod = 5;
        ITenoState prevState, newState, currentState;

        public TrasitionGameState(Teno teno, ITenoState prevState, ITenoState newState)
        {
            game = Game1.GetInstance();
            this.teno = teno;
            this.prevState = prevState;
            this.newState = newState;
            currentState = prevState;
        }
        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            Rectangle prevRect = prevState.GetBoundingBox(teno.position);
            Rectangle newRect = newState.GetBoundingBox(teno.position);
            timer--;
            if (currentState == prevState && timer % timeMod == 0)
            {
                currentState = newState;
                teno.state = newState;
                teno.position.Y -= (newRect.Height - prevRect.Height);
            }
            else if (timer % timeMod == 0 && currentState == newState)
            {
                currentState = prevState;
                teno.state = prevState;
                teno.position.Y += (newRect.Height - prevRect.Height);
            }
            if (timer <= 0)
            {
                teno.position.Y -= (newRect.Height - prevRect.Height);
                teno.state = newState;
                game.gameState = new TenoGameState();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
