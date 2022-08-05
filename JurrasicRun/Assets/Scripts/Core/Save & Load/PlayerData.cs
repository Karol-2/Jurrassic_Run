using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public bool dodo;
    public int eggs;
    public int allEggs;

    public PlayerData(int level, bool dodo, int eggs, int allEggs)
    {
        this.level = level;
        this.dodo = dodo;
        this.eggs = eggs;
        this.allEggs = allEggs;
    }
    public override string ToString()
    {
        return $"{level}. dodo - {dodo}, {eggs} / {allEggs} ";
    }
}
