#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Pikmin_4
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// contains the state of the game and what panel is currently displayed
        /// </summary>
        String baseState;

        /// <summary>
        /// Used to maintain the keys pressed.
        /// </summary>
        public static KeyboardState kbState,oldkbState;

        /// <summary>
        /// Used to maintain the cursors information
        /// </summary>
        public static MouseState mState,oldmState;

        /// <summary>
        /// Position handler of mouse.
        /// </summary>
        private Cursor cursor = new Cursor();

        /// <summary>
        /// Dictionary of all images used in the title screen
        /// </summary>
        public static Dictionary<String, Texture2D> TITLE_IMAGES;

        /// <summary>
        /// Dictionary of all images used for the pikmin
        /// </summary>
        public static Dictionary<String, Texture2D> PIKMIN_IMAGES;

        /// <summary>
        /// Dictionary of all images used for the playable Characters
        /// </summary>
        public static Dictionary<String, Texture2D> PLAYER_IMAGES;

        /// <summary>
        /// Dictionary of all images used for enemies
        /// </summary>
        public static Dictionary<String, Texture2D> ENEMY_IMAGES;

        /// <summary>
        /// Dictionary of all images used for walls with collisions
        /// </summary>
        public static Dictionary<String, Texture2D> FOREGROUND_IMAGES;

        /// <summary>
        /// Dictionary of all images used for the background
        /// </summary>
        public static Dictionary<String, Texture2D> BACKGROUND_IMAGES;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

            TITLE_IMAGES = new Dictionary<String, Texture2D>();
            PIKMIN_IMAGES = new Dictionary<String, Texture2D>();
            PLAYER_IMAGES = new Dictionary<String, Texture2D>();
            ENEMY_IMAGES = new Dictionary<string, Texture2D>();
            BACKGROUND_IMAGES = new Dictionary<string, Texture2D>();
            FOREGROUND_IMAGES = new Dictionary<string, Texture2D>();

            kbState = new KeyboardState();
            mState = new MouseState();
            baseState = "main";

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Adds all the images for the title screen to this dictionary.
            TITLE_IMAGES.Add("background", Content.Load<Texture2D>("title/background"));
            TITLE_IMAGES.Add("title", Content.Load<Texture2D>("title/title"));
            TITLE_IMAGES.Add("cursor", Content.Load<Texture2D>("title/Title_Cursor"));
            TITLE_IMAGES.Add("pikminFamily", Content.Load<Texture2D>("title/Pikmin_Family"));
            TITLE_IMAGES.Add("blueLeaf", Content.Load<Texture2D>("title/Leaf_Blue_Pikmin_Front"));
            TITLE_IMAGES.Add("redLeaf", Content.Load<Texture2D>("title/Leaf_Red_Pikmin_Front"));
            TITLE_IMAGES.Add("yellowLeaf", Content.Load<Texture2D>("title/Leaf_Yellow_Pikmin_Front"));
            TITLE_IMAGES.Add("whiteLeaf", Content.Load<Texture2D>("title/Leaf_White_Pikmin_Front"));
            TITLE_IMAGES.Add("purpleLeaf", Content.Load<Texture2D>("title/Leaf_Purple_Pikmin_Front"));
            TITLE_IMAGES.Add("rockLeaf", Content.Load<Texture2D>("title/Leaf_Rock_Pikmin_Front"));
            TITLE_IMAGES.Add("flyingLeaf", Content.Load<Texture2D>("title/Leaf_Flying_Pikmin_Front"));

            // Adds all the images for playable characters to this dictionary.
            PLAYER_IMAGES.Add("olimarRight1", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk1"));
            PLAYER_IMAGES.Add("olimarRight2", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk2"));
            PLAYER_IMAGES.Add("olimarRight3", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk3"));

            // Adds all the images for pikmin to this dictionary.
            PIKMIN_IMAGES.Add("blueLeafRight1", Content.Load<Texture2D>("PikminAnimation/blue_leaf_walk_1"));
            PIKMIN_IMAGES.Add("blueLeafRight2", Content.Load<Texture2D>("PikminAnimation/blue_leaf_walk_2"));
            PIKMIN_IMAGES.Add("blueLeafRight3", Content.Load<Texture2D>("PikminAnimation/blue_leaf_walk_3"));
            PIKMIN_IMAGES.Add("blueBudRight1", Content.Load<Texture2D>("PikminAnimation/blue_bud_walk_1"));
            PIKMIN_IMAGES.Add("blueBudRight2", Content.Load<Texture2D>("PikminAnimation/blue_bud_walk_2"));
            PIKMIN_IMAGES.Add("blueBudRight3", Content.Load<Texture2D>("PikminAnimation/blue_bud_walk_3"));
            PIKMIN_IMAGES.Add("blueFlowerRight1", Content.Load<Texture2D>("PikminAnimation/blue_flower_walk_1"));
            PIKMIN_IMAGES.Add("blueFlowerRight2", Content.Load<Texture2D>("PikminAnimation/blue_flower_walk_2"));
            PIKMIN_IMAGES.Add("blueFlowerRight3", Content.Load<Texture2D>("PikminAnimation/blue_flower_walk_3"));

            PIKMIN_IMAGES.Add("redLeafRight1", Content.Load<Texture2D>("PikminAnimation/red_leaf_walk_1"));
            PIKMIN_IMAGES.Add("redLeafRight2", Content.Load<Texture2D>("PikminAnimation/red_leaf_walk_2"));
            PIKMIN_IMAGES.Add("redLeafRight3", Content.Load<Texture2D>("PikminAnimation/red_leaf_walk_3"));
            PIKMIN_IMAGES.Add("redBudRight1", Content.Load<Texture2D>("PikminAnimation/red_bud_walk_1"));
            PIKMIN_IMAGES.Add("redBudRight2", Content.Load<Texture2D>("PikminAnimation/red_bud_walk_2"));
            PIKMIN_IMAGES.Add("redBudRight3", Content.Load<Texture2D>("PikminAnimation/red_bud_walk_3"));
            PIKMIN_IMAGES.Add("redFlowerRight1", Content.Load<Texture2D>("PikminAnimation/red_flower_walk_1"));
            PIKMIN_IMAGES.Add("redFlowerRight2", Content.Load<Texture2D>("PikminAnimation/red_flower_walk_2"));
            PIKMIN_IMAGES.Add("redFlowerRight3", Content.Load<Texture2D>("PikminAnimation/red_flower_walk_3"));

            PIKMIN_IMAGES.Add("yellowLeafRight1", Content.Load<Texture2D>("PikminAnimation/yellow_leaf_walk_1"));
            PIKMIN_IMAGES.Add("yellowLeafRight2", Content.Load<Texture2D>("PikminAnimation/yellow_leaf_walk_2"));
            PIKMIN_IMAGES.Add("yellowLeafRight3", Content.Load<Texture2D>("PikminAnimation/yellow_leaf_walk_3"));
            PIKMIN_IMAGES.Add("yellowBudRight1", Content.Load<Texture2D>("PikminAnimation/yellow_bud_walk_1"));
            PIKMIN_IMAGES.Add("yellowBudRight2", Content.Load<Texture2D>("PikminAnimation/yellow_bud_walk_2"));
            PIKMIN_IMAGES.Add("yellowBudRight3", Content.Load<Texture2D>("PikminAnimation/yellow_bud_walk_3"));
            PIKMIN_IMAGES.Add("yellowFlowerRight1", Content.Load<Texture2D>("PikminAnimation/yellow_flower_walk_1"));
            PIKMIN_IMAGES.Add("yellowFlowerRight2", Content.Load<Texture2D>("PikminAnimation/yellow_flower_walk_2"));
            PIKMIN_IMAGES.Add("yellowFlowerRight3", Content.Load<Texture2D>("PikminAnimation/yellow_flower_walk_3"));

            PIKMIN_IMAGES.Add("whiteLeafRight1", Content.Load<Texture2D>("PikminAnimation/white_leaf_walk_1"));
            PIKMIN_IMAGES.Add("whiteLeafRight2", Content.Load<Texture2D>("PikminAnimation/white_leaf_walk_2"));
            PIKMIN_IMAGES.Add("whiteLeafRight3", Content.Load<Texture2D>("PikminAnimation/white_leaf_walk_3"));
            PIKMIN_IMAGES.Add("whiteBudRight1", Content.Load<Texture2D>("PikminAnimation/white_bud_walk_1"));
            PIKMIN_IMAGES.Add("whiteBudRight2", Content.Load<Texture2D>("PikminAnimation/white_bud_walk_2"));
            PIKMIN_IMAGES.Add("whiteBudRight3", Content.Load<Texture2D>("PikminAnimation/white_bud_walk_3"));
            PIKMIN_IMAGES.Add("whiteFlowerRight1", Content.Load<Texture2D>("PikminAnimation/white_flower_walk_1"));
            PIKMIN_IMAGES.Add("whiteFlowerRight2", Content.Load<Texture2D>("PikminAnimation/white_flower_walk_2"));
            PIKMIN_IMAGES.Add("whiteFlowerRight3", Content.Load<Texture2D>("PikminAnimation/white_flower_walk_3"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            oldmState = mState;
            oldkbState = kbState;
            mState = Mouse.GetState();
            kbState = Keyboard.GetState();
            cursor.update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            if(baseState.Equals("main"))
            {
                spriteBatch.Draw(TITLE_IMAGES["background"], new Vector2(0, 0), Color.White);
                spriteBatch.Draw(TITLE_IMAGES["title"], new Vector2(100, 25), Color.White);
                spriteBatch.Draw(TITLE_IMAGES["cursor"], cursor.getPosition(), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
