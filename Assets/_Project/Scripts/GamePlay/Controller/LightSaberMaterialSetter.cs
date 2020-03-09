using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberMaterialSetter : MonoBehaviour
{
    [SerializeField] Renderer lightSaber1, lightSaber2;
    [SerializeField] Material red, blue, green;
    int Cunt;
    private void Start()
    {
        Cunt = PlayerPrefs.GetInt("Count");

        switch (Cunt) {
            case 1:
                lightSaberMaterialSetterBoth(red);
                break;
            case 2:
                lightSaberMaterialSetterBoth(blue);
                break;
            case 3:
                lightSaberMaterialSetterBoth(green);
                break;
        }
        
    }

    private void lightSaberMaterialSetterBoth(Material mat) {
        lightSaber1.material = mat;
        lightSaber2.material = mat;
    }

}
