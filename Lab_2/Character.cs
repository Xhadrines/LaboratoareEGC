using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Lab_2
{
    public class Character : GameWindow
    {
        private float characterRotation = 0.0f;

        private float sensitivity = 0.01f;

        private bool isRotating = false;

        public Character() : base(800, 600)
        {
            Title = "Laborator 2";

            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.392f, 0.584f, 0.929f, 1.0f);

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadIdentity();

            GL.Rotate(characterRotation, 0, 1, 0);

            // Desenare cerc
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Color3(1.0f, 1.0f, 1.0f); // Culoare albă

            GL.Vertex2(0, 0); // Centrul centrul

            int numSegments = 20;

            for (int i = 0; i <= numSegments; i++)
            {
                double angle = 2 * Math.PI * i / numSegments;

                double x = Math.Cos(angle);

                double y = Math.Sin(angle);

                GL.Vertex2(x, y);
            }

            GL.End();

            GL.Begin(PrimitiveType.Lines);

            GL.Color3(0.0f, 0.0f, 0.0f); // Culoare neagră

            // Corpul omulețului
            // Linie verticală pentru corp
            GL.Vertex2(0, 0);
            GL.Vertex2(0, -0.4f);

            // Capul omulețului
            // Linie dreapta orizontală pentru cap jos
            GL.Vertex2(0, 0);
            GL.Vertex2(0.1f, 0);
            // Linie stânga orizontală pentru cap jos
            GL.Vertex2(0, 0);
            GL.Vertex2(-0.1f, 0);
            // Linie dreapta verticală pentru cap
            GL.Vertex2(0.1f, 0);
            GL.Vertex2(0.1f, 0.2f);
            // Linie stânga verticală pentru cap
            GL.Vertex2(-0.1f, 0);
            GL.Vertex2(-0.1f, 0.2f);
            // Linie dreapta orizontală pentru cap sus
            GL.Vertex2(-0.1f, 0.2f);
            GL.Vertex2(0.1f, 0.2f);

            // Mâinile omulețului
            // Linie stânga pentru mână stânga
            GL.Vertex2(0, -0.2f);
            GL.Vertex2(-0.1f, -0.3f);
            // Linie dreapta pentru mână dreapta
            GL.Vertex2(0, -0.2f);
            GL.Vertex2(0.1f, -0.3f);

            // Picioarele omulețului
            // Linie stânga pentru picior stânga
            GL.Vertex2(0, -0.4f);
            GL.Vertex2(-0.1f, -0.6f);
            // Linie dreapta pentru picior dreapta
            GL.Vertex2(0, -0.4f);
            GL.Vertex2(0.1f, -0.6f);

            GL.End();

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = Keyboard.GetState();

            // Invartire la stanga
            if (keyboard[Key.A])
            {
                characterRotation += 2.0f;
            }

            // Invartire la dreapta
            if (keyboard[Key.D])
            {
                characterRotation -= 2.0f;
            }

            // Activare/Dezactivare mouse
            if (keyboard[Key.S])
            {
                if (isRotating)
                {
                    isRotating = false;

                    characterRotation = 0.0f; // Resetează la valoarea inițială
                }

                else
                {
                    isRotating = true;
                }
            }

            // Invartire prin mouse
            if (isRotating)
            {
                var mouse = Mouse.GetState();

                characterRotation += mouse.X * sensitivity;
            }

            // Închide programul la apăsarea tastei "ESC"
            if (keyboard[Key.Escape])
            {
                Exit();
            }

            base.OnUpdateFrame(e);
        }
    }
}
