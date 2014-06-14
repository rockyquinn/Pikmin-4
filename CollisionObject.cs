using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    public abstract class CollisionObject
    {
        /// <summary>
        /// The position of this object
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// The Child objects Type
        /// </summary>
        private String type;

        /// <summary>
        /// True if the object can be collided with everything
        /// </summary>
        private bool isCollidable = true;

        /// <summary>
        /// True if object is moving left
        /// </summary>
        private bool facingLeft = false;

        /// <summary>
        /// True if object is moving right
        /// </summary>
        private bool facingRight = false;

        /// <summary>
        /// The x coordinate of the object
        /// </summary>
        private float x;

        /// <summary>
        /// The y coordinate of the object
        /// </summary>
        private float y;

        /// <summary>
        /// the object's width
        /// </summary>
        private int width;

        /// <summary>
        /// The object's height
        /// </summary>
        private int height;

        /// <summary>
        /// Animation count
        /// </summary>
        private int aniCount;

        /// <summary>
        /// If true, animation will continue
        /// </summary>
        private bool animate;

        /// <summary>
        /// All images involved in moving right
        /// </summary>
        private List<Texture2D> rightAnimations;

        /// <summary>
        /// All images involved in moving left.
        /// </summary>
        private List<Texture2D> leftAnimations;

        /// <summary>
        /// Image displayed when animate is false.
        /// </summary>
        private Texture2D stand;

        /// <summary>
        /// How fast an image will be animated
        /// Fast => Slow
        /// </summary>
        private int buffer = 5;


        /// <summary>
        /// Constructor for objects that have animations
        /// </summary>
        /// <param name="type">child class name</param>
        /// <param name="nx">x position</param>
        /// <param name="ny">y position</param>
        /// <param name="left">images for the animation to the left</param>
        /// <param name="right">images for the animation to the right</param>
        public CollisionObject(String typ, float nx, float ny, List<Texture2D> left, List<Texture2D> right, Texture2D still)
        {
            type = typ;
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
            width = left[0].Width;
            height = left[0].Height;
            leftAnimations = left;
            rightAnimations = right;
            aniCount = 0;
            facingLeft = true;
            stand = still;
        }

        /// <summary>
        /// Constructor for objects that don't have animations
        /// </summary>
        /// <param name="type">child class name</param>
        /// <param name="nx">x position</param>
        /// <param name="ny">y position</param>
        /// <param name="image">the image to display for this object</param>
        public CollisionObject(String typ, float nx, float ny, Texture2D image)
        {
            type = typ;
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
            width = image.Width;
            height = image.Height;
            leftAnimations = new List<Texture2D>();
            leftAnimations.Add(image);
            rightAnimations = new List<Texture2D>();
            rightAnimations.Add(image);
            stand = image;
            aniCount = 0;
            facingLeft = true;
        }
        /// <summary>
        /// A very basic constructor where other variables 
        /// must be assigned later
        /// </summary>
        /// <param name="typ">child class name</param>
        /// <param name="nx">x position</param>
        /// <param name="ny">y position</param>
        public CollisionObject(String typ, float nx, float ny)
        {
            type = typ;
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
            aniCount = 0;
            facingLeft = true;
        }


        /// <summary>
        /// Gets the x position of the object
        /// </summary>
        /// <returns>(int) x position</returns>
        public float getX() { return x; }

        /// <summary>
        /// Sets the x position of the object
        /// </summary>
        /// <param name="nx">New x value</param>
        public void setX(int nx) 
        {
            x = nx;
            position = new Vector2(x, y);
        }


        /// <summary>
        /// Gets the y position of the object
        /// </summary>
        /// <returns>(int) y position</returns>
        public float getY() { return y; }

        /// <summary>
        /// Sets the y position
        /// </summary>
        /// <param name="ny">New y position</param>
        public void setY(int ny) 
        {
            y = ny;
            position = new Vector2(x, y);
        }

        /// <summary>
        /// Sets the standing image
        /// </summary>
        /// <param name="still">new image</param>
        public void setStand(Texture2D still)
        {
            stand = still;
        }

        /// <summary>
        /// Sets height
        /// </summary>
        /// <param name="nh">new height</param>
        public void setHeight(int nh) { height = nh; }
        /// <summary>
        /// Gets height
        /// </summary>
        /// <returns>(int) height</returns>
        public int getHeight() { return height; }

        /// <summary>
        /// Sets width
        /// </summary>
        /// <param name="nw">new width</param>
        public void setWidth(int nw) { width = nw; }
        /// <summary>
        /// Gets width
        /// </summary>
        /// <returns>(int) width</returns>
        public int getWidth() { return width; }


        /// <summary>
        /// Gets the Vector2 representation of the position
        /// </summary>
        /// <returns>(Vector2) position</returns>
        public Vector2 getPosition() { return position; }

        /// <summary>
        /// Sets the position
        /// </summary>
        /// <param name="nx">new x</param>
        /// <param name="ny">new y</param>
        public void setPosition(float nx, float ny)
        {
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
        }

        /// <summary>
        /// Gets current animation image
        /// </summary>
        /// <returns>(Texture2D) image</returns>
        public Texture2D getCurrentImage()
        {
            if(facingLeft)
                return leftAnimations[aniCount];
            return rightAnimations[aniCount];
        }

        /// <summary>
        /// sets the image at a certain index to a new index
        /// </summary>
        /// <param name="index">index to be changed</param>
        /// <param name="imag">image to change to</param>
        public void setImage(int index, Texture2D imag)
        {
            leftAnimations[index] = imag;
            rightAnimations[index] = imag;
        }

        /// <summary>
        /// Sets the right facing animations list
        /// </summary>
        /// <param name="l">list of Texture2D objects</param>
        public void setRightAnimations(List<Texture2D> l)
        {
            rightAnimations = l;
        }

        /// <summary>
        /// Sets the left facing animations list
        /// </summary>
        /// <param name="l">list of Texture2D objects</param>
        public void setLeftAnimations(List<Texture2D> l)
        {
            leftAnimations = l;
        }

        /// <summary>
        /// Checks collidability with other objects.
        /// </summary>
        /// <returns>if object is collidable with othe objects</returns>
        public bool getCollidable()
        {
            return isCollidable;
        }

        /// <summary>
        /// Sets buffer
        /// </summary>
        /// <param name="nb">new buffer</param>
        public void setBuffer(int nb)
        {
            buffer = nb;
        }

        /// <summary>
        /// Draws the images
        /// </summary>
        /// <param name="spriteBatch">a SpriteBatch object</param>
        public void draw(SpriteBatch spriteBatch)
        {
            if(!animate)
                spriteBatch.Draw(stand, position, Color.White);
            else if(facingLeft)
                spriteBatch.Draw(leftAnimations[aniCount], position, Color.White);
            else if(facingRight)
                spriteBatch.Draw(rightAnimations[aniCount], position, Color.White);
            if (Game1.TIMER % buffer == 0)
            {
                if (!animate)
                    return;
                aniCount++;
                if (aniCount % leftAnimations.Count() == 0)
                    aniCount = 0;
            }
        }
        
        
        /// <summary>
        /// Compares the positions of an object compared to this one
        /// </summary>
        /// <param name="o">object used for comparison</param>
        public string compareTo(CollisionObject o)
        {
            if(this.x+this.width >= o.x &&
                this.x <= o.x+o.width &&
                this.y+this.height >= o.y &&
                this.y <= o.y+o.height)
            {
                return "collision";
            }
            return "none";
        }


        /// <summary>
        /// To stop animation
        /// </summary>
        public void unanimate()
        {
            animate = false;
        }


        /// <summary>
        /// To start animation
        /// </summary>
        public void reanimate()
        {
            animate = true;
        }
    }
}
