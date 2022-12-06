using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<Transform> points;
    public List<int> taked;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
    }

    public void Locate(Transform a)
    {
        int pos = -1;
        bool check_ = false;
        while (!check_)
        {
            int random = Random.Range(0, points.Count);
            int j = 0;
            for (int i = 0; i < taked.Count || taked.Count == 0; i++)
            {
                if (taked.Count == 0)
                {
                    pos = random;
                    check_ = true;
                    break;
                }
                if (taked[i] != random)
                    j++;
                else
                    break;
                if (j >= taked.Count)
                {
                    pos = random;
                    check_ = true;
                    break;
                }
            }
        }
        taked.Add(pos);
        a.position = transform.GetChild(pos).position;  
    }
}
