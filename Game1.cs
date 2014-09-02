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
        /// Cursor to keep track of the mouse.
        /// </summary>
        private static Cursor cursor;

        /// <summary>
        /// Button that when clicked will change the game state to "game"
        /// </summary>
        private Button playButton;
            
        /// <summary>
        /// Button that when clicked will change the game state to "options"
        /// </summary>
        private Button optionButton;

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
        /// Dictionary of all images used for walls and grass and stuff
        /// </summary>
        public static Dictionary<String, Texture2D> BLOCK_IMAGES;

        /// <summary>
        /// Dictionary of all images used for walls and grass and stuff
        /// </summary>
        public static Dictionary<String, Texture2D> FOREGROUND_IMAGES;

        /// <summary>
        /// Counts every frame.
        /// </summary>
        public static int TIMER;

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
            BLOCK_IMAGES = new Dictionary<String, Texture2D>();
            FOREGROUND_IMAGES = new Dictionary<String, Texture2D>();

            COLLISIONS = new Dictionary<string, object>();
            TIMER = 0;

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
            BUTTON_IMAGES.Add("options", Content.Load<Texture2D>("Buttons/Option_Button"));
            playButton = new Button(350, 300, BUTTON_IMAGES["play"].Width, BUTTON_IMAGES["play"].Height,
                                    "game", BUTTON_IMAGES["play"]);
            optionButton = new Button(350, 330, BUTTON_IMAGES["options"].Width, BUTTON_IMAGES["options"].Height,
                                    "options", BUTTON_IMAGES["options"]);
            COLLISIONS.Add("playButton", playButton);
            COLLISIONS.Add("optionsButton", optionButton);

            // Adds all the images for playable characters to this dictionary.
            PLAYER_IMAGES.Add("olimarRight1", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk1"));
            PLAYER_IMAGES.Add("olimarRight2", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk2"));
            PLAYER_IMAGES.Add("olimarRight3", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk3"));
            PLAYER_IMAGES.Add("olimarRight4", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk4"));
            PLAYER_IMAGES.Add("olimarRight5", Content.Load<Texture2D>("PlayerAnimation/olimar_right_walk5"));
            PLAYER_IMAGES.Add("whistle1", Content.Load<Texture2D>("PlayerAnimation/whistle_1"));
            PLAYER_IMAGES.Add("whistle2", Content.Load<Texture2D>("PlayerAnimation/whistle_2"));
            PLAYER_IMAGES.Add("whistle3", Content.Load<Texture2D>("PlayerAnimation/whistle_3"));

            // Adds all the images for pikmin to this dictionary.
            PIKMIN_IMAGES.Add("blueLeafFront", Content.Load<Texture2D>("PikminAnimation/Blue/blue_leaf_stand"));
            PIKMIN_IMAGES.Add("blueBudFront", Content.Load<Texture2D>("PikminAnimation/Blue/blue_bud_stand"));
            PIKMIN_IMAGES.Add("blueFlowerFront", Content.Load<Texture2D>("PikminAnimation/Blue/blue_flower_stand"));
            PIKMIN_IMAGES.Add("redLeafFront", Content.Load<Texture2D>("PikminAnimation/Red/red_leaf_stand"));
            PIKMIN_IMAGES.Add("yellowLeafFront", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_leaf_stand"));
            PIKMIN_IMAGES.Add("whiteLeafFront", Content.Load<Texture2D>("PikminAnimation/White/white_leaf_stand"));
            PIKMIN_IMAGES.Add("purpleLeafFront", Content.Load<Texture2D>("PikminAnimation/Purple/purple_leaf_stand"));
            PIKMIN_IMAGES.Add("rockLeafFront", Content.Load<Texture2D>("PikminAnimation/Rock/rock_leaf_stand"));
            PIKMIN_IMAGES.Add("flyingLeafFront", Content.Load<Texture2D>("PikminAnimation/Flying/flying_leaf_stand"));

            PIKMIN_IMAGES.Add("blueLeafRight1", Content.Load<Texture2D>("PikminAnimation/Blue/blue_leaf_walk_1"));
            PIKMIN_IMAGES.Add("blueLeafRight2", Content.Load<Texture2D>("PikminAnimation/Blue/blue_leaf_walk_2"));
            PIKMIN_IMAGES.Add("blueLeafRight3", Content.Load<Texture2D>("PikminAnimation/Blue/blue_leaf_walk_3"));
            PIKMIN_IMAGES.Add("blueBudRight1", Content.Load<Texture2D>("PikminAnimation/Blue/blue_bud_walk_1"));
            PIKMIN_IMAGES.Add("blueBudRight2", Content.Load<Texture2D>("PikminAnimation/Blue/blue_bud_walk_2"));
            PIKMIN_IMAGES.Add("blueBudRight3", Content.Load<Texture2D>("PikminAnimation/Blue/blue_bud_walk_3"));
            PIKMIN_IMAGES.Add("blueFlowerRight1", Content.Load<Texture2D>("PikminAnimation/Blue/blue_flower_walk_1"));
            PIKMIN_IMAGES.Add("blueFlowerRight2", Content.Load<Texture2D>("PikminAnimation/Blue/blue_flower_walk_2"));
            PIKMIN_IMAGES.Add("blueFlowerRight3", Content.Load<Texture2D>("PikminAnimation/Blue/blue_flower_walk_3"));

            PIKMIN_IMAGES.Add("redLeafRight1", Content.Load<Texture2D>("PikminAnimation/Red/red_leaf_walk_1"));
            PIKMIN_IMAGES.Add("redLeafRight2", Content.Load<Texture2D>("PikminAnimation/Red/red_leaf_walk_2"));
            PIKMIN_IMAGES.Add("redLeafRight3", Content.Load<Texture2D>("PikminAnimation/Red/red_leaf_walk_3"));
            PIKMIN_IMAGES.Add("redBudRight1", Content.Load<Texture2D>("PikminAnimation/Red/red_bud_walk_1"));
            PIKMIN_IMAGES.Add("redBudRight2", Content.Load<Texture2D>("PikminAnimation/Red/red_bud_walk_2"));
            PIKMIN_IMAGES.Add("redBudRight3", Content.Load<Texture2D>("PikminAnimation/Red/red_bud_walk_3"));
            PIKMIN_IMAGES.Add("redFlowerRight1", Content.Load<Texture2D>("PikminAnimation/Red/red_flower_walk_1"));
            PIKMIN_IMAGES.Add("redFlowerRight2", Content.Load<Texture2D>("PikminAnimation/Red/red_flower_walk_2"));
            PIKMIN_IMAGES.Add("redFlowerRight3", Content.Load<Texture2D>("PikminAnimation/Red/red_flower_walk_3"));

            PIKMIN_IMAGES.Add("yellowLeafRight1", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_leaf_walk_1"));
            PIKMIN_IMAGES.Add("yellowLeafRight2", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_leaf_walk_2"));
            PIKMIN_IMAGES.Add("yellowLeafRight3", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_leaf_walk_3"));
            PIKMIN_IMAGES.Add("yellowBudRight1", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_bud_walk_1"));
            PIKMIN_IMAGES.Add("yellowBudRight2", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_bud_walk_2"));
            PIKMIN_IMAGES.Add("yellowBudRight3", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_bud_walk_3"));
            PIKMIN_IMAGES.Add("yellowFlowerRight1", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_flower_walk_1"));
            PIKMIN_IMAGES.Add("yellowFlowerRight2", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_flower_walk_2"));
            PIKMIN_IMAGES.Add("yellowFlowerRight3", Content.Load<Texture2D>("PikminAnimation/Yellow/yellow_flower_walk_3"));

            PIKMIN_IMAGES.Add("whiteLeafRight1", Content.Load<Texture2D>("PikminAnimation/White/white_leaf_walk_1"));
            PIKMIN_IMAGES.Add("whiteLeafRight2", Content.Load<Texture2D>("PikminAnimation/White/white_leaf_walk_2"));
            PIKMIN_IMAGES.Add("whiteLeafRight3", Content.Load<Texture2D>("PikminAnimation/White/white_leaf_walk_3"));
            PIKMIN_IMAGES.Add("whiteBudRight1", Content.Load<Texture2D>("PikminAnimation/White/white_bud_walk_1"));
            PIKMIN_IMAGES.Add("whiteBudRight2", Content.Load<Texture2D>("PikminAnimation/White/white_bud_walk_2"));
            PIKMIN_IMAGES.Add("whiteBudRight3", Content.Load<Texture2D>("PikminAnimation/White/white_bud_walk_3"));
            PIKMIN_IMAGES.Add("whiteFlowerRight1", Content.Load<Texture2D>("PikminAnimation/White/white_flower_walk_1"));
            PIKMIN_IMAGES.Add("whiteFlowerRight2", Content.Load<Texture2D>("PikminAnimation/White/white_flower_walk_2"));
            PIKMIN_IMAGES.Add("whiteFlowerRight3", Content.Load<Texture2D>("PikminAnimation/White/white_flower_walk_3"));


            //Adds images for enemies and animations for enemies.
            //ENEMY_IMAGES.Add("|_Enemy_Image_Names_|", Content.Load<Texture2D>("|_Content_Location_|"));


            //Adds foreground images and images that have collision.
            FOREGROUND_IMAGES.Add("gameCursor", Content.Load<Texture2D>("Cursors/Game_Cursor"));
            FOREGROUND_IMAGES.Add("titleCursor", Content.Load<Texture2D>("Cursors/Title_Cursor"));
            cursor = new Cursor(FOREGROUND_IMAGES["titleCursor"]);
            COLLISIONS.Add("cursor", cursor);


            //Adds background images and images that dont have collision.
            //BLOCK_IMAGES.Add("|_background images names_|", Content.Load<Texture2D>("|_Content Location_|"));
            BLOCK_IMAGES.Add("grass", Content.Load<Texture2D>("Map Blocks/grass_block"));
            BLOCK_IMAGES.Add("rock", Content.Load<Texture2D>("Map Blocks/rock_block"));
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

            TIMER++;
            oldmState = mState;
            oldkbState = kbState;
            mState = Mouse.GetState();
            kbState = Keyboard.GetState();
            cursor.update();

            if (baseState.Equals("game"))
            {
                GameState.update();
            }

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
            
            if(baseState.Equals("main")) //Frame is on the title screen
            {
                if (cursor.getStandingImage() != FOREGROUND_IMAGES["titleCursor"])
                    cursor.setStand(FOREGROUND_IMAGES["titleCursor"]);
                spriteBatch.Draw(TITLE_IMAGES["background"], new Vector2(0, 0), Color.White);
                spriteBatch.Draw(TITLE_IMAGES["title"], new Vector2(100, 25), Color.White);

                if (playButton.isSelected())
                    spriteBatch.Draw(playButton.getStandingImage(), playButton.getPosition(), Color.LimeGreen);
                else
                    spriteBatch.Draw(playButton.getStandingImage(), playButton.getPosition(), Color.White);

                if (optionButton.isSelected())
                    spriteBatch.Draw(optionButton.getStandingImage(), optionButton.getPosition(), Color.LimeGreen);
                else
                    spriteBatch.Draw(optionButton.getStandingImage(), optionButton.getPosition(), Color.White);

                cursor.draw(spriteBatch);
                if (playButton.isClicked())
                    baseState = "game";
            }
            else if (baseState.Equals("game")) //Frame is on the game screen
            {
                if (cursor.getStandingImage() != FOREGROUND_IMAGES["gameCursor"])
                {
                    GameState.initiate(cursor);
                    cursor.setStand(FOREGROUND_IMAGES["gameCursor"]);
                }
                cursor.draw(spriteBatch);
                GameState.draw(spriteBatch);
            }
            else if (baseState.Equals("options"))
            {
                if (cursor.getStandingImage() != FOREGROUND_IMAGES["titleCursor"])
                    cursor.setStand(FOREGROUND_IMAGES["titleCursor"]);
                cursor.draw(spriteBatch);
                OptionState.draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
