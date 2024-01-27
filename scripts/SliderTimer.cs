using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider slider;
    public float duration = 15f;

    private float timeElapsed;
    private bool isTimerRunning = false; // 添加的控制变量

    void Update()
    {
        if (isTimerRunning && timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            slider.value = 1 - (timeElapsed / duration);
        }
    }

    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            isTimerRunning = true;
            timeElapsed = 0; // 重置计时器
            slider.value = 1; // 重置滑块的值
        }
    }

    public bool IsTimerRunning()
    {
        return isTimerRunning;
    }

    public bool IsTimerFinished()
    {
        return timeElapsed >= duration;
    }
}
