using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;

namespace JumperJumper
{
    public class Camera
    {
        private Game1 game;
        private Viewport viewport;
        public Vector2 CameraPosition = new Vector2(0, 125.0f);
        public Vector2 CenterScreen { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        int valOneAdjust = 200;
        int valTwo = 250;
        int valThreeAdjust = 30;

        public Camera(Viewport viewport, Game1 game)
        {
            this.viewport = viewport;
            this.game = game;
            Zoom = 2.0f;
            CenterScreen = new Vector2(viewport.Width / Zoom, viewport.Height / Zoom);
        }

        //Update trước khi vẽ-> Look at
        public void LookAt(Vector2 position)
        {
            CameraPosition.X = position.X - viewport.Width / Zoom;
            if (CameraPosition.X < ValueHolder.camClamp)
                CameraPosition.X = ValueHolder.camClamp;
        }



        // GetViewMatix để lấy matrix ra-> set vào spriteBatch
        // Matrix Chứa thông tin để SpriteBatch vẽ(các phép biếnh hình, tịnh tiến,....)
        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-CameraPosition, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-CenterScreen, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(CenterScreen, 0.0f));
        }


        // Khi vẽ chỉ cần vẽ những thứ có sẵn trong phần nhìn thấy của camera view-> dùng Incamera View để kiểm tra
        public bool InCameraView(Rectangle obj)
        {
            if (new Rectangle((int)(CameraPosition.X + valOneAdjust), valTwo, ((int)(viewport.Width / Zoom)) +
                valThreeAdjust, (int)(viewport.Height / Zoom)).Intersects(obj))
            {
                return true;
            }
            return false;
        }
    }
}
