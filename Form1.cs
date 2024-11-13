using OpenTK.WinForms;
using OpenTK.Graphics.OpenGL;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Lab7_1
{
    public partial class Form1 : Form
    {
        private bool loaded = false;

        public Form1()
        {
            InitializeComponent();

            glControl1.Load += (sender, e) =>
            {
                loaded = true;
                glControl1.MakeCurrent();
                GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            };

            glControl1.Paint += (sender, e) =>
            {
                if (!loaded) return;

                glControl1.MakeCurrent();
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();

                if (glControl1.Width <= glControl1.Height)
                {
                    float aspect = (float)glControl1.Height / glControl1.Width;
                    GL.Ortho(-1.0, 1.0, aspect, -aspect, -1.0, 1.0);
                }
                else
                {
                    float aspect = (float)glControl1.Width / glControl1.Height;
                    GL.Ortho(-aspect, aspect, 1.0, -1.0, -1.0, 1.0);
                }

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();

                DrawClockFace();

                DateTime now = DateTime.Now;

                DrawHourHand(now.Hour, now.Minute);
                DrawMinuteHand(now.Minute, now.Second);
                DrawSecondHand(now.Second);

                glControl1.SwapBuffers();
            };

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 16;
            timer.Tick += (sender, e) => glControl1.Invalidate();
            timer.Start();
        }

        private void DrawClockFace()
        {
            GL.Color3(1.0f, 1.0f, 1.0f);
            DrawCircle(0, 0, 0.9f);

            for (int i = 0; i < 12; i++)
            {
                double angle = i * 30 * Math.PI / 180;
                float x1 = (float)(Math.Cos(angle) * 0.85);
                float y1 = (float)(Math.Sin(angle) * 0.85);
                float x2 = (float)(Math.Cos(angle) * 0.9);
                float y2 = (float)(Math.Sin(angle) * 0.9);

                GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(x1, y1);
                GL.Vertex2(x2, y2);
                GL.End();
            }
        }

        private void DrawCircle(float cx, float cy, float r)
        {
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < 360; i++)
            {
                double angle = i * Math.PI / 180;
                GL.Vertex2(cx + Math.Cos(angle) * r, cy + Math.Sin(angle) * r);
            }
            GL.End();
        }

        private void DrawHourHand(int hour, int minute)
        {
            double angle = (-90 + (hour * 30 + minute * 0.5)) * Math.PI / 180;
            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.LineWidth(3.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, 0);
            GL.Vertex2(Math.Cos(angle) * 0.6f, Math.Sin(angle) * 0.6f);
            GL.End();
        }

        private void DrawMinuteHand(int minute, int second)
        {
            double angle = (-90 + (minute * 6 + second * 0.1)) * Math.PI / 180;
            GL.Color3(1.0f, 1.0f, 1.0f);
            GL.LineWidth(2.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, 0);
            GL.Vertex2(Math.Cos(angle) * 0.5f, Math.Sin(angle) * 0.5f);
            GL.End();
        }

        private void DrawSecondHand(int second)
        {
            double angle = (-90 + (second * 6)) * Math.PI / 180;
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0, 0);
            GL.Vertex2(Math.Cos(angle) * 0.8f, Math.Sin(angle) * 0.8f);
            GL.End();
        }

    }
}