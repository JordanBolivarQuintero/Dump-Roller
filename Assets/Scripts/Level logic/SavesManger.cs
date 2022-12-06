using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavesManger 
{
    public static void Save(MonoBehaviour x)
    {
        PlayerPrefs.SetString("Slot", JsonUtility.ToJson(x));
        Debug.Log(JsonUtility.ToJson(x));
    }
    public static void Load(MonoBehaviour x)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Slot"), x);
    }
}
