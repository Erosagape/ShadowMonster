using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ShadowMonster.TileEngine
{
    public class Animation : ICloneable
    {
        Rectangle[] frames;
        int framesPerSecond;
        public int FramesPerSecond
        {
            get { return framesPerSecond; }
            set
            {
                if (value < 1)
                    framesPerSecond = 1;
                else if (value > 60)
                    framesPerSecond = 60;
                else
                    framesPerSecond = value;
                frameLength = TimeSpan.FromSeconds(1 / (double)framesPerSecond);
            }
        }
        TimeSpan frameLength;
        TimeSpan frameTimer;
        int currentFrame;
        public int CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = (int)MathHelper.Clamp(value, 0, frames.Length - 1);
            }
        }
        int frameWidth;
        public int FrameWidth
        {
            get { return frameWidth; }            
        }
        public int FrameHeight
        {
            get { return frameHeight; }
        }
        int frameHeight;
        public Rectangle CurrentFrameRect
        {
            get { return frames[currentFrame]; }
        }
        public Animation(int frameCount,int frameWidth,int frameHeight,int xOffset,int yOffset)
        {
            frames = new Rectangle[frameCount];
            this.frameWidth = frameWidth;
            this.frameHeight = FrameHeight;
            for(int i=0;i< frameCount; i++)
            {
                frames[i] = new Rectangle(
                    xOffset+(frameWidth*i),
                    yOffset,
                    frameWidth,
                    frameHeight
                    );
            }
            FramesPerSecond = 5;
            Reset();
        }
        private Animation(Animation animation)
        {
            this.frames = animation.frames;
            framesPerSecond = 5;
        }
        public void Reset()
        {
            currentFrame = 0;
            frameTimer = TimeSpan.Zero;
        }
        public void Update(GameTime gameTime)
        {
            frameTimer += gameTime.ElapsedGameTime;
            if (frameTimer >= frameLength)
            {
                frameTimer = TimeSpan.Zero;
                currentFrame = (currentFrame + 1) % frames.Length;
            }
        }
        public object Clone()
        {
            Animation anim = new Animation(this);
            anim.frameWidth = this.frameWidth;
            anim.frameHeight = this.FrameHeight;
            anim.Reset();
            return anim;
        }
    }
}
