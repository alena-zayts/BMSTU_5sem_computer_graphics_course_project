using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class UpdateParamsCommand : Command
    {
        private bool BF_model;
        private double coef;
        private bool drawSceneBackground;
        private int recursion_depth;
        private int numThreads;

        private int picturesNum;
        private bool reverse;
        private int speed;
        private bool createArray;

        unsafe public UpdateParamsCommand(bool reverse, int speed, bool createArray, int picturesNum, bool BF_model, double coef, bool drawBackground, int numThreads, int recursion_depth)
        {
            this.reverse = reverse;
            this.picturesNum = picturesNum;
            this.speed = speed;
            this.createArray = createArray;

            this.recursion_depth = recursion_depth;
            this.drawSceneBackground = drawBackground;
            this.BF_model = BF_model;
            this.coef = coef;
            this.numThreads = numThreads;
        }
        public override void execute(Controller controller)
        {
            controller.UpdateParams(reverse, speed, createArray, picturesNum, BF_model, coef, drawSceneBackground, numThreads, recursion_depth);
        }
    }
}
