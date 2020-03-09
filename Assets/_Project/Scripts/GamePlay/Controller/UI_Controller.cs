using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public static UI_Controller instance;

    public float IncreaseValueForBottle, DecreaseValueForBottle;
    public float WinValue;
    public bool isWin;
    private void Awake()
    {
        instance = this;
        isWin = false;
    }

    [SerializeField] Image GrapeBottle, MangoPakaBottle, MangoKachaBottle;

    public void IncreaseGrapeBottle() {
        IncreaseImageSlider(GrapeBottle, IncreaseValueForBottle);
        CheckBottleFull();
    }
    public void IncreaseMangoPakaBottle() {
        IncreaseImageSlider(MangoPakaBottle, IncreaseValueForBottle);
        CheckBottleFull();
    }
    public void IncreaseMangoKachaBottle() {
        IncreaseImageSlider(MangoKachaBottle, IncreaseValueForBottle);
        CheckBottleFull();
    }


    private void CheckBottleFull() {
        if (MangoPakaBottle.fillAmount == 1 && MangoKachaBottle.fillAmount == 1 && GrapeBottle.fillAmount == 1) {
       
            isWin = true;

            GameStateManager.instance.OnGameResultState();
        }


    }



    public void DecreaseAllBottle() {
        DecreaseImageSlider(GrapeBottle, DecreaseValueForBottle);
        DecreaseImageSlider(MangoPakaBottle, DecreaseValueForBottle);
        DecreaseImageSlider(MangoKachaBottle, DecreaseValueForBottle);
    }

    private void IncreaseImageSlider(Image img, float FillAmount) {
        if (img.fillAmount <= 1) 
        img.fillAmount = img.fillAmount + FillAmount;
    }

    private void DecreaseImageSlider(Image img, float FillAmount)
    {
        if (img.fillAmount >= 0)
            img.fillAmount = img.fillAmount - FillAmount;
    }
}
