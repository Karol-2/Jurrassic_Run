using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingJSON : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Eggs eggsScript;
    [SerializeField] private Bird_In_Cage cage;

    [Header("Paths")]
    private string persistentPath = "";

    private int level;
    private int eggs = -1;
    private int allEggs = 100;
    private bool dodo = false;

    private PlayerData playerData;

    private void CreatePlayerData()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        eggs = eggsScript.collectedEggs;
        allEggs = eggsScript.AmountOfAllExisting;
        dodo = cage.birdSaved;

        playerData = new PlayerData(level, dodo, eggs, allEggs);
    }

    private void SetPaths()
    {
        //path = Application.dataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreatePlayerData();
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.L))
            LoadData();
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

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }
}
