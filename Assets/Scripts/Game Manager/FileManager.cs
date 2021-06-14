using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileManager
{
    public static T Save<T>(T param, string filePath)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, param);
        file.Close();
        return param;
    }

    public static T Load<T>(T param, string filePath)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
        param = (T)bf.Deserialize(file);
        file.Close();
        return param;
    }
}
