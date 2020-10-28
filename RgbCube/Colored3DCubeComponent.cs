using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.Tests.Components
{
	class Colored3DCubeComponent
	{
		GraphicsDevice graphicsDevice;
		BasicEffect basicEffect;

		const int number_of_vertices = 8;
		const int number_of_indices = 36;
		VertexBuffer vertices;

		Matrix worldMatrix, viewMatrix, projectionMatrix;
		float rotationX = 0f;
		float rotationY = 0.4f;

		public Vector3 CubePosition { get; set; }

		public Colored3DCubeComponent(GraphicsDevice gd)
		{
			graphicsDevice = gd;
		}

		public void LoadContent()
		{
			// setup our graphics scene matrices
			UpdateWorldMatrix();
			viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
			projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, graphicsDevice.Viewport.AspectRatio, 1, 10);

			// Setup our basic effect
			basicEffect = new BasicEffect(graphicsDevice);
			basicEffect.World = worldMatrix;
			basicEffect.View = viewMatrix;
			basicEffect.Projection = projectionMatrix;
			basicEffect.VertexColorEnabled = true;

			CreateCubeVertexBuffer();
			CreateCubeIndexBuffer();
		}

		public void UnloadContent()
		{
			basicEffect.Dispose();
			basicEffect = null;

			vertices.Dispose();
			vertices = null;

			indices.Dispose();
			indices = null;
		}

		public void Draw()
		{
			graphicsDevice.Clear(Color.CornflowerBlue);

			graphicsDevice.SetVertexBuffer(vertices);
			graphicsDevice.Indices = indices;

			basicEffect.World = worldMatrix;

			foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
			{
				pass.Apply();
				graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, number_of_vertices, 0, number_of_indices / 3);
			}
		}

		public void Update()
        {
			float rotationChange = 0.008f;
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				rotationY += rotationChange;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				rotationY -= rotationChange;
			}
			if (rotationY > 2 * Math.PI)
			{
				rotationY = 0f;
			}
			if (Keyboard.GetState().IsKeyDown(Keys.W))
			{
				rotationX += rotationChange;
			}
			else if (Keyboard.GetState().IsKeyDown(Keys.S))
			{
				rotationX -= rotationChange;
			}
			if (rotationX > 2 * Math.PI)
			{
				rotationX = 0f;
			}
			UpdateWorldMatrix();
		}

		void UpdateWorldMatrix()
        {
			Matrix rotation = Matrix.CreateRotationY(rotationY) * Matrix.CreateRotationX(rotationX);
			worldMatrix = Matrix.CreateTranslation(CubePosition) * rotation;
		}

		void CreateCubeVertexBuffer()
		{
			VertexPositionColor[] cubeVertices = new VertexPositionColor[number_of_vertices];

			cubeVertices[0].Position = new Vector3(-1, -1, -1);
			cubeVertices[1].Position = new Vector3(-1, -1, 1);
			cubeVertices[2].Position = new Vector3(1, -1, 1);
			cubeVertices[3].Position = new Vector3(1, -1, -1);
			cubeVertices[4].Position = new Vector3(-1, 1, -1);
			cubeVertices[5].Position = new Vector3(-1, 1, 1);
			cubeVertices[6].Position = new Vector3(1, 1, 1);
			cubeVertices[7].Position = new Vector3(1, 1, -1);

			cubeVertices[0].Color = Color.Black;
			cubeVertices[1].Color = Color.Red;
			cubeVertices[2].Color = Color.Yellow;
			cubeVertices[3].Color = Color.Green;
			cubeVertices[4].Color = Color.Blue;
			cubeVertices[5].Color = Color.Magenta;
			cubeVertices[6].Color = Color.White;
			cubeVertices[7].Color = Color.Cyan;

			vertices = new VertexBuffer(graphicsDevice, VertexPositionColor.VertexDeclaration, number_of_vertices, BufferUsage.WriteOnly);
			vertices.SetData<VertexPositionColor>(cubeVertices);
		}

		IndexBuffer indices;

		void CreateCubeIndexBuffer()
		{
			UInt16[] cubeIndices = new UInt16[number_of_indices];

			//bottom
			cubeIndices[0] = 0;
			cubeIndices[1] = 2;
			cubeIndices[2] = 3;
			cubeIndices[3] = 0;
			cubeIndices[4] = 1;
			cubeIndices[5] = 2;

			//top
			cubeIndices[6] = 4;
			cubeIndices[7] = 6;
			cubeIndices[8] = 5;
			cubeIndices[9] = 4;
			cubeIndices[10] = 7;
			cubeIndices[11] = 6;

			//front
			cubeIndices[12] = 5;
			cubeIndices[13] = 2;
			cubeIndices[14] = 1;
			cubeIndices[15] = 5;
			cubeIndices[16] = 6;
			cubeIndices[17] = 2;

			//back
			cubeIndices[18] = 0;
			cubeIndices[19] = 7;
			cubeIndices[20] = 4;
			cubeIndices[21] = 0;
			cubeIndices[22] = 3;
			cubeIndices[23] = 7;

			//left
			cubeIndices[24] = 0;
			cubeIndices[25] = 4;
			cubeIndices[26] = 1;
			cubeIndices[27] = 1;
			cubeIndices[28] = 4;
			cubeIndices[29] = 5;

			//right
			cubeIndices[30] = 2;
			cubeIndices[31] = 6;
			cubeIndices[32] = 3;
			cubeIndices[33] = 3;
			cubeIndices[34] = 6;
			cubeIndices[35] = 7;

			indices = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits, number_of_indices, BufferUsage.WriteOnly);
			indices.SetData<UInt16>(cubeIndices);
		}

	}
}