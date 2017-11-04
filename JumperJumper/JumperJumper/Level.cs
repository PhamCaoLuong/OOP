using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;

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
        private List<Enemy> levelEnemies;
        private List<House> levelHouses;
        private List<ICollectable> levelItems;

        public LevelBuilder builder;
        public CollisionDetector collision;
        bool isVictory = false;
        public bool isUnderGround = false;
        public Vector2 exitPosition { get; set; }
        public IAnimatedSprite exitPole { get; set; }
        public Vector2 checkpoint;


        public Level(string fileName)
        {
            game = new Game1();
            builder = new LevelBuilder(this);
            teno = builder.Build(fileName);
            game.gameCamera.LookAt(teno.position);
            collision = new CollisionDetector(teno, game);
            exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("gateFramedFinal"), 2, 23);
            game.gameHUD.Time = ValueHolder.startingTime;
        }

        public void Update(GameTime gameTime)
        {
            game.background.CurrentSprite.Update(gameTime);
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Update(gameTime);
            }

            foreach (House pipeUpdater in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeUpdater.getBoundingBox()))
                {
                    pipeUpdater.Update(gameTime);
                }
            }

            foreach (Block blockUpdater in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockUpdater.getBoundingBox()))
                {
                    blockUpdater.Update(gameTime);
                }
            }

            if(game.gameCamera.InCameraView(exitPole.GetBoundingBox()))
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
                game.gameState = new VictoryGameState();
                exitPole = new GateSprite(Game1.gameContent.Load<Texture2D>("gateBroken"), 1, 1);
                isVictory = true;
            }
            game.gameCamera.LookAt(teno.position);
        }

        public void Draw(SpriteBatch spriteBacth)
        {
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgroundObjects)
            {
                backgroundObject.Key.Draw(spriteBacth);
            }
            foreach (House pipeDrawer in levelPipe)
            {
                if(game.gameCamera.InCameraView(pipeDrawer.GetBoundingBox()))
                {
                    pipeDrawer.Draw(spriteBacth);
                }
            }

            foreach (Block blockDrawer in levelBlock)
            {
                if(game.gameCamera.InCameraView(blockDrawer.GetBoundingBox()))
                {
                    blockDrawer.Draw(spriteBacth);
                }
            }
            if(game.gameCamera.InCameraView(exitPole.GetBoundingBox()))
            {
                exitPole.Draw(spriteBacth, exitPosition);
            }
            /* if(!game.isTitle)
             * {
             *      teno.Draw(spriteBacth);
             * }
            */
        }
    }
}
