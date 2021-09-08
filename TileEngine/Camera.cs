using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace ShadowMonster.TileEngine
{
    public class Camera
    {
        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        float speed;
        public float Speed
        {
            get { return speed; }
            set { speed = (float)MathHelper.Clamp(speed, 1f, 16f); }
        }
        public Matrix Transformation
        {
            get { return Matrix.CreateTranslation(new Vector3(-Position,0f)); }
        }
        public Camera()
        {
            speed = 4f;
        }
        public Camera(Vector2 position)
        {
            speed = 4f;
            Position = position;
        }
        public void LockCamera(TileMap map,Rectangle viewPort)
        {
            position.X = MathHelper.Clamp(position.X, 0, map.WidthInPixels - viewPort.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, map.HeightInPixels - viewPort.Height);
        }
        public void LockToSprite(TileMap map,AnimatedSprite sprite,Rectangle viewPort)
        {
            position.X = (sprite.Position.X + sprite.Width) - (viewPort.Width / 2);
            position.Y = (sprite.Position.Y + sprite.Height) - (viewPort.Height / 2);
            LockCamera(map, viewPort);
        }
    }
}
