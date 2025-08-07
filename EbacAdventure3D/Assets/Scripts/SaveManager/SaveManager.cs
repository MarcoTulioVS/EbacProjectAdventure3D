using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ebac.Core.Singleton;
public class SaveManager : Singleton<SaveManager>
{

    private SaveSetup _saveSetup;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "Mark";
    }
    

    [NaughtyAttributes.Button]
    private void Save()
    {
       
        string setupToJson = JsonUtility.ToJson(_saveSetup,true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    private void SaveFile(string json)
    {
        string path = Application.dataPath + "/save.txt";

        //string fileLoaded = "";

        //if (File.Exists(path))
        //{
        //    fileLoaded = File.ReadAllText(path);
        //}

        File.WriteAllText(path,json);
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        Save();
    }

    [NaughtyAttributes.Button]
    private void SavaLevelOne()
    {
        SaveLastLevel(1);
    }

    [NaughtyAttributes.Button]
    private void SavaLevelFive()
    {
        SaveLastLevel(5);
    }
}

[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
}
