using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;

    private SaveData saveData;

    private List<IDataPersistance> dataPersistanceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one data persistance manager");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        loadGame();
    }
    private void newGame()
    {
        this.saveData = new SaveData();
    }

    private void loadGame()
    {
        //load saved file
        this.saveData = dataHandler.load();

        //initializing to defaults when no save is found
        if (this.saveData == null)
        {
            Debug.Log("No save data was found, initializing to default state");
            newGame();
        }
        //push to any files that need it
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.loadData(saveData);
        }
    }

    private void saveGame()
    {
        //pass to other files so they can update
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.saveData (ref saveData);
        }
        //save data using file handler
        dataHandler.save(saveData);
    }

    private void OnApplicationQuit()
    {
        saveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
