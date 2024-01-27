using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator characterAnimator;
    public SliderTimer sliderTimer;
    private bool itemReceived = false;

    void Update()
    {
        // 检查计时器是否结束且没有收到物品
        if (!itemReceived && sliderTimer.IsTimerFinished())
        {
            characterAnimator.SetTrigger("student_cry_walkaway");
        }
    }

    public void ReceiveItem(GameObject item)
    {
        itemReceived = true; // 标记已收到物品

        if (item.tag == "potion")
        {
            characterAnimator.SetTrigger("student_laugh_walkaway");
        }
        else
        {
            characterAnimator.SetTrigger("student_cry_walkaway");
        }
    }
}
