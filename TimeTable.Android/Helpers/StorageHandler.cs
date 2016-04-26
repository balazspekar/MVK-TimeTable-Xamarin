using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace TimeTable.Droid.Helpers
{
    class StorageHandler
    {

        public static void Serialize(List<Favorite> favorites)
        {
            var json = JsonConvert.SerializeObject(favorites);
            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var file = Path.Combine(path, "megallo_settings.txt");

            using (var streamWriter = new StreamWriter(file))
            {
                streamWriter.WriteLine(json);
            }
        }

        public static List<Favorite> Deserialize()
        {
            string json;
            var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var file = Path.Combine(path, "megallo_settings.txt");

            using (StreamReader streamReader = new StreamReader(file))
            {
                json = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Favorite>>(json);

        }

    }
}