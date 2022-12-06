using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinNLose : MonoBehaviour
{
    enum WinOrLose{ Lose, Win }
    [SerializeField] WinOrLose winOrLose;
    LevelLogic levelLogic;

    private void Start()
    {
        levelLogic = GameObject.FindGameObjectWithTag("Base").GetComponent<LevelLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            switch (winOrLose)
            {
                case WinOrLose.Lose:
                    levelLogic.state = LevelLogic.LevelState.Lose;
                    break;
                case WinOrLose.Win:
                    levelLogic.state = LevelLogic.LevelState.Win;
                    break;
            }
        }
    }
}
