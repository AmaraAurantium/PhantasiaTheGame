using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string getpath()
    {
        return Application.persistentDataPath + "/data.ara";
    }

    //save and load data
    public static void save(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(getpath(), FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static SaveData load()
    {
        if (!File.Exists(getpath()))
        {
            SaveData emptyData = new SaveData();
            save(emptyData);
            return emptyData;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(getpath(), FileMode.Open);
        SaveData data = formatter.Deserialize(fs) as SaveData;
        fs.Close();

        return data;
    }
}
