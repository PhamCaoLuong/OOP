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
        public List<Enemy> levelEnemies = new List<Enemy>();
        public List<House> levelHouses = new List<House>();
        public List<ICollectable> levelItems = new List<ICollectable>();

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
            game.gameCamera.LookAt(teno.position);
            collision = new CollisionDetector(teno, game);
            exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("Item/exit"), 1, 1);
            game.gameHUD.Time = ValueHolder.startingTime;
        }

        public void Update(GameTime gameTime)
        {
            game.background.CurrentSprite.Update(gameTime);
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Update(gameTime);
            }
            foreach (Enemy enemy in levelEnemies)
            {
                if (game.gameCamera.InCameraView(enemy.GetBoundingBox()))
                {
                    enemy.Update(gameTime);
                }
            }
            /*foreach (House pipeUpdater in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeUpdater.getBoundingBox()))
                {
                    pipeUpdater.Update(gameTime);
                }
            }
            */
            foreach (ICollectable item in levelItems)
            {
                if (game.gameCamera.InCameraView(item.GetBoundingBox()))
                {
                    item.Update(gameTime);
                }
            }
            foreach (Block blockUpdater in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockUpdater.GetBoundingBox()))
                {
                    blockUpdater.Update(gameTime);
                }
            }

            if(game.gameCamera.InCameraView(exitPole.GetBoundingBox(exitPosition)))
            {
                exitPole.Update(gameTime);
            }

            collision.Detect(teno, levelEnemies, levelBlock, levelHouses, levelItems);
            teno.Update(gameTime);
            if(teno.position.X < 0)
            {
                teno.position.X = 0;
            }
            if(teno.position.X > exitPosition.X && !isVictory && !isUnderGround )
            {
                game.gameState = new VictoryGameState(game);
                isVictory = true;
            }
            game.gameCamera.LookAt(teno.position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Draw(spriteBatch, backgroundObject.Value, Color.White);
            }
            /*foreach (House pipeDrawer in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeDrawer.GetBoundingBox()))
                {
                    pipeDrawer.Draw(spriteBacth);
                }
            }*/
            foreach (ICollectable item in levelItems)
            {
                if (game.gameCamera.InCameraView(item.GetBoundingBox()))
                {
                    item.Draw(spriteBatch);
                }
            }

            foreach (Enemy enemy in levelEnemies)
            {
                if (game.gameCamera.InCameraView(enemy.GetBoundingBox()))
                {
                    enemy.Draw(spriteBatch);
                }
            }

            foreach (Block blockDrawer in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockDrawer.GetBoundingBox()))
                {
                    blockDrawer.Draw(spriteBatch, blockDrawer.position);
                }
            }
            if(game.gameCamera.InCameraView(exitPole.GetBoundingBox(exitPosition)))
            {
                exitPole.Draw(spriteBatch, exitPosition, Color.White);
            }
            if(!game.isTitle)
            {
                 teno.Draw(spriteBatch);
            }

        }
    }
}
