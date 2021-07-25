using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class SaveCommand : Command
    {
        private string name;

        public SaveCommand(string name)
        {
            this.name = name;
        }
        public override void execute(Controller controller)
        {
            controller.saveScene(this.name);
        }
    }
}
