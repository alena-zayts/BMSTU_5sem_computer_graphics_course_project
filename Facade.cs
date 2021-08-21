
namespace Weatherwane
{
    class Facade
    {
        private Controller controller;
        public Facade(int canvasWidth, int canvasHeight)
        {
            this.controller = new Controller(canvasWidth, canvasHeight);
        }

        public void executeCommand(BaseCommand command)
        {
            command.execute(controller);
        }
    }
}
