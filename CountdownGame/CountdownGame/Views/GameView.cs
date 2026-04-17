using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using CountdownGame.Models;
using CountdownGame.Controllers;

namespace CountdownGame.Views
{
    public class GameView
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _pixel;

        public GameView(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = spriteBatch;
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        public void Draw(World world, Player player, List<Enemy> enemies, Camera camera)
        {
            _spriteBatch.Begin(transformMatrix: camera.Transform);

            DrawWalls(world.Walls);
            DrawAttackArea(player);
            DrawPlayer(player);
            DrawEnemies(enemies);

            _spriteBatch.End();
        }

        private void DrawWalls(List<Rectangle> walls)
        {
            foreach (var w in walls)
                _spriteBatch.Draw(_pixel, w, new Color(70, 72, 85));
        }

        private void DrawAttackArea(Player player)
        {
            if (player.IsAttacking)
                _spriteBatch.Draw(_pixel, player.AttackArea, Color.White * 0.1f);
        }

        private void DrawPlayer(Player player)
        {
            _spriteBatch.Draw(_pixel,
                new Rectangle((int)player.Position.X - 16, (int)player.Position.Y - 16, 32, 32),
                player.IsAttacking ? Color.Yellow : Color.Cyan);
        }

        private void DrawEnemies(List<Enemy> enemies)
        {
            foreach (var e in enemies)
                _spriteBatch.Draw(_pixel,
                    new Rectangle((int)e.Position.X - 12, (int)e.Position.Y - 12, 24, 24),
                    e.IsAggro ? Color.OrangeRed : Color.Red);
        }
    }
}