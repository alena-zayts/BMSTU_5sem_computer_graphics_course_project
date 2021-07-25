using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Atomium
{
    class RenderCommand : Command
    {
        private PictureBox canvas;
        private bool drawAxes;
        private bool drawNebo;

        unsafe public RenderCommand(ref PictureBox canvas, bool drawOXYZ, bool drawNebo)
        {
            this.canvas = canvas;
            this.drawAxes = drawOXYZ;
            this.drawNebo = drawNebo;
        }
        public override void execute(Controller controller)
        {
            controller.render(ref canvas, this.drawAxes, this.drawNebo);
        }
    }

    class DynamicRenderCommand : Command
    {
        private PictureBox canvas;
        private bool drawAxes;
        private bool drawNebo;

        unsafe public DynamicRenderCommand(ref PictureBox canvas, bool drawOXYZ, bool drawNebo)
        {
            this.canvas = canvas;
            this.drawAxes = drawOXYZ;
            this.drawNebo = drawNebo;
        }
        public override void execute(Controller controller)
        {
            controller.dynamic_render(ref canvas, this.drawAxes, this.drawNebo);
        }
    }

    class DrawAxesCommand : Command
    {
        private PictureBox canvas;
        private bool drawAxes;

        unsafe public DrawAxesCommand(ref PictureBox canvas, bool draw)
        {
            this.canvas = canvas;
            this.drawAxes = draw;
        }
        public override void execute(Controller controller)
        {
            controller.drawingAxes(ref canvas, this.drawAxes);
        }
    }
}
