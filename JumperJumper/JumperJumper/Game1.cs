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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager gameContent;
        public IController keyboardController;
        public IGameState gameState;
        public Level level;
        public static SoundManager soundManager;
        public Camera gameCamera;
        public bool isPaused = false, isVictory = false, isGameOver = false, isVVVVVV = false, isTitle = true;
        private static Game1 sInstance = new Game1();
        public BackgroundHolder background;
        public HUD gameHUD;
        public AchievementsManager ach;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameContent = Content;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>

        protected override void Initialize()
        {
            soundManager = new SoundManager(this);
            gameCamera = new Camera(GraphicsDevice.Viewport, this);
            gameHUD = new HUD(this);
            level = new Level(this, StringHolder.levelOne);
            keyboardController = new KeyboardController(level.teno);

            gameState = new TitleScreenGameState(this);
            background = new BackgroundHolder(this);
            ach = new AchievementsManager(this);
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameHUD.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
            ach.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            background.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, gameCamera.GetViewMatrix());
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            if (!isTitle && !isVVVVVV)
            {
                spriteBatch.Begin();
                gameHUD.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public static Game1 GetInstance()
        {
            return sInstance;
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

    }
}
