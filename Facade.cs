using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weatherwane
{
    class Facade
    {
        private Controller controller;
        public Facade(int canvasWidth, int canvasHeight)
        {
            this.controller = new Controller(canvasWidth, canvasHeight);
        }

        public void executeCommand(Command command)
        {
            command.execute(controller);
        }
    }
}
