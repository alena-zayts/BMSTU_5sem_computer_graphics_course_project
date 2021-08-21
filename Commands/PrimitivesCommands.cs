using System.Collections.Generic;

namespace Weatherwane
{
    class UpdatePrimitiveCommand : BaseCommand
    {
        private string name;
        private double specular;
        private double reflective;
        private Vec3 color;

        public UpdatePrimitiveCommand(string name, Vec3 color, double specular, double reflective)
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
    class GetPrimitivesCommand : BaseCommand
    {
        private List<Primitive> primitives;

        public override void execute(Controller controller)
        {
            primitives = controller.getPrimitives();
        }

        public List<Primitive> getResult()
        {
            return this.primitives;
        }
    }
}
