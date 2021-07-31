using System;
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
        private bool drawSea;
        private int numThreads;
        TextBox textBoxTime;

        unsafe public RenderCommand(ref PictureBox canvas, bool drawSea, int numThreads, ref TextBox textBoxTime)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
            this.numThreads = numThreads;
            this.textBoxTime = textBoxTime;
        }
        public override void execute(Controller controller)
        {
            controller.render(ref canvas, this.drawSea, this.numThreads, ref this.textBoxTime);
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
        private bool drawSea;
        ProgressBar progressBar;
        private bool reverse;
        private int speed;
        private int numThreads;
        TextBox textBoxTime;
        bool createArray;
        int n;


        unsafe public DynamicRenderCommand(ref PictureBox canvas, bool drawSea, ref ProgressBar progressBar, bool reverse, int speed, int numThreads, ref TextBox textBoxTime, bool createArray, int n)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
            this.progressBar = progressBar;
            this.reverse = reverse;
            this.speed = speed;
            this.numThreads = numThreads;
            this.textBoxTime = textBoxTime;
            this.createArray = createArray;
            this.n = n;
        }
        public override void execute(Controller controller)
        {
            controller.dynamic_render(ref canvas, this.drawSea, ref this.progressBar, this.reverse, this.speed, this.numThreads, ref this.textBoxTime, createArray, n);
        }
    }

    class ChangeParamsCommand : Command
    {
        private bool reverse;
        private int speed;


        unsafe public ChangeParamsCommand(bool reverse, int speed)
        {
            this.reverse = reverse;
            this.speed = speed;
        }
        public override void execute(Controller controller)
        {
            controller.changeParams(this.reverse, this.speed);
        }
    }
}
