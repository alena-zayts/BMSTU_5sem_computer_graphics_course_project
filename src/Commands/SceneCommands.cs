namespace Weatherwane
{
    class SaveSceneCommand : BaseCommand
    {
        private string name;

        public SaveSceneCommand(string name)
        {
            this.name = name;
        }
        public override void execute(Controller controller)
        {
            controller.saveScene(this.name);
        }
    }
    class LoadSceneCommand : BaseCommand
    {
        private string name;

        public LoadSceneCommand(string name)
        {
            this.name = name;
        }
        public override void execute(Controller controller)
        {
            controller.loadScene(this.name);
        }
    }
}
