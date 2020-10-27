using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Tests.Components;
using System;

namespace RgbCube
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        //BasicEffect effect;
        //VertexPositionNormalTexture[] cube;
        //float rotationY = 0f;
        //float rotationX = 0.4f;

        //BasicEffect basicEffect;
        //Matrix worldMatrix, viewMatrix, projectionMatrix;

        Colored3DCubeComponent cube;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            //effect = new BasicEffect(graphics.GraphicsDevice);
            //effect.AmbientLightColor = Vector3.One;
            //effect.DirectionalLight0.Enabled = true;
            //effect.DirectionalLight0.DiffuseColor = Vector3.One;
            //effect.DirectionalLight0.Direction = Vector3.Normalize(Vector3.One);
            //effect.AmbientLightColor = new Vector3(0.0f, 1.0f, 1.0f);
            //effect.LightingEnabled = true;

            //Matrix projection = Matrix.CreatePerspectiveFieldOfView(
            //    (float)Math.PI / 4.0f,
            //    (float)Window.ClientBounds.Width /
            //    (float)Window.ClientBounds.Height,
            //    1f,
            //    10f);
            //effect.Projection = projection;
            //Matrix V = Matrix.CreateTranslation(0f, 0f, -11f);
            //effect.View = V;

            cube = new Colored3DCubeComponent(graphics.GraphicsDevice);
            cube.LoadContent();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            //cube = MakeCube();

            // setup our graphics scene matrices
            //worldMatrix = Matrix.Identity;
            //viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            //projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, graphics.GraphicsDevice.Viewport.AspectRatio, 1, 10);

            //worldMatrix *= Matrix.CreateRotationX(-0.05f * 30f);
            //worldMatrix *= Matrix.CreateRotationY(-0.05f * 20f);
            //worldMatrix *= Matrix.CreateTranslation(Vector3.Zero);

            //// Setup our basic effect
            //basicEffect = new BasicEffect(graphics.GraphicsDevice);
            //basicEffect.World = worldMatrix;
            //basicEffect.View = viewMatrix;
            //basicEffect.Projection = projectionMatrix;
            //basicEffect.VertexColorEnabled = true;

            //CreateCubeVertexBuffer();
            //CreateCubeIndexBuffer();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //// TODO: Add your update logic here
            //if (Keyboard.GetState().IsKeyDown(Keys.D))
            //{
            //    rotationY += 0.008f;
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.A))
            //{
            //    rotationY -= 0.008f;
            //}
            //if (rotationY > 2 * Math.PI)
            //{
            //    rotationY = 0f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.W))
            //{
            //    rotationX += 0.008f;
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.S))
            //{
            //    rotationX -= 0.008f;
            //}
            //if (rotationX > 2 * Math.PI)
            //{
            //    rotationX = 0f;
            //}
            //Matrix R = Matrix.CreateRotationY(rotationY) * Matrix.CreateRotationX(rotationX);
            //Matrix T = Matrix.CreateTranslation(0.0f, 0f, 5f);
            //effect.World = R * T;

            cube.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.CullClockwiseFace;
            //graphics.GraphicsDevice.RasterizerState = rs;

            //foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();
            //    graphics.GraphicsDevice.DrawUserPrimitives<VertexPositionNormalTexture>(PrimitiveType.TriangleList, cube, 0, 12);
            //}


            //graphics.GraphicsDevice.SetVertexBuffer(vertices);
            //graphics.GraphicsDevice.Indices = indices;

            //basicEffect.World = worldMatrix;
            //foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();

            //    graphics.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, number_of_vertices, 0, number_of_indices / 3);

            //}

            cube.Draw();

            base.Draw(gameTime);
        }

        ///// <summary>
        ///// https://www.i-programmer.info/projects/119-graphics-and-games/1108-getting-started-with-3d-xna.html?start=1
        ///// </summary>
        ///// <returns></returns>
        //protected VertexPositionNormalTexture[] MakeCube()
        //{
        //    VertexPositionNormalTexture[] vertices = new VertexPositionNormalTexture[36];
        //    Vector2 Texcoords = new Vector2(0f, 0f);

        //    Vector3[] face = new Vector3[6];
        //    //TopLeft
        //    face[0] = new Vector3(-1f, 1f, 0.0f);
        //    //BottomLeft
        //    face[1] = new Vector3(-1f, -1f, 0.0f);
        //    //TopRight
        //    face[2] = new Vector3(1f, 1f, 0.0f);
        //    //BottomLeft
        //    face[3] = new Vector3(-1f, -1f, 0.0f);
        //    //BottomRight
        //    face[4] = new Vector3(1f, -1f, 0.0f);
        //    //TopRight
        //    face[5] = new Vector3(1f, 1f, 0.0f);

        //    //front face
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i] = new VertexPositionNormalTexture(face[i] + Vector3.UnitZ, Vector3.UnitZ, Texcoords);
        //        vertices[i + 3] = new VertexPositionNormalTexture(face[i + 3] + Vector3.UnitZ, Vector3.UnitZ, Texcoords);
        //    }

        //    //back face

        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i + 6] = new VertexPositionNormalTexture(face[2 - i] - Vector3.UnitZ, -Vector3.UnitZ, Texcoords);
        //        vertices[i + 6 + 3] = new VertexPositionNormalTexture(face[5 - i] - Vector3.UnitZ, -Vector3.UnitZ, Texcoords);
        //    }

        //    //left face
        //    Matrix RotY90 = Matrix.CreateRotationY(-(float)Math.PI / 2f);
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i + 12] = new VertexPositionNormalTexture(Vector3.Transform(face[i], RotY90) - Vector3.UnitX, -Vector3.UnitX, Texcoords);
        //        vertices[i + 12 + 3] = new VertexPositionNormalTexture(Vector3.Transform(face[i + 3], RotY90) - Vector3.UnitX, -Vector3.UnitX, Texcoords);
        //    }

        //    //Right face

        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i + 18] = new VertexPositionNormalTexture(Vector3.Transform(face[2 - i], RotY90) + Vector3.UnitX, Vector3.UnitX, Texcoords);
        //        vertices[i + 18 + 3] = new VertexPositionNormalTexture(Vector3.Transform(face[5 - i], RotY90) + Vector3.UnitX, Vector3.UnitX, Texcoords);

        //    }

        //    //Top face

        //    Matrix RotX90 = Matrix.CreateRotationX(-(float)Math.PI / 2f);
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i + 24] = new VertexPositionNormalTexture(Vector3.Transform(face[i], RotX90) + Vector3.UnitY, Vector3.UnitY, Texcoords);
        //        vertices[i + 24 + 3] = new VertexPositionNormalTexture(Vector3.Transform(face[i + 3], RotX90) + Vector3.UnitY, Vector3.UnitY, Texcoords);

        //    }

        //    //Bottom face

        //    for (int i = 0; i <= 2; i++)
        //    {
        //        vertices[i + 30] = new VertexPositionNormalTexture(Vector3.Transform(face[2 - i], RotX90) - Vector3.UnitY, -Vector3.UnitY, Texcoords);
        //        vertices[i + 30 + 3] = new VertexPositionNormalTexture(Vector3.Transform(face[5 - i], RotX90) - Vector3.UnitY, -Vector3.UnitY, Texcoords);
        //    }

        //    return vertices;
        //}

        //const int number_of_vertices = 8;
        //const int number_of_indices = 36;
        //VertexBuffer vertices;

        //void CreateCubeVertexBuffer()
        //{
        //    VertexPositionColor[] cubeVertices = new VertexPositionColor[number_of_vertices];

        //    cubeVertices[0].Position = new Vector3(-1, -1, -1);
        //    cubeVertices[1].Position = new Vector3(-1, -1, 1);
        //    cubeVertices[2].Position = new Vector3(1, -1, 1);
        //    cubeVertices[3].Position = new Vector3(1, -1, -1);
        //    cubeVertices[4].Position = new Vector3(-1, 1, -1);
        //    cubeVertices[5].Position = new Vector3(-1, 1, 1);
        //    cubeVertices[6].Position = new Vector3(1, 1, 1);
        //    cubeVertices[7].Position = new Vector3(1, 1, -1);

        //    cubeVertices[0].Color = Color.Black;
        //    cubeVertices[1].Color = Color.Red;
        //    cubeVertices[2].Color = Color.Yellow;
        //    cubeVertices[3].Color = Color.Green;
        //    cubeVertices[4].Color = Color.Blue;
        //    cubeVertices[5].Color = Color.Magenta;
        //    cubeVertices[6].Color = Color.White;
        //    cubeVertices[7].Color = Color.Cyan;

        //    vertices = new VertexBuffer(graphics.GraphicsDevice, VertexPositionColor.VertexDeclaration, number_of_vertices, BufferUsage.WriteOnly);
        //    vertices.SetData<VertexPositionColor>(cubeVertices);
        //}

        //IndexBuffer indices;

        //void CreateCubeIndexBuffer()
        //{
        //    UInt16[] cubeIndices = new UInt16[number_of_indices];

        //    //bottom face
        //    cubeIndices[0] = 0;
        //    cubeIndices[1] = 2;
        //    cubeIndices[2] = 3;
        //    cubeIndices[3] = 0;
        //    cubeIndices[4] = 1;
        //    cubeIndices[5] = 2;

        //    //top face
        //    cubeIndices[6] = 4;
        //    cubeIndices[7] = 6;
        //    cubeIndices[8] = 5;
        //    cubeIndices[9] = 4;
        //    cubeIndices[10] = 7;
        //    cubeIndices[11] = 6;

        //    //front face
        //    cubeIndices[12] = 5;
        //    cubeIndices[13] = 2;
        //    cubeIndices[14] = 1;
        //    cubeIndices[15] = 5;
        //    cubeIndices[16] = 6;
        //    cubeIndices[17] = 2;

        //    //back face
        //    cubeIndices[18] = 0;
        //    cubeIndices[19] = 7;
        //    cubeIndices[20] = 4;
        //    cubeIndices[21] = 0;
        //    cubeIndices[22] = 3;
        //    cubeIndices[23] = 7;

        //    //left face
        //    cubeIndices[24] = 0;
        //    cubeIndices[25] = 4;
        //    cubeIndices[26] = 1;
        //    cubeIndices[27] = 1;
        //    cubeIndices[28] = 4;
        //    cubeIndices[29] = 5;

        //    //right face
        //    cubeIndices[30] = 2;
        //    cubeIndices[31] = 6;
        //    cubeIndices[32] = 3;
        //    cubeIndices[33] = 3;
        //    cubeIndices[34] = 6;
        //    cubeIndices[35] = 7;

        //    indices = new IndexBuffer(graphics.GraphicsDevice, IndexElementSize.SixteenBits, number_of_indices, BufferUsage.WriteOnly);
        //    indices.SetData<UInt16>(cubeIndices);

        //}
    }
}