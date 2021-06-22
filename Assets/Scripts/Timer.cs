using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image timerFill;
    [SerializeField]
    private float maxTime;
    private float currentTime;
    private float HowFill { get { return 1 - currentTime / maxTime; } }
    [SerializeField]
    private UnityEvent timeUpEvnet;
    private bool isStart;

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        if (isStart)
            TimeGo();
        if (HowFill <= 0)
            TimeUp();
        FillTimer();
    }

    public void TimerStart()
    {
        isStart = true;       
    }

    private void FillTimer()
    {
        timerFill.fillAmount = HowFill;
    }

    private void TimeGo()
    {
        currentTime += Time.deltaTime;
    }

    private void TimeUp()
    {
        timeUpEvnet.Invoke();
    }
}
