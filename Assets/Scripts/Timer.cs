using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timer = 59f;
    [SerializeField] LevelLogic logic;
    private Text counterText;
    private int minute, seconds, miliseconds;

    #region singleton
    public static Timer timerInstance;

    private void Awake()
    {
        timerInstance = this;
    }

    #endregion

    void Start()
    {
        counterText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        Counter();
    }

    private void Counter()
    {
        minute = (int)timer / 60;
        seconds = (int)timer % 60;
        miliseconds = (int)(timer * 1000)%1000;
        counterText.text = seconds.ToString("00") + " , " + miliseconds.ToString("00");
   
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            logic.lose = true;
        }
    }

    public void AddSecondsToTimer(float seconds)
    {
        timer += seconds;
        Debug.Log("Añadi tiempo");
    }
}
