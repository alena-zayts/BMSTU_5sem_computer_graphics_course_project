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

        unsafe public DynamicRenderCommand(ref PictureBox canvas, bool drawSea, ref ProgressBar progressBar)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
            this.progressBar = progressBar;
        }
        public override void execute(Controller controller)
        {
            controller.dynamic_render(ref canvas, this.drawSea, ref this.progressBar);
        }
    }
}
