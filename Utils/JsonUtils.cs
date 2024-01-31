using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NationalExamReporter.Utils;

public class JsonUtils
{
    
    
    public static void AppendToFile<T>(string jsonPath, T obj)
    {
        List<T> objList = DeserializeObjectList<T>(jsonPath);
        objList.Add(obj);
        var json = JsonConvert.SerializeObject(objList);
        File.WriteAllText(jsonPath,json);
    }

    public static void RemoveFromFileByIndex<T>(string jsonPath, int index)
    {
        List<T> objList = DeserializeObjectList<T>(jsonPath);
        objList.RemoveAt(index);
        var json = JsonConvert.SerializeObject(objList);
        File.WriteAllText(jsonPath,json);
    }
    public static List<T> DeserializeObjectList<T>(string path)
    {
        return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@path));
    }

    public static JObject GetJsonDataAsObject(string path)
    {
        return (JObject)JsonConvert.DeserializeObject(File.ReadAllText(path));
    }
}