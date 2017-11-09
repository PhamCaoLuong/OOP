using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JumperJumper
{
    public class Level
    {
        Game1 game;
        public Teno teno;
        public List<House> levelPipe = new List<House>();
        public List<Block> levelBlock = new List<Block>();
        public List<KeyValuePair<IAnimatedSprite, Vector2>> levelBackgroundObjects = 
                                                            new List<KeyValuePair<IAnimatedSprite, Vector2>>();
        public List<Enemy> levelEnemies;
        public List<House> levelHouses;
        public List<ICollectable> levelItems;

        public LevelBuilder builder;
        public CollisionDetector collision;
        bool isVictory = false;
        public bool isUnderGround = false;
        public Vector2 exitPosition { get; set; }
        public IAnimatedSprite exitPole { get; set; }
        public Vector2 checkpoint;
        public string levelCurrent;

        public Level(Game1 game, string fileName)
        {
            this.game = game;
            levelCurrent = fileName;
            builder = new LevelBuilder(this, game);
            teno = builder.Build(fileName);
            game.gameCamera = Game1.GetInstance().gameCamera;
            if(game.gameCamera != null)
                game.gameCamera.LookAt(teno.position);
            collision = new CollisionDetector(teno, game);
            //exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("gateFramedFinal"), 2, 23);
            if(game.gameHUD != null)
                game.gameHUD.Time = ValueHolder.startingTime;
        }

        public void Update(GameTime gameTime)
        {
            game.background.CurrentSprite.Update(gameTime);
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Update(gameTime);
            }

            /*foreach (House pipeUpdater in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeUpdater.getBoundingBox()))
                {
                    pipeUpdater.Update(gameTime);
                }
            }
            */
            foreach (Block blockUpdater in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockUpdater.GetBoundingBox()))
                {
                    blockUpdater.Update(gameTime);
                }
            }

            /*if(game.gameCamera.InCameraView(exitPole.GetBoundingBox()))
            {
                exitPole.Update(gameTime);
            }*/

            collision.Detect(teno, levelEnemies, levelBlock, levelHouses, levelItems);
            teno.Update(gameTime);
            if(teno.position.X < 0)
            {
                teno.position.X = 0;
            }
            /*if(teno.position.X > exitPosition.X && !isVictory && !isUnderGround )
            {
                game.gameState = new VictoryGameState();
                exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("gateBroken"), 1, 1);
                isVictory = true;
            }*/
            game.gameCamera.LookAt(teno.position);
        }

        public void Draw(SpriteBatch spriteBacth)
        {
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Draw(spriteBacth, backgroundObject.Value, Color.White);
            }
            /*foreach (House pipeDrawer in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeDrawer.GetBoundingBox()))
                {
                    pipeDrawer.Draw(spriteBacth);
                }
            }*/

            foreach (Block blockDrawer in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockDrawer.GetBoundingBox()))
                {
                    blockDrawer.Draw(spriteBacth, blockDrawer.position);
                }
            }
            /*if(game.gameCamera.InCameraView(exitPole.GetBoundingBox()))
            {
                exitPole.Draw(spriteBacth, exitPosition);
            }*/
            /* if(!game.isTitle)
             * {
             *      teno.Draw(spriteBacth);
             * }
            */
        }
    }
}
