namespace Weatherwane
{
    class TurnXCameraCommand : BaseCommand
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
    class TurnYCameraCommand : BaseCommand
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
    class TurnZCameraCommand : BaseCommand
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

    class MoveCameraCommand : BaseCommand
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

    class GetCameraCommand : BaseCommand
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
