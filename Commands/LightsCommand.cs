using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class GetLightCommand : Command
    {
        private string name;
        Light light;

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

    class GetLightsNamesCommand : Command
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

    class UpdateLightCommand : Command
    {
        private string name;
        Vec3 position;
        double intensity;

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

    class AddLightCommand : Command
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

    class DeleteLightCommand : Command
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
