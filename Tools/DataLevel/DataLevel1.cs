using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;


public static class DataLevel1
{
    private static string ALL_DATA_LEVEL = "ALL_DATA_LEVEL";

    private static DataLevelModel dataLevelModel;
    private static DataWaveModel dataWaveModel;


    static DataLevel1()
    {
        Debug.Log("Static");
        dataLevelModel = JsonConvert.DeserializeObject<DataLevelModel>(PlayerPrefs.GetString(ALL_DATA_LEVEL));

        if (dataLevelModel == null)
        {
            dataLevelModel = new DataLevelModel();
            dataLevelModel.CurrentLevel = 1;
        }

        if(dataWaveModel == null)
        {
            dataWaveModel = new DataWaveModel();
            dataWaveModel.CurrentWave = 1;
        }
        SaveDataLevel();
    }

    #region Level
    private static void SaveDataLevel()
    {
        string json = JsonConvert.SerializeObject(dataLevelModel);
        PlayerPrefs.SetString(ALL_DATA_LEVEL, json);
    }

    public static void SetLevel(int level)
    {
        dataLevelModel.SetLevel(level);
        SaveDataLevel();
    }

    public static int GetCurrentLevel()
    {
        return dataLevelModel.GetCurrentLevel();
    }

    public static int CountAmoutFolderInResources(string path)
    {
        return dataLevelModel.CountAmoutFolderInResources(path);
    }

    #endregion


    public static int CountAmoutWaveInResources(string Path)
    {
        return dataWaveModel.CountAmoutWaveInResources(Path);
    }

    public static int GetCurrentWave()
    {
        return dataWaveModel.GetCurrentWave();
    }
}

public class DataLevelModel
{

    public int CurrentLevel;

    public void SetLevel(int level)
    {
        CurrentLevel = level;
    }

    public int GetCurrentLevel()
    {
        return CurrentLevel;
    }

    public int CountAmoutFolderInResources(string Folderpath)
    {
        int _count = 0;
        string[] subdirectories = Directory.GetDirectories(Folderpath);
        _count = subdirectories.Length;

        return _count;
    }
}

public class DataWaveModel
{

    public int CurrentWave;

    public int GetCurrentWave()
    {
        return CurrentWave;
    }

    public int CountAmoutWaveInResources(string path)
    {
        int _count = 0;

        GameObject[] Resources1 = Resources.LoadAll<GameObject>(path);
        _count = Resources1.Length;

        Debug.Log("co" + Resources1.Length + "wave");

        return _count;
    }
}