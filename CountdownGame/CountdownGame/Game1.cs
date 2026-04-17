using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CountdownGame.Models;
using CountdownGame.Controllers;
using CountdownGame.Views;

namespace CountdownGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private World _world;
        private Player _player;
        private List<Enemy> _enemies;

        private PlayerController _playerController;
        private EnemyController _enemyController;
        private Camera _camera;
        private GameView _view;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _world = new World();
            _player = new Player(new Vector2(200, 1100));
            _enemies = new List<Enemy>();

            foreach (var pos in _world.GetEnemySpawnPoints())
                _enemies.Add(new Enemy(pos));

            _playerController = new PlayerController(_player);
            _enemyController = new EnemyController();
            _camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _view = new GameView(_spriteBatch, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _playerController.Update(gameTime, _enemies, _world.Walls);
            _enemyController.Update(dt, _player.Position, _enemies, _world.Walls);
            _camera.Update(_player.Position);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(18, 18, 22));
            _view.Draw(_world, _player, _enemies, _camera);
            base.Draw(gameTime);
        }
    }
}