using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateWatcher : MonoBehaviour
{
    public Animator npcAnimator;
    public SliderTimer sliderTimer;

    // 要监视的动画状态名称
    private string[] waitingAnimations = { "student_cry_and_waiting", "bluetie_cry_and_waiting", "senior_cry_and_waiting" };

    void Update()
    {
        foreach (var animName in waitingAnimations)
        {
            if (npcAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName) && !sliderTimer.IsTimerRunning())
            {
                sliderTimer.StartTimer();
                break; // 找到一个匹配的动画，就开始倒计时并跳出循环
            }
        }
    }
}
