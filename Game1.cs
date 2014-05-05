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
        /// Contains the state of the game and what panel is currently displayed:
        ///     "main": Title screen.
        ///     "game": Game screen.
        /// </summary>
        public static String baseState;

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
        private Cursor cursor;

        /// <summary>
        /// Button that when clicked will change the game state to "game"
        /// </summary>
        private Button playButton;

        /// <summary>
        /// Dictionary of all objects that can have collisions
        /// </summary>
        public static Dictionary<String, Object> COLLISIONS;

        /// <summary>
        /// Dictionary of all images used in the title screen
        /// </summary>
        public static Dictionary<String, Texture2D> TITLE_IMAGES;

        /// <summary>
        /// Dictionary of all images used for buttons
        /// </summary>
        public static Dictionary<String, Texture2D> BUTTON_IMAGES;

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
            BUTTON_IMAGES = new Dictionary<String, Texture2D>();
            PIKMIN_IMAGES = new Dictionary<String, Texture2D>();
            PLAYER_IMAGES = new Dictionary<String, Texture2D>();
            ENEMY_IMAGES = new Dictionary<String, Texture2D>();
            BACKGROUND_IMAGES = new Dictionary<String, Texture2D>();
            FOREGROUND_IMAGES = new Dictionary<String, Texture2D>();

            COLLISIONS = new Dictionary<string, object>();

            kbState = new KeyboardState();
            mState = new MouseState();
            baseState = "main";

            base.Initialize();
        }

        /// <summary>
        /// Called at the beginning of the game. Loads stuff out of Content folder.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Adds all the images for the title screen to this dictionary.
            TITLE_IMAGES.Add("background", Content.Load<Texture2D>("title/background"));
            TITLE_IMAGES.Add("title", Content.Load<Texture2D>("title/title"));
            TITLE_IMAGES.Add("pikminFamily", Content.Load<Texture2D>("title/Pikmin_Family"));

            // Adds all the images for buttons
            BUTTON_IMAGES.Add("play", Content.Load<Texture2D>("Buttons/Play_Button"));
            playButton = new Button(350, 300, BUTTON_IMAGES["play"].Width, BUTTON_IMAGES["play"].Height,
                                    "game", BUTTON_IMAGES["play"]);
            COLLISIONS.Add("playButton", playButton);

            // Adds all the images for playable characters to this dictionary.
            PLAYER_IMAGES.Add("olimarRight1", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk1"));
            PLAYER_IMAGES.Add("olimarRight2", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk2"));
            PLAYER_IMAGES.Add("olimarRight3", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk3"));

            // Adds all the images for pikmin to this dictionary.
            PIKMIN_IMAGES.Add("blueLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Blue_Pikmin_Front"));
            PIKMIN_IMAGES.Add("redLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Red_Pikmin_Front"));
            PIKMIN_IMAGES.Add("yellowLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Yellow_Pikmin_Front"));
            PIKMIN_IMAGES.Add("whiteLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_White_Pikmin_Front"));
            PIKMIN_IMAGES.Add("purpleLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Purple_Pikmin_Front"));
            PIKMIN_IMAGES.Add("rockLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Rock_Pikmin_Front"));
            PIKMIN_IMAGES.Add("flyingLeafFront", Content.Load<Texture2D>("PikminAnimation/Leaf_Flying_Pikmin_Front"));

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


            //Adds images for enemies and animations for enemies.
            //ENEMY_IMAGES.Add("|_Enemy_Image_Names_|", Content.Load<Texture2D>("|_Content_Location_|"));


            //Adds foreground images and images that have collision.
            FOREGROUND_IMAGES.Add("gameCursor", Content.Load<Texture2D>("Cursors/Game_Cursor"));
            FOREGROUND_IMAGES.Add("titleCursor", Content.Load<Texture2D>("Cursors/Title_Cursor"));
            cursor = new Cursor(FOREGROUND_IMAGES["titleCursor"]);
            COLLISIONS.Add("cursor", cursor);


            //Adds background images and images that dont have collision.
            //BACKGROUND_IMAGES.Add("|_background images names_|", Content.Load<Texture2D>("|_Content Location_|"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
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
            CollisionHandler.update();


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
                if (cursor.getImage() != FOREGROUND_IMAGES["titleCursor"])
                    cursor.setImage(FOREGROUND_IMAGES["titleCursor"]);
                spriteBatch.Draw(TITLE_IMAGES["background"], new Vector2(0, 0), Color.White);
                spriteBatch.Draw(TITLE_IMAGES["title"], new Vector2(100, 25), Color.White);

                if (playButton.isSelected())
                    spriteBatch.Draw(playButton.getImage(), playButton.getPosition(), Color.Black);
                else
                    spriteBatch.Draw(playButton.getImage(), playButton.getPosition(), Color.White);

                spriteBatch.Draw(cursor.getImage(), cursor.getPosition(), Color.White);
                if (playButton.isClicked())
                    baseState = "game";
            }
            else if (baseState.Equals("game"))
            {
                if (cursor.getImage() != FOREGROUND_IMAGES["gameCursor"])
                    cursor.setImage(FOREGROUND_IMAGES["gameCursor"]);
                spriteBatch.Draw(cursor.getImage(), cursor.getPosition(), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
