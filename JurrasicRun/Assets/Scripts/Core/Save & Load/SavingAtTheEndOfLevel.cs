using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingAtTheEndOfLevel : MonoBehaviour
{
    
    [SerializeField] private Eggs eggsScript;
    [SerializeField] private Bird_In_Cage bird_in_cage_script;

    private PlayerData playerData;

    private string persistentPath = "";
    private int level;
    private int eggs;
    private int allEggs;
    private bool dodo;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreatePlayerData();
        SaveData();
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

    private void CreatePlayerData()
    {

        level = SceneManager.GetActiveScene().buildIndex;
        eggs = eggsScript.collectedEggs;
        allEggs = eggsScript.AmountOfAllExisting;
        dodo = bird_in_cage_script.birdSaved;
        playerData = new PlayerData(level, dodo, eggs, allEggs);
    }

    private void SetPaths()
    {
        //path = Application.dataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + $"SaveLevel{level}.json";
    }
}
