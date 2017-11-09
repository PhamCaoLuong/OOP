using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumperJumper
{
    public class VictoryGameState : IGameState
    {
        Game1 game;
        int walkTimer = 30;
        int slowFrames = 3;
        RightCommand right;

        public VictoryGameState(Game1 game)
        {
            this.game = game;
            game.isVictory = true;
            //SoundManager.StopMusic();
            //SoundManager.clear.Play();
            right = new RightCommand(game.level.teno);
            game.gameHUD.gameEnded = true;
            game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Level1);
        }

        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            if (walkTimer > 0)
            {
                if (slowFrames >= ValueHolder.slowdownRate)
                {
                    right.Execute();
                    game.level.Update(gameTime);
                    slowFrames = 0;
                }
                slowFrames *= 2;
            }
            else
            {
                game.level.teno.MakeVictoryTeno();
                if (walkTimer < -70)
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
            walkTimer--;

            if (game.gameHUD.Time > 0)
            {
                game.gameHUD.Time--;
                game.gameHUD.Score += ValueHolder.remainingTimePoints;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
