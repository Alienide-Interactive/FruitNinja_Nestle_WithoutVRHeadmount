using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTextureManager : MonoBehaviour
{
    public static SplashTextureManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject amn, grape, kachaAmn, PochaGrape;

    public void appear_Amn(Vector3 pos) {
        amn.transform.position = pos;
        amn.SetActive(true);
        Invoke("AmnOff",1.25f);
    }
    public void appear_grape(Vector3 pos) {
        grape.transform.position = pos;
        grape.SetActive(true);
        Invoke("GrapeOff",1.25f);
    }
    public void appear_kachaAmn(Vector3 pos) {
        kachaAmn.transform.position = pos;
        kachaAmn.SetActive(true);
        Invoke("KachaAmnOff", 1.25f);
    }
    public void appear_PochaGrape(Vector3 pos) {
        PochaGrape.transform.position = pos;
        PochaGrape.SetActive(true);
        Invoke("PochaGrapeOff", 1.25f);
    }

    private void AmnOff() {
        amn.SetActive(false);
    }
    private void GrapeOff() {
        grape.SetActive(false);
    }
    private void KachaAmnOff() {
        kachaAmn.SetActive(false);
    }
    private void PochaGrapeOff() {
        PochaGrape.SetActive(false);
    }

}
