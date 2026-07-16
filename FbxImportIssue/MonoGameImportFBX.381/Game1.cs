using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameImportFBX
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _Model1 = this.Content.Load<Model>("Wood_Calf_R");
            _Model2 = this.Content.Load<Model>("Wood_Foot_R");
            _Model3 = this.Content.Load<Model>("Wood_Pelvis");
            _Model4 = this.Content.Load<Model>("Wood_Roller_R");
        }

        private Model _Model1;
        private Model _Model2;
        private Model _Model3;
        private Model _Model4;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            var viewMatrix = Matrix.CreateLookAt(new Vector3(0, 60, 100),Vector3.Zero,Vector3.Up);
            var projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45),_graphics.GraphicsDevice.Viewport.AspectRatio,0.1f,10000f);

            _Model1.Draw(Matrix.CreateTranslation(-45, 0, 0), viewMatrix, projectionMatrix);
            _Model2.Draw(Matrix.CreateTranslation(-15, 0, 0), viewMatrix, projectionMatrix);
            _Model3.Draw(Matrix.CreateTranslation(+15, 0, 0), viewMatrix, projectionMatrix);
            _Model4.Draw(Matrix.CreateTranslation(+45, 0, 0), viewMatrix, projectionMatrix);

            base.Draw(gameTime);
        }
    }
}
