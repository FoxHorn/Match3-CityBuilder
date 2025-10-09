using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystemBinary : ISaveSystem
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
            using Stream stream = new FileStream(savePath, FileMode.Open);
            BinaryFormatter formatter = new();
            return (Game)formatter.Deserialize(stream);
        }
        catch (SerializationException)
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
        using Stream stream = new FileStream(savePath, FileMode.Create);
        BinaryFormatter formatter = new();
        formatter.Serialize(stream, game);
    }
}