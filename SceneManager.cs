using Newtonsoft.Json;

namespace Weatherwane
{
    class SceneManager
    {
        private Converter converter;

        public void saveScene(string filename, Scene scene)
        {
            converter = new Converter();
            converter.ToJson(scene);
            string output = JsonConvert.SerializeObject(converter);
            System.IO.File.WriteAllText(filename, output);
        }

        public void loadScene(string filename, ref Scene scene)
        {
            string input = System.IO.File.ReadAllText(filename);
            converter = JsonConvert.DeserializeObject<Converter>(input);
            converter.FromJson(ref scene);
        }
    }
}
