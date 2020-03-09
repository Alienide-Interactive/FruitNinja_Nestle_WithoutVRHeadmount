using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AnimationController : MonoBehaviour
{
    public static UI_AnimationController instance;

    private void Awake()
    {
        instance = this;
    }
    [SerializeField] Animator instructionAnimator, countDownAnimator, InGameUiAnimator, resultAnimator;



    public void AppearInstruction() {
        instructionAnimator.SetBool("Play", true);
    }
    public void AppearCountDown()
    {
        countDownAnimator.SetBool("Play", true);
    }
    public void AppearInGameUI()
    {
        InGameUiAnimator.SetBool("Play", true);
    }
    public void AppearResult()
    {

        resultAnimator.SetBool("Play", true);
    }

}
