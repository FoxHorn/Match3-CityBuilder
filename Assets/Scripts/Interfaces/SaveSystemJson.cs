using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveSystemJson : ISaveSystem
{
    private readonly string savePath = Path.Combine(Application.persistentDataPath, "save.dat");

    public Game Load()
    {
        if (!File.Exists(savePath))
        {
            return null;
        }

        try
        {
            string json = File.ReadAllText(savePath);
            return JsonConvert.DeserializeObject<Game>(json);
        }
        catch (JsonException)
        {
            Debug.LogWarning("Ошибка при десериализации файла сохранения");
            return null;
        }
        catch (IOException)
        {
            Debug.LogWarning("Ошибка при открытии файла сохранения");
            return null;
        }
    }

    public void Save(Game game)
    {
        string json = JsonConvert.SerializeObject(game, Formatting.Indented);
        File.WriteAllText(savePath, json);
    }
}
