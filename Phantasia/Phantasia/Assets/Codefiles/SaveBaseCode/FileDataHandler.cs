using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
 
public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler (string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public SaveData load()
    {
        //using path.combine ensures that it works on diffrent OS's (different seperators)
        string fullpath = Path.Combine(dataDirPath, dataFileName);
        SaveData loadedData = null;
        if (File.Exists(fullpath))
        {
            try
            {
                //loaded serialalized data from file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //deserialize from json back into C#
                loadedData = JsonUtility.FromJson<SaveData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured while trying to load data from file" + fullpath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void save(SaveData data)
    {
        //using path.combine ensures that it works on diffrent OS's (different seperators)
        string fullpath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //create the directory file path in case it doesn't exist yet
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            //serialize data to store the c# game data into json
            string dataToStore = JsonUtility.ToJson(data, true);

            //write the string to the designiatied file
            using(FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured while trying to save data to file" + fullpath + "\n" + e);
        }
    }
}
