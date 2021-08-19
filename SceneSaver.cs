using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weatherwane
{
    class SceneSaver
    {
        public void saveScene(string filename, Scene scene)
        {
            Converter convert = new Converter();
            convert.ToJson(scene);
            string output = JsonConvert.SerializeObject(convert);
            System.IO.File.WriteAllText(filename, output);
        }
    }
}
