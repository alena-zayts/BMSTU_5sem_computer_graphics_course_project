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

        unsafe public RenderCommand(ref PictureBox canvas, bool drawSea)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
        }
        public override void execute(Controller controller)
        {
            controller.render(ref canvas, this.drawSea);
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
}
