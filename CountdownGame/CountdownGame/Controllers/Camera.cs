using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CountdownGame.Controllers
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        private readonly Viewport _vp;

        public Camera(Viewport vp)
        {
            _vp = vp;
        }

        public void Update(Vector2 playerPos)
        {
            Transform = Matrix.CreateTranslation(
                -playerPos.X + _vp.Width / 2,
                -playerPos.Y + _vp.Height / 2, 0);
        }
    }
}