using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _06_Domek
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        BasicEffect basicEffect;
        VertexPositionTexture[] grassVertexes;
        Vector3[] frontFace;

        VertexPositionTexture[] wallsVertexes;
        Texture2D wallsTexture;

        VertexPositionTexture[] roofVertexes;
        Texture2D roofTexture;

        VertexPositionColor[] axisVertexes;

        Vector3 camPos;
        float angleX = 0.5f, angleY = -0.2f;

        Texture2D grassTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            camPos = new Vector3(0f, 0f, 5f);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;

            basicEffect = new BasicEffect(GraphicsDevice);
            //basicEffect.VertexColorEnabled = true;
            basicEffect.TextureEnabled = true;

            basicEffect.World = Matrix.Identity;
            basicEffect.View = Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
            basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50), graphics.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);

            LoadGrass();
            LoadWalls();
            LoadAxis();
            LoadRoof();
        }

        protected void LoadRoof()
        {
            roofTexture = Content.Load<Texture2D>("roofing1");

            roofVertexes = new VertexPositionTexture[18];

            // przedni dach
            roofVertexes[0] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(0.0f, 2.0f));
            roofVertexes[1] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(2.0f, 2.0f));
            roofVertexes[2] = new VertexPositionTexture(new Vector3(-1, 1.5f, 0f), new Vector2(0.0f, 0.0f));

            roofVertexes[3] = new VertexPositionTexture(new Vector3(-1, 1.5f, 0.0f), new Vector2(0.0f, 0.0f));
            roofVertexes[4] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(2.0f, 2.0f));
            roofVertexes[5] = new VertexPositionTexture(new Vector3(1, 1.5f, 0f), new Vector2(2.0f, 0.0f));

            // tylny dach
            roofVertexes[6] = new VertexPositionTexture(new Vector3(-1, 1, -0.5f), new Vector2(2.0f, 2.0f));
            roofVertexes[7] = new VertexPositionTexture(new Vector3(1, 1, -0.5f), new Vector2(0.0f, 2.0f));
            roofVertexes[8] = new VertexPositionTexture(new Vector3(-1, 1.5f, 0f), new Vector2(2.0f, 0.0f));

            roofVertexes[9] = new VertexPositionTexture(new Vector3(-1, 1.5f, 0.0f), new Vector2(2.0f, 0.0f));
            roofVertexes[10] = new VertexPositionTexture(new Vector3(1, 1.5f, 0.0f), new Vector2(0.0f, 0.0f));
            roofVertexes[11] = new VertexPositionTexture(new Vector3(1, 1f, -0.5f), new Vector2(0.0f, 2.0f));

            // lewy dach
            roofVertexes[12] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(2.0f, 2.0f));
            roofVertexes[13] = new VertexPositionTexture(new Vector3(-1, 1.5f, 0.0f), new Vector2(1, 0.0f));
            roofVertexes[14] = new VertexPositionTexture(new Vector3(-1, 1, -0.5f), new Vector2(0.0f, 2.0f));

            // prawy dach
            roofVertexes[15] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(0.0f, 2.0f));
            roofVertexes[16] = new VertexPositionTexture(new Vector3(1, 1, -0.5f), new Vector2(2.0f, 2.0f));
            roofVertexes[17] = new VertexPositionTexture(new Vector3(1, 1.5f, 0f), new Vector2(1f, 0.0f));
        }

        protected void LoadAxis()
        {
            axisVertexes = new VertexPositionColor[6];

            axisVertexes[0] = new VertexPositionColor(new Vector3(-3.0f, 0.0f, 0.0f), Color.Red);
            axisVertexes[1] = new VertexPositionColor(new Vector3(3.0f, 0.0f, 0.0f), Color.Red);

            axisVertexes[2] = new VertexPositionColor(new Vector3(0.0f, 3.0f, 0.0f), Color.Green);
            axisVertexes[3] = new VertexPositionColor(new Vector3(0.0f, -3.0f, 0.0f), Color.Green);

            axisVertexes[4] = new VertexPositionColor(new Vector3(0.0f, 0.0f, -3.0f), Color.Blue);
            axisVertexes[5] = new VertexPositionColor(new Vector3(0.0f, 0.0f, 3.0f), Color.Blue);
        }

        protected void LoadWalls()
        {
            wallsTexture = Content.Load<Texture2D>("wall1");

            wallsVertexes = new VertexPositionTexture[24];

            // przednia sciana
            wallsVertexes[0] = new VertexPositionTexture(new Vector3(-1, 0, 0.5f), new Vector2(0f, 1f));
            wallsVertexes[1] = new VertexPositionTexture(new Vector3(1, 0, 0.5f), new Vector2(2f, 1f));
            wallsVertexes[2] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(0f, 0f));

            wallsVertexes[3] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(2f, 0f));
            wallsVertexes[4] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(0f, 0f));
            wallsVertexes[5] = new VertexPositionTexture(new Vector3(1, 0, 0.5f), new Vector2(2f, 1f));

            // prawa sciana
            wallsVertexes[6] = new VertexPositionTexture(new Vector3(1, 0, 0.5f), new Vector2(0f, 1f));
            wallsVertexes[7] = new VertexPositionTexture(new Vector3(1, 0, -0.5f), new Vector2(1f, 1f));
            wallsVertexes[8] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(0f, 0f));

            wallsVertexes[9] = new VertexPositionTexture(new Vector3(1, 1, -0.5f), new Vector2(1f, 0f));
            wallsVertexes[10] = new VertexPositionTexture(new Vector3(1, 1, 0.5f), new Vector2(0f, 0f));
            wallsVertexes[11] = new VertexPositionTexture(new Vector3(1, 0, -0.5f), new Vector2(1f, 1f));

            // tylna sciana
            wallsVertexes[12] = new VertexPositionTexture(new Vector3(-1, 0, -0.5f), new Vector2(0f, 1f));
            wallsVertexes[13] = new VertexPositionTexture(new Vector3(1, 0, -0.5f), new Vector2(2f, 1f));
            wallsVertexes[14] = new VertexPositionTexture(new Vector3(-1, 1, -0.5f), new Vector2(0f, 0f));

            wallsVertexes[15] = new VertexPositionTexture(new Vector3(1, 1, -0.5f), new Vector2(2f, 0f));
            wallsVertexes[16] = new VertexPositionTexture(new Vector3(-1, 1, -0.5f), new Vector2(0f, 0f));
            wallsVertexes[17] = new VertexPositionTexture(new Vector3(1, 0, -0.5f), new Vector2(2f, 1f));

            // lewa sciana
            wallsVertexes[18] = new VertexPositionTexture(new Vector3(-1, 0, 0.5f), new Vector2(0f, 1f));
            wallsVertexes[19] = new VertexPositionTexture(new Vector3(-1, 0, -0.5f), new Vector2(1f, 1f));
            wallsVertexes[20] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(0f, 0f));

            wallsVertexes[21] = new VertexPositionTexture(new Vector3(-1, 1, -0.5f), new Vector2(1f, 0f));
            wallsVertexes[22] = new VertexPositionTexture(new Vector3(-1, 1, 0.5f), new Vector2(0f, 0f));
            wallsVertexes[23] = new VertexPositionTexture(new Vector3(-1, 0, -0.5f), new Vector2(1f, 1f));
        }

        protected void LoadGrass()
        {
            grassTexture = Content.Load<Texture2D>("grass1");

            frontFace = new Vector3[6];

            frontFace[0] = new Vector3(-5, 0, -5);
            frontFace[1] = new Vector3(-5, 0, 5);
            frontFace[2] = new Vector3(5, 0, 5);
            frontFace[3] = new Vector3(5, 0, -5);
            frontFace[4] = new Vector3(-5, 0, -5);
            frontFace[5] = new Vector3(5, 0, 5);

            grassVertexes = new VertexPositionTexture[6];

            grassVertexes[0] = new VertexPositionTexture(frontFace[0], new Vector2(0.0f, 0.0f));
            grassVertexes[1] = new VertexPositionTexture(frontFace[1], new Vector2(0.0f, 1.0f));
            grassVertexes[2] = new VertexPositionTexture(frontFace[2], new Vector2(1.0f, 1.0f));
            grassVertexes[3] = new VertexPositionTexture(frontFace[3], new Vector2(1.0f, 0.0f));
            grassVertexes[4] = new VertexPositionTexture(frontFace[4], new Vector2(0.0f, 0.0f));
            grassVertexes[5] = new VertexPositionTexture(frontFace[5], new Vector2(1.0f, 1.0f));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                angleY += 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                angleY -= 0.02f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                angleX -= 0.02f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                angleX += 0.02f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                camPos.Z -= 0.05f;
                if (camPos.Z < 2) camPos.Z = 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                camPos.Z += 0.05f;
                if (camPos.Z > 10) camPos.Z = 10;

            }

            basicEffect.View = Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
            basicEffect.View = Matrix.CreateRotationY(angleY) * Matrix.CreateRotationX(angleX) * basicEffect.View;

            //Matrix transform = Matrix.CreateScale(scale) * Matrix.CreateRotationZ(rot);
            //for(int i = 0; i < frontFace.Length; i++)
            //{
            // grassVertexes[i].Position = Vector3.Transform(frontFace[i], transform);
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawGrass();
            DrawAxis();
            DrawWalls();
            DrawRoof();

            base.Draw(gameTime);
        }

        protected void DrawRoof()
        {
            basicEffect.Texture = roofTexture;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, roofVertexes, 0, 6);
        }

        protected void DrawAxis()
        {
            basicEffect.TextureEnabled = false;
            basicEffect.VertexColorEnabled = true;

            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, axisVertexes, 0, 3);

            basicEffect.VertexColorEnabled = false;
            basicEffect.TextureEnabled = true;
        }

        protected void DrawWalls()
        {
            basicEffect.Texture = wallsTexture;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, wallsVertexes, 0, 8);
        }

        protected void DrawGrass()
        {
            basicEffect.Texture = grassTexture;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, grassVertexes, 0, 2);
        }
    }
}