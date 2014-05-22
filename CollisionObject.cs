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
        private bool facingLeft;

        /// <summary>
        /// True if object is moving right
        /// </summary>
        private bool facingRight;

        /// <summary>
        /// The x coordinate of the object
        /// </summary>
        private int x;

        /// <summary>
        /// The y coordinate of the object
        /// </summary>
        private int y;

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
        /// All images involved in moving right
        /// </summary>
        private List<Texture2D> rightAnimations;

        /// <summary>
        /// All images involved in moving left.
        /// </summary>
        private List<Texture2D> leftAnimations;


        /// <summary>
        /// Constructor for objects that have animations
        /// </summary>
        /// <param name="type">child class name</param>
        /// <param name="nx">x position</param>
        /// <param name="ny">y position</param>
        /// <param name="left">images for the animation to the left</param>
        /// <param name="right">images for the animation to the right</param>
        public CollisionObject(String type, int nx, int ny, List<Texture2D> left, List<Texture2D> right)
        {
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
            width = left[0].Width;
            height = left[0].Height;
            leftAnimations = left;
            rightAnimations = right;
            aniCount = 0;
            facingLeft = true;
        }

        /// <summary>
        /// Constructor for objects that don't have animations
        /// </summary>
        /// <param name="type">child class name</param>
        /// <param name="nx">x position</param>
        /// <param name="ny">y position</param>
        /// <param name="image">the image to display for this object</param>
        public CollisionObject(String type, int nx, int ny, Texture2D image)
        {
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
            width = image.Width;
            height = image.Height;
            leftAnimations = new List<Texture2D>();
            leftAnimations.Add(image);
            rightAnimations = new List<Texture2D>();
            rightAnimations.Add(image);
            aniCount = 0;
            facingLeft = true;
        }


        /// <summary>
        /// Gets the x position of the object
        /// </summary>
        /// <returns>(int) x position</returns>
        public int getX() { return x; }

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
        public int getY() { return y; }

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
        /// Gets the Vector2 representation of the position
        /// </summary>
        /// <returns>(Vector2) position</returns>
        public Vector2 getPosition() { return position; }

        /// <summary>
        /// Sets the position
        /// </summary>
        /// <param name="nx">new x</param>
        /// <param name="ny">new y</param>
        public void setPosition(int nx, int ny)
        {
            x = nx;
            y = ny;
            position = new Vector2(nx, ny);
        }


        public Texture2D getCurrentImage()
        {
            if (leftAnimations.Count() == 1)
                return leftAnimations[0];
            return leftAnimations[0];
        }


        public void setImage(int index, Texture2D imag)
        {
            leftAnimations[index] = imag;
            rightAnimations[index] = imag;
        }


        public void draw(SpriteBatch spriteBatch)
        {
            if(facingLeft)
                spriteBatch.Draw(leftAnimations[aniCount], position, Color.White);
            else if(facingRight)
                spriteBatch.Draw(rightAnimations[aniCount], position, Color.White);
            aniCount++;
            if (aniCount % leftAnimations.Count() == 0)
                aniCount = 0;
        }
    }
}