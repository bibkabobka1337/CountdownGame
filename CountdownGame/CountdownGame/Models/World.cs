using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CountdownGame.Models
{
    public class World
    {
        public List<Rectangle> Walls { get; private set; }
        public const int T = 40;

        public World()
        {
            Walls = new List<Rectangle>();
            CreateMap();
        }

        private void CreateMap()
        {
            Walls.Clear();

            //  ПЕРВЫЙ КОРИДОР (Вверх)
            for (int y = 200; y <= 1200; y += T) Walls.Add(new Rectangle(80, y, T, T));
            for (int y = 440; y <= 1200; y += T) Walls.Add(new Rectangle(320, y, T, T));
            for (int x = 80; x <= 320; x += T) Walls.Add(new Rectangle(x, 1200, T, T));

            Walls.Add(new Rectangle(200, 840, T, T));
            Walls.Add(new Rectangle(120, 600, T, T));
            Walls.Add(new Rectangle(280, 600, T, T));

            // ВТОРОЙ КОРИДОР (Вправо)
            for (int x = 80; x <= 1360; x += T)
            {
                if (x >= 600 && x <= 800) continue;
                Walls.Add(new Rectangle(x, 200, T, T));
            }
            for (int x = 320; x <= 1600; x += T)
            {
                if (x >= 1000 && x <= 1200) continue;
                Walls.Add(new Rectangle(x, 440, T, T));
            }

            Walls.Add(new Rectangle(440, 320, T, T));
            Walls.Add(new Rectangle(880, 240, T, T * 2));
            Walls.Add(new Rectangle(1280, 360, T, T));

            // КОМНАТА 1
            for (int y = -80; y <= 160; y += T)
            {
                Walls.Add(new Rectangle(560, y, T, T));
                Walls.Add(new Rectangle(840, y, T, T));
            }
            for (int x = 560; x <= 840; x += T)
                Walls.Add(new Rectangle(x, -80, T, T));

            Walls.Add(new Rectangle(640, 40, T * 2, T));
            Walls.Add(new Rectangle(760, 120, T, T));

            // КОМНАТА 2
            for (int y = 480; y <= 720; y += T)
            {
                Walls.Add(new Rectangle(960, y, T, T));
                Walls.Add(new Rectangle(1240, y, T, T));
            }
            for (int x = 960; x <= 1240; x += T)
                Walls.Add(new Rectangle(x, 720, T, T));

            Walls.Add(new Rectangle(1040, 560, T, T * 2));
            Walls.Add(new Rectangle(1160, 520, T, T));

            // ТРЕТИЙ КОРИДОР (Вверх)
            for (int y = -400; y <= 200; y += T)
                Walls.Add(new Rectangle(1360, y, T, T));
            for (int y = -400; y <= 440; y += T)
                Walls.Add(new Rectangle(1600, y, T, T));
            for (int x = 1360; x <= 1600; x += T)
                Walls.Add(new Rectangle(x, -400, T, T));

            Walls.Add(new Rectangle(1440, 40, T, T));
            Walls.Add(new Rectangle(1520, -120, T, T));
            Walls.Add(new Rectangle(1440, -280, T, T));
        }

        public List<Vector2> GetEnemySpawnPoints()
        {
            return new List<Vector2>
            {
                new Vector2(200, 700),
                new Vector2(520, 320),
                new Vector2(700, 0),
                new Vector2(1050, 320),
                new Vector2(1100, 640),
                new Vector2(1480, 200),
                new Vector2(1480, -200)
            };
        }
    }
}