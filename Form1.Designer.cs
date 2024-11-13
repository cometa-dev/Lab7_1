namespace Lab7_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            glControl1 = new OpenTK.WinForms.GLControl();
            SuspendLayout();
            // 
            // glControl1
            // 
            glControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl1.APIVersion = new Version(3, 3, 0, 0);
            glControl1.Dock = DockStyle.Fill;
            glControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl1.IsEventDriven = true;
            glControl1.Location = new Point(0, 0);
            glControl1.Margin = new Padding(5, 6, 5, 6);
            glControl1.Name = "glControl1";
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl1.SharedContext = null;
            glControl1.Size = new Size(1371, 1200);
            glControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 1200);
            Controls.Add(glControl1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "OpenGL Test";
            ResumeLayout(false);
        }

        private OpenTK.WinForms.GLControl glControl1;
    }
}