﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Weatherwane
{
    class RenderCommand : Command
    {
        private PictureBox canvas;
        TextBox textBoxTime;

        unsafe public RenderCommand(ref PictureBox canvas, ref TextBox textBoxTime)
        {
            this.canvas = canvas;
            this.textBoxTime = textBoxTime;
        }
        public override void execute(Controller controller)
        {
            controller.render(ref canvas, ref this.textBoxTime);
        }
    }

    class StopRenderCommand : Command
    {
        public override void execute(Controller controller)
        {
            controller.stopRender();
        }
    }

    class DynamicRenderCommand : Command
    {
        private PictureBox canvas;
        ProgressBar progressBar;
        TextBox textBoxTime;


        unsafe public DynamicRenderCommand(ref PictureBox canvas, ref ProgressBar progressBar, ref TextBox textBoxTime)
        {
            this.canvas = canvas;
            this.progressBar = progressBar;
            this.textBoxTime = textBoxTime;
        }
        public override void execute(Controller controller)
        {
            controller.dynamic_render(ref canvas, ref this.progressBar, ref this.textBoxTime);
        }
    }
}
