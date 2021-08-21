using System.Windows.Forms;

namespace Weatherwane
{
    class RenderCommand : BaseCommand
    {
        private PictureBox canvas;
        private TextBox textBoxTime;

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

    class StopRenderCommand : BaseCommand
    {
        public override void execute(Controller controller)
        {
            controller.stopRender();
        }
    }

    class DynamicRenderCommand : BaseCommand
    {
        private PictureBox canvas;
        private ProgressBar progressBar;
        private TextBox textBoxTime;


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
    class UpdateRenderCommand : BaseCommand
    {
        private bool BF_model;
        private double coef;
        private bool drawBackground;
        private int recursion_depth;
        private int numThreads;

        private int picturesNum;
        private bool reverse;
        private int speed;
        private bool createArray;

        unsafe public UpdateRenderCommand(bool reverse, int speed, bool createArray, int picturesNum, bool BF_model, double coef, bool drawBackground, int numThreads, int recursion_depth)
        {
            this.reverse = reverse;
            this.picturesNum = picturesNum;
            this.speed = speed;
            this.createArray = createArray;

            this.recursion_depth = recursion_depth;
            this.drawBackground = drawBackground;
            this.BF_model = BF_model;
            this.coef = coef;
            this.numThreads = numThreads;
        }
        public override void execute(Controller controller)
        {
            controller.UpdateParams(reverse, speed, createArray, picturesNum, BF_model, coef, drawBackground, numThreads, recursion_depth);
        }
    }
}
