using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSaved : MonoBehaviour
{
    public List<int> saved = new List<int>();
    public List<GameObject> parts = new List<GameObject>();
    [SerializeField] LevelLogic levelLogic;

    private void Awake()
    {
        SavesManger.Load(gameObject.GetComponent<SavedData>());
        saved = gameObject.GetComponent<SavedData>().parts;
        if (levelLogic.secondMode)
        {
            PartsOff();
            SavedPartsOn();
        }
    }

    void PartsOff()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            parts.Add(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < parts.Count; i++)
        {
            parts[i].SetActive(false);
        }
    }
    void SavedPartsOn()
    {
        for (int i = 0; i < saved.Count; i++)
        {
            parts[saved[i]].SetActive(true);
        }
    }
}
