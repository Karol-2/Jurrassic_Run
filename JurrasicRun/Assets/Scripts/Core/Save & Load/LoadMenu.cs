using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    private PlayerData playerData;

    private string path = "";
    private string persistentPath = "";
    private int level;
    private int eggs = -1;
    private int allEggs = 100;
    private bool dodo = false;

    public void CreateNew()
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (i == 0)
                continue;

            level = i;
            eggs = -2;
            allEggs = -1;
            dodo = false;
            playerData = new PlayerData(level, dodo, eggs, allEggs);

            SaveData();
        }
    }

    public void SaveData()
    {
        SetPaths();

        string savePath = persistentPath;


        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    private void SetPaths()
    {
        //path = Application.dataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
    }
}
