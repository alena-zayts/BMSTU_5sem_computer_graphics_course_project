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

        unsafe public DynamicRenderCommand(ref PictureBox canvas, bool drawSea)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
        }
        public override void execute(Controller controller)
        {
            controller.dynamic_render(ref canvas, this.drawSea);
        }
    }

/*    class CreateArrayBitmap : Command
    {
        private PictureBox canvas;
        private bool drawSea;
        private int n;

        unsafe public CreateArrayBitmap(ref PictureBox canvas, bool drawSea, int n)
        {
            this.canvas = canvas;
            this.drawSea = drawSea;
            this.n = n;
        }
        public override void execute(Controller controller)
        {
            controller.createArrayBitmap(ref canvas, this.drawSea, this.);
        }
    }*/
}
