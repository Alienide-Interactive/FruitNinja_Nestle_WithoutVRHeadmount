using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public float splitSpeed;

    public enum FruitType {
        MangoPaka,MangoKacha,Grape,MangoPosa,MangoBeshiPocha
    }
    public FruitType currentType;

    int i; // for firstTimeCollision Only
    private void Start()
    {
        i = 0;
    }

    private void OnDisable()
    {
        i = 0;
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("sword") && i == 0) {


            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);

            // add force and rotation to sliced obj
            transform.GetChild(1).gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetChild(2).gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * splitSpeed, ForceMode.Impulse);
            transform.GetChild(2).gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * splitSpeed, ForceMode.Impulse);

            HitFX(transform.position);

            i++;
        }
    }

    private void HitFX(Vector3 pos) {

        // sound
        // effect
        // pop up message
        // bg effects
        // UI


        Vector3 RandPosition = new Vector3(Random.Range(2,  -2), Random.Range(1.2f, -1.2f), -4);

        if (currentType == FruitType.MangoPaka)
        {
            SplashTextureManager.instance.appear_Amn(RandPosition);
            VFX_Controller.instance.PlayMangoPakaFxOnPosition(pos);
            AudioController.instance.PlaySingleHit();
            UI_Controller.instance.IncreaseMangoPakaBottle();
        }
        else if(currentType == FruitType.MangoKacha)
        {
            SplashTextureManager.instance.appear_kachaAmn(RandPosition);
            VFX_Controller.instance.PlayMangoKachaFxOnPosition(pos);
            AudioController.instance.PlaySingleHit();
            UI_Controller.instance.IncreaseMangoKachaBottle();
        }
        else if (currentType == FruitType.Grape)
        {
            SplashTextureManager.instance.appear_grape(RandPosition);
            VFX_Controller.instance.PlayGrapeFxOnPosition(pos);
            AudioController.instance.PlaySingleHit();
            UI_Controller.instance.IncreaseGrapeBottle();
        }
        else if (currentType == FruitType.MangoPosa)
        {
            SplashTextureManager.instance.appear_Amn(RandPosition);
            VFX_Controller.instance.PlayMangoPosaFxOnPosition(pos);
            AudioController.instance.PlaySingleHit();
            UI_Controller.instance.DecreaseAllBottle();
        }
        else if (currentType == FruitType.MangoBeshiPocha)
        {
            SplashTextureManager.instance.appear_PochaGrape(RandPosition);
            VFX_Controller.instance.PlayMangoPosaFxOnPosition(pos);
            AudioController.instance.PlaySingleHit();
            UI_Controller.instance.DecreaseAllBottle();
        }

    }


}
