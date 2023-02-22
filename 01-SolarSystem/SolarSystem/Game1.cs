using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace _05_UkladSloneczny
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;
        private Texture2D backgroundTexture;
        private bool isBackgroundVisible = true;
        private bool wasBDown = true;

        private BasicEffect basicEffect;
        private Vector3 camPos;
        private readonly float camSpeed = 0.02f;
        private float angleY = 0.2f, angleX = 0.0f;

        private VertexPositionColor[] gridVertexes;
        private bool isGridVisible = true;
        private bool wasXDown = true;

        private VertexPositionColor[] SunVertexes;
        private float SunAngle = 0;

        private VertexPositionColor[] MercuryVertexes;
        private float MercuryAngle = 0;

        private VertexPositionColor[] VenusVertexes;
        private float VenusAngle = 0;

        private VertexPositionColor[] EarthVertexes;
        private float EarthAngle = 0;

        private VertexPositionColor[] MarsVertexes;
        private float MarsAngle = 0;

        private VertexPositionColor[] MoonVertexes;
        private float MoonAngle = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
         
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadBackground();

            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.World = Matrix.Identity;
            camPos = new Vector3(0.0f, 30.0f, 30f);
            basicEffect.View = Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
            basicEffect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50), graphics.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);
            basicEffect.VertexColorEnabled = true;

            LoadGrid();
            LoadSun();
            LoadMercury();
            LoadVenus();
            LoadEarth();
            LoadMars();
            LoadMoon();
        }

        protected void LoadMoon()
        {
            MoonVertexes = new VertexPositionColor[36];

            MoonVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.LightGray);
            MoonVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightGray);
            MoonVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.LightGray);

            MoonVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Gray);
            MoonVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Gray);
            MoonVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Gray);

            MoonVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.LightGray);
            MoonVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.LightGray);
            MoonVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.LightGray);

            MoonVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Gray);
            MoonVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Gray);
            MoonVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Gray);

            MoonVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.LightGray);
            MoonVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.LightGray);
            MoonVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.LightGray);

            MoonVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Gray);
            MoonVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Gray);
            MoonVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Gray);

            MoonVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.LightGray);
            MoonVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.LightGray);
            MoonVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.LightGray);

            MoonVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Gray);
            MoonVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Gray);
            MoonVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Gray);

            MoonVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightGray);
            MoonVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.LightGray);
            MoonVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.LightGray);

            MoonVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Gray);
            MoonVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Gray);
            MoonVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Gray);

            MoonVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.LightGray);
            MoonVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.LightGray);
            MoonVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.LightGray);

            MoonVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Gray);
            MoonVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Gray);
            MoonVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Gray);
        }

        protected void LoadMars()
        {
            MarsVertexes = new VertexPositionColor[36];

            MarsVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);
            MarsVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            MarsVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);

            MarsVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
            MarsVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
            MarsVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Red);

            MarsVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            MarsVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);
            MarsVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);

            MarsVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);
            MarsVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Red);
            MarsVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Red);

            MarsVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            MarsVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Orange);
            MarsVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);

            MarsVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Red);
            MarsVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
            MarsVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Red);

            MarsVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);
            MarsVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            MarsVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            MarsVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
            MarsVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red);
            MarsVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Red);

            MarsVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            MarsVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            MarsVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);

            MarsVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Red);
            MarsVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Red);
            MarsVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Red);

            MarsVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            MarsVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            MarsVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            MarsVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Red);
            MarsVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Red);
            MarsVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Red);
        }

        protected void LoadEarth()
        {
            EarthVertexes = new VertexPositionColor[36];

            EarthVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Blue);
            EarthVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            EarthVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);

            EarthVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);
            EarthVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);
            EarthVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Green);

            EarthVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);
            EarthVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);
            EarthVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);

            EarthVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);
            EarthVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
            EarthVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);

            EarthVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            EarthVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Blue);
            EarthVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Blue);

            EarthVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
            EarthVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            EarthVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Green);

            EarthVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Blue);
            EarthVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);
            EarthVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Blue);

            EarthVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            EarthVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Green);
            EarthVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Green);

            EarthVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue);
            EarthVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Blue);
            EarthVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Blue);

            EarthVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Green);
            EarthVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Green);
            EarthVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Green);

            EarthVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Blue);
            EarthVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Blue);
            EarthVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Blue);

            EarthVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Green);
            EarthVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Green);
            EarthVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Green);
        }

        protected void LoadVenus()
        {
            VenusVertexes = new VertexPositionColor[36];

            VenusVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);
            VenusVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            VenusVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);

            VenusVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Brown);
            VenusVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Brown);
            VenusVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Brown);

            VenusVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            VenusVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);
            VenusVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);

            VenusVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Brown);
            VenusVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Brown);
            VenusVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Brown);

            VenusVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            VenusVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Orange);
            VenusVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);

            VenusVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Brown);
            VenusVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Brown);
            VenusVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Brown);

            VenusVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);
            VenusVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            VenusVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            VenusVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Brown);
            VenusVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Brown);
            VenusVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Brown);

            VenusVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            VenusVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            VenusVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);

            VenusVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Brown);
            VenusVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Brown);
            VenusVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Brown);

            VenusVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            VenusVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            VenusVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            VenusVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Brown);
            VenusVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Brown);
            VenusVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Brown);
        }

        protected void LoadMercury()
        {
            MercuryVertexes = new VertexPositionColor[36];

            MercuryVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);
            MercuryVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.White);
            MercuryVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);

            MercuryVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.DarkGray);
            MercuryVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.DarkGray);
            MercuryVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.DarkGray);

            MercuryVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);
            MercuryVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.White);
            MercuryVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.White);

            MercuryVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.DarkGray);
            MercuryVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.DarkGray);
            MercuryVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.DarkGray);

            MercuryVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.White);
            MercuryVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.White);
            MercuryVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.White);

            MercuryVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.DarkGray);
            MercuryVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.DarkGray);
            MercuryVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.DarkGray);

            MercuryVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.White);
            MercuryVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.White);
            MercuryVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);

            MercuryVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.DarkGray);
            MercuryVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.DarkGray);
            MercuryVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.DarkGray);

            MercuryVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.White);
            MercuryVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.White);
            MercuryVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.White);

            MercuryVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.DarkGray);
            MercuryVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.DarkGray);
            MercuryVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.DarkGray);

            MercuryVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.White);
            MercuryVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.White);
            MercuryVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.White);

            MercuryVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.DarkGray);
            MercuryVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.DarkGray);
            MercuryVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.DarkGray);
        }

        protected void LoadSun()
        {
            SunVertexes = new VertexPositionColor[36];

            SunVertexes[0] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);
            SunVertexes[1] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            SunVertexes[2] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);

            SunVertexes[3] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Yellow);
            SunVertexes[4] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Yellow);
            SunVertexes[5] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Yellow);

            SunVertexes[6] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            SunVertexes[7] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);
            SunVertexes[8] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);

            SunVertexes[9] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Yellow);
            SunVertexes[10] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Yellow);
            SunVertexes[11] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Yellow);

            SunVertexes[12] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            SunVertexes[13] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Orange);
            SunVertexes[14] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);

            SunVertexes[15] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Yellow);
            SunVertexes[16] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);
            SunVertexes[17] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);

            SunVertexes[18] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Orange);
            SunVertexes[19] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            SunVertexes[20] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            SunVertexes[21] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);
            SunVertexes[22] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Yellow);
            SunVertexes[23] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Yellow);

            SunVertexes[24] = new VertexPositionColor(new Vector3(-1, 1, 1), Color.Orange);
            SunVertexes[25] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Orange);
            SunVertexes[26] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Orange);

            SunVertexes[27] = new VertexPositionColor(new Vector3(-1, 1, -1), Color.Yellow);
            SunVertexes[28] = new VertexPositionColor(new Vector3(1, 1, -1), Color.Yellow);
            SunVertexes[29] = new VertexPositionColor(new Vector3(1, 1, 1), Color.Yellow);

            SunVertexes[30] = new VertexPositionColor(new Vector3(1, -1, 1), Color.Orange);
            SunVertexes[31] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Orange);
            SunVertexes[32] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Orange);

            SunVertexes[33] = new VertexPositionColor(new Vector3(1, -1, -1), Color.Yellow);
            SunVertexes[34] = new VertexPositionColor(new Vector3(-1, -1, -1), Color.Yellow);
            SunVertexes[35] = new VertexPositionColor(new Vector3(-1, -1, 1), Color.Yellow);
        }

        protected void LoadBackground()
        {
            backgroundTexture = Content.Load<Texture2D>("stars");
        }

        protected void LoadGrid()
        {
            gridVertexes = new VertexPositionColor[164];

            int tmp = -20;
            for(int i = 0; i < 82; i += 2)
            {
                gridVertexes[i] = new VertexPositionColor(new Vector3(tmp, 0, -20), Color.White);
                gridVertexes[i + 1] = new VertexPositionColor(new Vector3(tmp++, 0, 20), Color.White);
            }

            tmp = -20;
            for(int i = 82; i < 164; i += 2)
            {
                gridVertexes[i] = new VertexPositionColor(new Vector3(-20, 0, tmp), Color.White);
                gridVertexes[i + 1] = new VertexPositionColor(new Vector3(20, 0, tmp++), Color.White);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            CheckKeyboard();

            UpdateCamera();

            base.Update(gameTime);
        }

        protected void UpdateCamera()
        {
            basicEffect.View = Matrix.CreateRotationY(angleY) * Matrix.CreateRotationX(angleX) * Matrix.CreateLookAt(camPos, Vector3.Zero, Vector3.Up);
        }

        protected void CheckKeyboard()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            // ukrycie tla
            if(Keyboard.GetState().IsKeyDown(Keys.B) && wasBDown)
            {
                isBackgroundVisible = !isBackgroundVisible;
                wasBDown = false;
            }
            if(!Keyboard.GetState().IsKeyDown(Keys.B))
            {
                wasBDown = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X) && wasXDown)
            {
                isGridVisible = !isGridVisible;
                wasXDown = false;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.X))
            {
                wasXDown = true;
            }

            // rotacja kamery
            if (!Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                angleY -= camSpeed;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                angleY += camSpeed;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                angleX -= camSpeed;
            }
            if (!Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                angleX += camSpeed;
            }

            // odleglosc kamery
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                camPos.Z -= 0.25f;
                camPos.Y -= 0.25f;
                Trace.WriteLine(camPos.ToString());
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                camPos.Z += 0.25f;
                camPos.Y += 0.25f;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // 2D

            spriteBatch.Begin();
            DrawBackground();
            spriteBatch.End();

            // 3D

            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            DrawGrid();

            DrawSun();
            DrawMercury();
            DrawVenus();
            DrawEarth();
            DrawMars();
            DrawMoon();

            base.Draw(gameTime);
        }

        protected void DrawMoon()
        {
            MoonAngle += .1f;
            // obrot wokol wlasnej osi * przesuniecie od Ziemi * orbitowanie dookola Ziemi * przesuniecie od Slonca * orbitowanie dookola Slonca
            basicEffect.World = Matrix.CreateScale(0.35f) * Matrix.CreateRotationY(MoonAngle) 
                * Matrix.CreateTranslation(new Vector3(2f, 0f, 0f)) * Matrix.CreateRotationY(MoonAngle)
                * Matrix.CreateTranslation(new Vector3(15f, 0, 0)) * Matrix.CreateRotationY(EarthAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, MoonVertexes, 0, 12);
        }

        protected void DrawMars()
        {
            MarsAngle += .015f;
            // obrot wokol wlasnej osi * przesuniecie * orbitowanie
            basicEffect.World = Matrix.CreateScale(0.65f) * Matrix.CreateRotationY(-3 * MarsAngle) * Matrix.CreateTranslation(new Vector3(19f, 0f, 0f)) * Matrix.CreateRotationY(MarsAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, MarsVertexes, 0, 12);
        }

        protected void DrawEarth()
        {
            EarthAngle += .02f;
            // obrot wokol wlasnej osi * przesuniecie * orbitowanie
            basicEffect.World = Matrix.CreateScale(0.75f) * Matrix.CreateRotationY(-2 * EarthAngle) * Matrix.CreateTranslation(new Vector3(15f, 0f, 0f)) * Matrix.CreateRotationY(EarthAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, EarthVertexes, 0, 12);
        }

        protected void DrawVenus()
        {
            VenusAngle += .02f;
            // obrot wokol wlasnej osi * przesuniecie * orbitowanie
            basicEffect.World = Matrix.CreateScale(0.65f) * Matrix.CreateRotationY(-3 * VenusAngle) * Matrix.CreateTranslation(new Vector3(10f, 0f, 0f)) * Matrix.CreateRotationY(VenusAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, VenusVertexes, 0, 12);
        }

        protected void DrawMercury()
        {
            MercuryAngle += .01f;
            // obrot wokol wlasnej osi * przesuniecie * orbitowanie
            basicEffect.World = Matrix.CreateScale(0.5f) * Matrix.CreateRotationY(-3 * MercuryAngle) * Matrix.CreateTranslation(new Vector3(5f, 0f, 0f)) * Matrix.CreateRotationY(MercuryAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, MercuryVertexes, 0, 12);
        }

        protected void DrawSun()
        {
            SunAngle += .6f;
            basicEffect.World = Matrix.Identity * Matrix.CreateRotationY(SunAngle) * Matrix.CreateRotationZ(SunAngle);
            basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, SunVertexes, 0, 12);
        }

        protected void DrawGrid()
        {
            basicEffect.World = Matrix.Identity;
            basicEffect.CurrentTechnique.Passes[0].Apply();
            if(isGridVisible) GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, gridVertexes, 0, 82);
        }

        protected void DrawBackground()
        {
            if (isBackgroundVisible) spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
        }
    }
}
