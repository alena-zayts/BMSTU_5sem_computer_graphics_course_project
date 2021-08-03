using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class UpdatePrimitiveCommand : Command
    {
        private string name;
        private double specular;
        private double reflective;
        private Vec3d color;

        public UpdatePrimitiveCommand(string name, Vec3d color, double specular, double reflective)
        {
            this.name = name;
            this.color = color;
            this.specular = specular;
            this.reflective = reflective;
        }
        public override void execute(Controller controller)
        {
            controller.updatePrimitive(this.name, this.color, this.specular, this.reflective);
        }
    }
}
