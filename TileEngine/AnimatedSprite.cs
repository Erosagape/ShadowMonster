﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonster.TileEngine
{
    public enum AnimationKey
    {
        IdleLeft,
        IdleRight,
        IdleDown,
        IdleUp,
        WalkLeft,
        WalkRight,
        WalkDown,
        WalkUp,
        ThrowLeft,
        ThrowRight,
        DuckLeft,
        DuckRight,
        JumpLeft,
        JumpRight,
        Dieing,
    }
    public class AnimatedSprite
    {
        Dictionary<AnimationKey, Animation> animations;
        AnimationKey currentAnimation;
        bool isAnimating;

        Texture2D texture;
        public Vector2 Position;
        Vector2 velocity;
        float speed = 200.0f;
        public bool IsActive { get; set; }
        public bool IsAnimating
        {
            get { return isAnimating; }
            set { isAnimating = value; }
        }
        public AnimationKey CurrentAnimation
        {
            get { return currentAnimation; }
            set
            {
                currentAnimation = value;
            }
        }
        public Vector2 Center
        {
            get { return Position + new Vector2(Width / 2, Height / 2); }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = MathHelper.Clamp(speed, 1.0f, 400.0f); }
        }
        public int Width
        {
            get { return animations[currentAnimation].FrameWidth; }
        }
        public int Height
        {
            get { return animations[currentAnimation].FrameHeight; }
        }
        public AnimatedSprite(Texture2D sprite,Dictionary<AnimationKey,Animation> animation)
        {
            texture = sprite;
            animations = new Dictionary<AnimationKey, Animation>();
            foreach(AnimationKey key in animation.Keys)
            {
                animations.Add(key, (Animation)animation[key].Clone());
            }
        }
        public void ResetAnimation()
        {
            animations[currentAnimation].Reset();
        }
        public Vector2 LockToMap(Point mapSize,Vector2 motion)
        {
            Position.X = MathHelper.Clamp(Position.X, 0, mapSize.X - Width);
            Position.Y = MathHelper.Clamp(Position.Y, 0, mapSize.Y - Height);
            if ((Position.X == 0 && motion.X < 0) || (Position.Y == 0 && motion.Y < 0))
                return Vector2.Zero;
            if (Position.X == (mapSize.X-Width) && motion.X>0)
                return Vector2.Zero;
            if (Position.Y == (mapSize.Y - Height) && motion.Y > 0)
                return Vector2.Zero;
            return motion;
        }
        public virtual void Update(GameTime gameTime)
        {
            if (isAnimating)
                animations[currentAnimation].Update(gameTime);
        }
        public virtual void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture, 
                new Rectangle((int)Position.X, (int)Position.Y, Engine.TileWidth, Engine.TileHeight),
                animations[currentAnimation].CurrentFrameRect,
                Color.White
                );
        }
    }
}
