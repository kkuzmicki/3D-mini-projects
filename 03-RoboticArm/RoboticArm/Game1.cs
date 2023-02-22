using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _07_RoboRamie
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        BasicEffect basicEffect;
        Vector3 camPos;
        float angleX = 0.5f, angleY = -0.2f;

        VertexPositionColor[] axisVertexes;

        private Texture2D metal1Texture;
        VertexPositionTexture[] metal1Vertexes;
        float angleMetal1Y = 0.0f, angleMetal1Z = 0.0f;

        private Texture2D metal2Texture;
        VertexPositionTexture[] metal2Vertexes;
        float angleMetal2X = 0.0f, angleMetal2Z = 0.0f;

        private Texture2D metal3Texture;
        VertexPositionTexture[] metal3Vertexes;
        float angleMetal3Up = 0.1f, angleMetal3Down = 0.0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;

            camPos = new Vector3(0, 0, 10);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rs;
            basicEffect = new BasicEffect(GraphicsDevice);
            //basicEffect.VertexColorEnabled = true;
            basicEffect.TextureEnabled = true;

            basicEffect.World = Matrix.Identity;
            basicEffect.View = Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
            basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50), _graphics.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);

            LoadAxis();
            LoadMetal1();
            LoadMetal2();
            LoadMetal3();

            //basicEffect.EnableDefaultLighting();
        }
        protected void LoadAxis()
        {
            axisVertexes = new VertexPositionColor[6];

            axisVertexes[0] = new VertexPositionColor(new Vector3(-6.0f, 0.0f, 0.0f), Color.Red);
            axisVertexes[1] = new VertexPositionColor(new Vector3(6.0f, 0.0f, 0.0f), Color.Red);

            axisVertexes[2] = new VertexPositionColor(new Vector3(0.0f, 6.0f, 0.0f), Color.Green);
            axisVertexes[3] = new VertexPositionColor(new Vector3(0.0f, -6.0f, 0.0f), Color.Green);

            axisVertexes[4] = new VertexPositionColor(new Vector3(0.0f, 0.0f, -6.0f), Color.Blue);
            axisVertexes[5] = new VertexPositionColor(new Vector3(0.0f, 0.0f, 6.0f), Color.Blue);
        }

        protected void LoadMetal1()
        {
            metal1Texture = Content.Load<Texture2D>("metal1");

            metal1Vertexes = new VertexPositionTexture[36];

            // przednia sciana
            metal1Vertexes[0] = new VertexPositionTexture(new Vector3(-3, -1, 1f), new Vector2(0f, 1f));
            metal1Vertexes[1] = new VertexPositionTexture(new Vector3(3, -1, 1f), new Vector2(2f, 1f));
            metal1Vertexes[2] = new VertexPositionTexture(new Vector3(-3, 1, 1f), new Vector2(0f, 0f));

            metal1Vertexes[3] = new VertexPositionTexture(new Vector3(3, 1, 1f), new Vector2(2f, 0f));
            metal1Vertexes[4] = new VertexPositionTexture(new Vector3(-3, 1, 1f), new Vector2(0f, 0f));
            metal1Vertexes[5] = new VertexPositionTexture(new Vector3(3, -1, 1f), new Vector2(2f, 1f));

            // prawa sciana
            metal1Vertexes[6] = new VertexPositionTexture(new Vector3(3, -1, 1f), new Vector2(0f, 1f));
            metal1Vertexes[7] = new VertexPositionTexture(new Vector3(3, -1, -1f), new Vector2(1f, 1f));
            metal1Vertexes[8] = new VertexPositionTexture(new Vector3(3, 1, 1f), new Vector2(0f, 0f));

            metal1Vertexes[9] = new VertexPositionTexture(new Vector3(3, 1, -1f), new Vector2(1f, 0f));
            metal1Vertexes[10] = new VertexPositionTexture(new Vector3(3, 1, 1f), new Vector2(0f, 0f));
            metal1Vertexes[11] = new VertexPositionTexture(new Vector3(3, -1, -1f), new Vector2(1f, 1f));

            // tylna sciana
            metal1Vertexes[12] = new VertexPositionTexture(new Vector3(-3, -1, -1f), new Vector2(0f, 1f));
            metal1Vertexes[13] = new VertexPositionTexture(new Vector3(3, -1, -1f), new Vector2(2f, 1f));
            metal1Vertexes[14] = new VertexPositionTexture(new Vector3(-3, 1, -1f), new Vector2(0f, 0f));

            metal1Vertexes[15] = new VertexPositionTexture(new Vector3(3, 1, -1f), new Vector2(2f, 0f));
            metal1Vertexes[16] = new VertexPositionTexture(new Vector3(-3, 1, -1f), new Vector2(0f, 0f));
            metal1Vertexes[17] = new VertexPositionTexture(new Vector3(3, -1, -1f), new Vector2(2f, 1f));

            // lewa sciana
            metal1Vertexes[18] = new VertexPositionTexture(new Vector3(-3, -1, 1f), new Vector2(0f, 1f));
            metal1Vertexes[19] = new VertexPositionTexture(new Vector3(-3, -1, -1f), new Vector2(1f, 1f));
            metal1Vertexes[20] = new VertexPositionTexture(new Vector3(-3, 1, 1f), new Vector2(0f, 0f));

            metal1Vertexes[21] = new VertexPositionTexture(new Vector3(-3, 1, -1f), new Vector2(1f, 0f));
            metal1Vertexes[22] = new VertexPositionTexture(new Vector3(-3, 1, 1f), new Vector2(0f, 0f));
            metal1Vertexes[23] = new VertexPositionTexture(new Vector3(-3, -1, -1f), new Vector2(1f, 1f));

            // gorna sciana
            metal1Vertexes[24] = new VertexPositionTexture(new Vector3(-3, 1, 1f), new Vector2(0f, 1f));
            metal1Vertexes[25] = new VertexPositionTexture(new Vector3(3, 1, 1f), new Vector2(2f, 1f));
            metal1Vertexes[26] = new VertexPositionTexture(new Vector3(-3, 1, -1f), new Vector2(0f, 0f));

            metal1Vertexes[27] = new VertexPositionTexture(new Vector3(3, 1, -1f), new Vector2(2f, 0f));
            metal1Vertexes[28] = new VertexPositionTexture(new Vector3(3, 1, 1f), new Vector2(2f, 1f));
            metal1Vertexes[29] = new VertexPositionTexture(new Vector3(-3, 1, -1f), new Vector2(0f, 0f));

            // dolna sciana
            metal1Vertexes[30] = new VertexPositionTexture(new Vector3(-3, -1, 1f), new Vector2(0f, 1f));
            metal1Vertexes[31] = new VertexPositionTexture(new Vector3(3, -1, 1f), new Vector2(2f, 1f));
            metal1Vertexes[32] = new VertexPositionTexture(new Vector3(-3, -1, -1f), new Vector2(0f, 0f));

            metal1Vertexes[33] = new VertexPositionTexture(new Vector3(3, -1, -1f), new Vector2(2f, 0f));
            metal1Vertexes[34] = new VertexPositionTexture(new Vector3(3, -1, 1f), new Vector2(2f, 1f));
            metal1Vertexes[35] = new VertexPositionTexture(new Vector3(-3, -1, -1f), new Vector2(0f, 0f));
        }

        protected void LoadMetal2()
        {
            metal2Texture = Content.Load<Texture2D>("metal2");

            metal2Vertexes = new VertexPositionTexture[36];

            // przednia sciana
            metal2Vertexes[0] = new VertexPositionTexture(new Vector3(-5, -0.5f, 0.5f), new Vector2(0f, 1f));
            metal2Vertexes[1] = new VertexPositionTexture(new Vector3(5, -0.5f, 0.5f), new Vector2(4f, 1f));
            metal2Vertexes[2] = new VertexPositionTexture(new Vector3(-5, 0.5f, 0.5f), new Vector2(0f, 0f));

            metal2Vertexes[3] = new VertexPositionTexture(new Vector3(5, 0.5f, 0.5f), new Vector2(4f, 0f));
            metal2Vertexes[4] = new VertexPositionTexture(new Vector3(-5, 0.5f, 0.5f), new Vector2(0f, 0f));
            metal2Vertexes[5] = new VertexPositionTexture(new Vector3(5, -0.5f, 0.5f), new Vector2(4f, 1f));

            // prawa sciana
            metal2Vertexes[6] = new VertexPositionTexture(new Vector3(5, -0.5f, 0.5f), new Vector2(0f, 1f));
            metal2Vertexes[7] = new VertexPositionTexture(new Vector3(5, -0.5f, -0.5f), new Vector2(1f, 1f));
            metal2Vertexes[8] = new VertexPositionTexture(new Vector3(5, 0.5f, 0.5f), new Vector2(0f, 0f));

            metal2Vertexes[9] = new VertexPositionTexture(new Vector3(5, 0.5f, -0.5f), new Vector2(1f, 0f));
            metal2Vertexes[10] = new VertexPositionTexture(new Vector3(5, 0.5f, 0.5f), new Vector2(0f, 0f));
            metal2Vertexes[11] = new VertexPositionTexture(new Vector3(5, -0.5f, -0.5f), new Vector2(1f, 1f));

            // tylna sciana
            metal2Vertexes[12] = new VertexPositionTexture(new Vector3(-5, -0.5f, -0.5f), new Vector2(0f, 1f));
            metal2Vertexes[13] = new VertexPositionTexture(new Vector3(5, -0.5f, -0.5f), new Vector2(4f, 1f));
            metal2Vertexes[14] = new VertexPositionTexture(new Vector3(-5, 0.5f, -0.5f), new Vector2(0f, 0f));

            metal2Vertexes[15] = new VertexPositionTexture(new Vector3(5, 0.5f, -0.5f), new Vector2(4f, 0f));
            metal2Vertexes[16] = new VertexPositionTexture(new Vector3(-5, 0.5f, -0.5f), new Vector2(0f, 0f));
            metal2Vertexes[17] = new VertexPositionTexture(new Vector3(5, -0.5f, -0.5f), new Vector2(4f, 1f));

            // lewa sciana
            metal2Vertexes[18] = new VertexPositionTexture(new Vector3(-5, -0.5f, 0.5f), new Vector2(0f, 1f));
            metal2Vertexes[19] = new VertexPositionTexture(new Vector3(-5, -0.5f, -0.5f), new Vector2(1f, 1f));
            metal2Vertexes[20] = new VertexPositionTexture(new Vector3(-5, 0.5f, 0.5f), new Vector2(0f, 0f));

            metal2Vertexes[21] = new VertexPositionTexture(new Vector3(-5, 0.5f, -0.5f), new Vector2(1f, 0f));
            metal2Vertexes[22] = new VertexPositionTexture(new Vector3(-5, 0.5f, 0.5f), new Vector2(0f, 0f));
            metal2Vertexes[23] = new VertexPositionTexture(new Vector3(-5, -0.5f, -0.5f), new Vector2(1f, 1f));

            // gorna sciana
            metal2Vertexes[24] = new VertexPositionTexture(new Vector3(-5, 0.5f, 0.5f), new Vector2(0f, 1f));
            metal2Vertexes[25] = new VertexPositionTexture(new Vector3(5, 0.5f, 0.5f), new Vector2(4f, 1f));
            metal2Vertexes[26] = new VertexPositionTexture(new Vector3(-5, 0.5f, -0.5f), new Vector2(0f, 0f));

            metal2Vertexes[27] = new VertexPositionTexture(new Vector3(5, 0.5f, -0.5f), new Vector2(4f, 0f));
            metal2Vertexes[28] = new VertexPositionTexture(new Vector3(5, 0.5f, 0.5f), new Vector2(4f, 1f));
            metal2Vertexes[29] = new VertexPositionTexture(new Vector3(-5, 0.5f, -0.5f), new Vector2(0f, 0f));

            // dolna sciana
            metal2Vertexes[30] = new VertexPositionTexture(new Vector3(-5, -0.5f, 0.5f), new Vector2(0f, 1f));
            metal2Vertexes[31] = new VertexPositionTexture(new Vector3(5, -0.5f, 0.5f), new Vector2(4f, 1f));
            metal2Vertexes[32] = new VertexPositionTexture(new Vector3(-5, -0.5f, -0.5f), new Vector2(0f, 0f));

            metal2Vertexes[33] = new VertexPositionTexture(new Vector3(5, -0.5f, -0.5f), new Vector2(4f, 0f));
            metal2Vertexes[34] = new VertexPositionTexture(new Vector3(5, -0.5f, 0.5f), new Vector2(4f, 1f));
            metal2Vertexes[35] = new VertexPositionTexture(new Vector3(-5, -0.5f, -0.5f), new Vector2(0f, 0f));
        }

        protected void LoadMetal3() // szerokosc: 8
        {
            metal3Texture = Content.Load<Texture2D>("metal3");

            metal3Vertexes = new VertexPositionTexture[36];

            // przednia sciana
            metal3Vertexes[0] = new VertexPositionTexture(new Vector3(-4, -0.25f, 0.25f), new Vector2(0f, 1f));
            metal3Vertexes[1] = new VertexPositionTexture(new Vector3(4, -0.25f, 0.25f), new Vector2(4f, 1f));
            metal3Vertexes[2] = new VertexPositionTexture(new Vector3(-4, 0.25f, 0.25f), new Vector2(0f, 0f));

            metal3Vertexes[3] = new VertexPositionTexture(new Vector3(4, 0.25f, 0.25f), new Vector2(4f, 0f));
            metal3Vertexes[4] = new VertexPositionTexture(new Vector3(-4, 0.25f, 0.25f), new Vector2(0f, 0f));
            metal3Vertexes[5] = new VertexPositionTexture(new Vector3(4, -0.25f, 0.25f), new Vector2(4f, 1f));

            // prawa sciana
            metal3Vertexes[6] = new VertexPositionTexture(new Vector3(4, -0.25f, 0.25f), new Vector2(0f, 1f));
            metal3Vertexes[7] = new VertexPositionTexture(new Vector3(4, -0.25f, -0.25f), new Vector2(1f, 1f));
            metal3Vertexes[8] = new VertexPositionTexture(new Vector3(4, 0.25f, 0.25f), new Vector2(0f, 0f));

            metal3Vertexes[9] = new VertexPositionTexture(new Vector3(4, 0.25f, -0.25f), new Vector2(1f, 0f));
            metal3Vertexes[10] = new VertexPositionTexture(new Vector3(4, 0.25f, 0.25f), new Vector2(0f, 0f));
            metal3Vertexes[11] = new VertexPositionTexture(new Vector3(4, -0.25f, -0.25f), new Vector2(1f, 1f));

            // tylna sciana
            metal3Vertexes[12] = new VertexPositionTexture(new Vector3(-4, -0.25f, -0.25f), new Vector2(0f, 1f));
            metal3Vertexes[13] = new VertexPositionTexture(new Vector3(4, -0.25f, -0.25f), new Vector2(4f, 1f));
            metal3Vertexes[14] = new VertexPositionTexture(new Vector3(-4, 0.25f, -0.25f), new Vector2(0f, 0f));

            metal3Vertexes[15] = new VertexPositionTexture(new Vector3(4, 0.25f, -0.25f), new Vector2(4f, 0f));
            metal3Vertexes[16] = new VertexPositionTexture(new Vector3(-4, 0.25f, -0.25f), new Vector2(0f, 0f));
            metal3Vertexes[17] = new VertexPositionTexture(new Vector3(4, -0.25f, -0.25f), new Vector2(4f, 1f));

            // lewa sciana
            metal3Vertexes[18] = new VertexPositionTexture(new Vector3(-4, -0.25f, 0.25f), new Vector2(0f, 1f));
            metal3Vertexes[19] = new VertexPositionTexture(new Vector3(-4, -0.25f, -0.25f), new Vector2(1f, 1f));
            metal3Vertexes[20] = new VertexPositionTexture(new Vector3(-4, 0.25f, 0.25f), new Vector2(0f, 0f));

            metal3Vertexes[21] = new VertexPositionTexture(new Vector3(-4, 0.25f, -0.25f), new Vector2(1f, 0f));
            metal3Vertexes[22] = new VertexPositionTexture(new Vector3(-4, 0.25f, 0.25f), new Vector2(0f, 0f));
            metal3Vertexes[23] = new VertexPositionTexture(new Vector3(-4, -0.25f, -0.25f), new Vector2(1f, 1f));

            // gorna sciana
            metal3Vertexes[24] = new VertexPositionTexture(new Vector3(-4, 0.25f, 0.25f), new Vector2(0f, 1f));
            metal3Vertexes[25] = new VertexPositionTexture(new Vector3(4, 0.25f, 0.25f), new Vector2(4f, 1f));
            metal3Vertexes[26] = new VertexPositionTexture(new Vector3(-4, 0.25f, -0.25f), new Vector2(0f, 0f));

            metal3Vertexes[27] = new VertexPositionTexture(new Vector3(4, 0.25f, -0.25f), new Vector2(4f, 0f));
            metal3Vertexes[28] = new VertexPositionTexture(new Vector3(4, 0.25f, 0.25f), new Vector2(4f, 1f));
            metal3Vertexes[29] = new VertexPositionTexture(new Vector3(-4, 0.25f, -0.25f), new Vector2(0f, 0f));

            // dolna sciana
            metal3Vertexes[30] = new VertexPositionTexture(new Vector3(-4, -0.25f, 0.25f), new Vector2(0f, 1f));
            metal3Vertexes[31] = new VertexPositionTexture(new Vector3(4, -0.25f, 0.25f), new Vector2(4f, 1f));
            metal3Vertexes[32] = new VertexPositionTexture(new Vector3(-4, -0.25f, -0.25f), new Vector2(0f, 0f));

            metal3Vertexes[33] = new VertexPositionTexture(new Vector3(4, -0.25f, -0.25f), new Vector2(4f, 0f));
            metal3Vertexes[34] = new VertexPositionTexture(new Vector3(4, -0.25f, 0.25f), new Vector2(4f, 1f));
            metal3Vertexes[35] = new VertexPositionTexture(new Vector3(-4, -0.25f, -0.25f), new Vector2(0f, 0f));
        }

        protected override void Update(GameTime gameTime)
        {
            CheckKeyboard();

            basicEffect.View = Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
            basicEffect.View = Matrix.CreateRotationY(angleY) * Matrix.CreateRotationX(angleX) * basicEffect.View;

            base.Update(gameTime);
        }

        protected void CheckKeyboard()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            #region camPos
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

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                camPos.Z -= 0.4f;
                if (camPos.Z < 2) camPos.Z = 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                camPos.Z += 0.4f;
                if (camPos.Z > 60) camPos.Z = 60;

            }
            #endregion camPos

            #region metal1
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                angleMetal1Y += .025f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                angleMetal1Y -= .025f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                angleMetal1Z += .025f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                angleMetal1Z -= .025f;
            }
            #endregion metal1

            #region metal2
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                angleMetal2Z += .03f;
                if (angleMetal2Z >= 0.8f)
                {
                    angleMetal2Z = 0.8f;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                angleMetal2Z -= .03f;
                if (angleMetal2Z <= -0.8f)
                {
                    angleMetal2Z = -0.8f;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                angleMetal2X += .05f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                angleMetal2X -= .05f;
            }
            #endregion metal2

            #region metal3

            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                angleMetal3Down += .02f;
                angleMetal3Up -= .02f;
                if (angleMetal3Up <= 0.02f)
                {
                    angleMetal3Up = 0.02f;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                angleMetal3Down -= .02f;
                angleMetal3Up += .02f;
                if (angleMetal3Up >= 0.6f)
                {
                    angleMetal3Up = 0.6f;
                }
            }

            #endregion metal3
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            DrawAxis();
            DrawMetal1();
            DrawMetal2();
            DrawMetal3Up();
            DrawMetal3Down();

            base.Draw(gameTime);
        }

        protected void DrawAxis()
        {
            //basicEffect.LightingEnabled = false;

            basicEffect.World = Matrix.Identity;
            basicEffect.TextureEnabled = false;
            basicEffect.VertexColorEnabled = true;

            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, axisVertexes, 0, 3);

            basicEffect.VertexColorEnabled = false;
            basicEffect.TextureEnabled = true;

            //basicEffect.EnableDefaultLighting();
        }
        protected void DrawMetal1()
        {
            basicEffect.Texture = metal1Texture;
            basicEffect.World = Matrix.CreateTranslation(3, 0, 0) * Matrix.CreateRotationZ(angleMetal1Z) * Matrix.CreateRotationY(angleMetal1Y);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, metal1Vertexes, 0, 12);
        }

        protected void DrawMetal2()
        {
            basicEffect.Texture = metal2Texture;
            basicEffect.World = Matrix.CreateTranslation(5, 0, 0) * Matrix.CreateRotationX(angleMetal2X) * Matrix.CreateRotationZ(angleMetal2Z) * Matrix.CreateTranslation(6, 0, 0) * Matrix.CreateRotationZ(angleMetal1Z) * Matrix.CreateRotationY(angleMetal1Y);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, metal2Vertexes, 0, 12);
        }

        protected void DrawMetal3Up()
        {
            basicEffect.Texture = metal3Texture;
            basicEffect.World = Matrix.CreateTranslation(4, 0, 0) * Matrix.CreateRotationZ(angleMetal3Up) * Matrix.CreateTranslation(10, 0, 0) * Matrix.CreateRotationX(angleMetal2X) * Matrix.CreateRotationZ(angleMetal2Z) * Matrix.CreateTranslation(6, 0, 0) * Matrix.CreateRotationZ(angleMetal1Z) * Matrix.CreateRotationY(angleMetal1Y);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, metal3Vertexes, 0, 12);
        }

        protected void DrawMetal3Down()
        {
            basicEffect.Texture = metal3Texture;
            basicEffect.World = Matrix.CreateTranslation(4, 0, 0) * Matrix.CreateRotationZ(-angleMetal3Up) * Matrix.CreateTranslation(10, 0, 0) * Matrix.CreateRotationX(angleMetal2X) * Matrix.CreateRotationZ(angleMetal2Z) * Matrix.CreateTranslation(6, 0, 0) * Matrix.CreateRotationZ(angleMetal1Z) * Matrix.CreateRotationY(angleMetal1Y);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, metal3Vertexes, 0, 12);
        }
    }
}
