using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab_3
{
    internal class Window : GameWindow
    {
        private float lineWidth = 1.0f;

        private float pointSize = 1.0f;

        private float[] triangleColor = new float[] { 1.0f, 0.0f, 0.0f };  // Roșu inițial

        private Matrix4 rotationMatrix = Matrix4.Identity;

        private float cameraAngle = 0.0f;

        private int previousMouseX;

        public Window() : base(800, 600, GraphicsMode.Default, "Axe X, Y, Z")
        {
            Title = "Laborator 3";

            VSync = VSyncMode.On;

            previousMouseX = Mouse.GetState().X;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Axe();

            DrawTriangle();

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard[Key.R])
                triangleColor = new float[] { 1.0f, 0.0f, 0.0f };  // Roșu
            else if (keyboard[Key.G])
                triangleColor = new float[] { 0.0f, 1.0f, 0.0f };  // Verde
            else if (keyboard[Key.B])
                triangleColor = new float[] { 0.0f, 0.0f, 1.0f };  // Albastru

            HandleKeyboardInput();
            HandleMouseInput();

            base.OnUpdateFrame(e);
        }

        private void Axe()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Begin(PrimitiveType.Lines);

            // Axa X (roșie)
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(1.0f, 0.0f, 0.0f);

            // Axa Y (verde)
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 1.0f, 0.0f);

            // Axa Z (albastru)
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.Vertex3(0.0f, 0.0f, 1.0f);

            GL.End();
        }

        private void DrawTriangle()
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref rotationMatrix);
            GL.Begin(PrimitiveType.Triangles);

            // Vertex 1
            GL.Color3(triangleColor[0], triangleColor[1], triangleColor[2]);
            GL.Vertex3(0.0f, 0.0f, 0.0f);

            // Vertex 2
            GL.Color3(triangleColor[0], triangleColor[1], triangleColor[2]);
            GL.Vertex3(0.5f, 0.0f, 0.0f);

            // Vertex 3
            GL.Color3(triangleColor[0], triangleColor[1], triangleColor[2]);
            GL.Vertex3(0.25f, 0.5f, 0.0f);

            GL.End();
        }

        private void HandleKeyboardInput()
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Key.A))
            {
                // Reducem lățimea liniei
                lineWidth -= 0.1f;
                if (lineWidth < 1.0f)
                    lineWidth = 1.0f;

                GL.LineWidth(lineWidth);
            }
            else if (keyboard.IsKeyDown(Key.D))
            {
                // Creștem lățimea liniei
                lineWidth += 0.1f;
                GL.LineWidth(lineWidth);
            }
            else if (keyboard.IsKeyDown(Key.W))
            {
                // Creștem dimensiunea punctului
                pointSize += 1.0f;
                GL.PointSize(pointSize);
            }
            else if (keyboard.IsKeyDown(Key.S))
            {
                // Reducem dimensiunea punctului
                pointSize -= 1.0f;
                if (pointSize < 1.0f)
                    pointSize = 1.0f;

                GL.PointSize(pointSize);
            }
        }

        private void HandleMouseInput()
        {
            var currentMouse = Mouse.GetState();
            int deltaX = currentMouse.X - previousMouseX;
            cameraAngle += deltaX;
            rotationMatrix = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(cameraAngle));
            previousMouseX = currentMouse.X;
        }
    }
}
