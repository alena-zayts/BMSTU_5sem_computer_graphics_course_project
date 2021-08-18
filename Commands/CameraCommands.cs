using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
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

    class MoveCameraCommand : Command
    {
        private double dx;
        private double dy;
        private double dz;

        public MoveCameraCommand(double dx, double dy, double dz)
        {
            this.dx = dx;
            this.dy = dy;
            this.dz = dz;
        }
        public override void execute(Controller controller)
        {
            controller.moveCamera(this.dx, this.dy, this.dz);
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
