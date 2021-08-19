using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class TurnXCameraCommand : Command
    {
        private double angle;

        public TurnXCameraCommand(double angle)
        {
            this.angle = angle;
        }
        public override void execute(Controller controller)
        {
            controller.turnXCamera(angle);
        }
    }

    class TurnYCameraCommand : Command
    {
        private double angle;

        public TurnYCameraCommand(double angle)
        {
            this.angle = angle;
        }
        public override void execute(Controller controller)
        {
            controller.turnYCamera(angle);
        }
    }
    class TurnZCameraCommand : Command
    {
        private double angle;

        public TurnZCameraCommand(double angle)
        {
            this.angle = angle;
        }
        public override void execute(Controller controller)
        {
            controller.turnZCamera(angle);
        }
    }

    class MoveCameraCommand : Command
    {
        private Vec3 d;

        public MoveCameraCommand(Vec3 d)
        {
            this.d = d;
        }
        public override void execute(Controller controller)
        {
            controller.moveCamera(d);
        }
    }

    class GetCameraCommand : Command
    {
        private Camera camera;
  
        public override void execute(Controller controller)
        {
            camera = controller.getCamera();
        }
        public Camera getResult()
        {
            return this.camera;
        }
    }
}
