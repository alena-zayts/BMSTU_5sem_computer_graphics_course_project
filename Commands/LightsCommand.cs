using System.Collections.Generic;

namespace Weatherwane
{
    class GetLightCommand : BaseCommand
    {
        private string name;
        private Light light;

        public GetLightCommand(string name)
        {
            this.name = name;
        }
        public override void execute(Controller controller)
        {
            controller.getLight(this.name, ref this.light);
        }

        public Light getResult()
        {
            return this.light;
        }
    }

    class GetLightsNamesCommand : BaseCommand
    {

        List<string> lights;

        public override void execute(Controller controller)
        {
            this.lights = controller.getLightsName();
        }

        public List<string> getResult()
        {
            return this.lights;
        }
    }

    class UpdateLightCommand : BaseCommand
    {
        private string name;
        private Vec3 position;
        private double intensity;

        public UpdateLightCommand(string name, double intensity, Vec3 position=null)
        {
            this.name = name;
            this.position = position;
            this.intensity = intensity;
        }

        public override void execute(Controller controller)
        { 
            controller.updateLight(this.name, this.intensity, this.position);
        }
    }

    class AddLightCommand : BaseCommand
    {

        Vec3 position;
        double intensity;
        LightTypes ltype;

        public AddLightCommand(Vec3 position, double intensity, LightTypes ltype)
        {
            this.position = position;
            this.intensity = intensity;
            this.ltype = ltype;
        }
        public override void execute(Controller controller)
        {
            controller.addLight(this.position, this.intensity, this.ltype);
        }
    }

    class DeleteLightCommand : BaseCommand
    {
        private string name;
        public DeleteLightCommand(string name)
        {
            this.name = name;
        }
        public override void execute(Controller controller)
        {
            controller.deleteLight(this.name);
        }
    }
}
