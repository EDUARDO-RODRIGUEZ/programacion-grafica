using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Animacion.animacion
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Accion
    {
        [JsonProperty] public string nameObject;
        [JsonProperty] public long timeStart;
        [JsonProperty] public long duration;

        public Accion(string nameObject, long timeStart, long duration)
        {
            this.nameObject = nameObject;
            this.timeStart = timeStart;
            this.duration = duration;
        }

        public static void SerializeJsonFile(string path, Accion obj)
        {
            string textJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(path, textJson);
        }

        public static Accion DeserializeJsonFile(string path)
        {
            string textJson = new StreamReader(path).ReadToEnd();
            return JsonConvert.DeserializeObject<Accion>(textJson);
        }

    }
}
