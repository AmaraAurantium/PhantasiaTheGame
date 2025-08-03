using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance
{
    void loadData(SaveData data);

    void saveData(ref SaveData data);
}
