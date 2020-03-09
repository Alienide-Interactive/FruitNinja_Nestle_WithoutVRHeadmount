using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_Controller : MonoBehaviour
{
    public static VFX_Controller instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject MangoPakaVFX, MangoKachaVFX, MangoPochaVFX,GrapeVfx;

    private ParticleSystem MangoPakaParticle, MangoKachaParticle, MangoPosaParticle, GrapeParticle;

    private void Start()
    {
        MangoPakaParticle = MangoPakaVFX.GetComponent<ParticleSystem>();
        MangoKachaParticle = MangoKachaVFX.GetComponent<ParticleSystem>();
        MangoPosaParticle = MangoPochaVFX.GetComponent<ParticleSystem>();
        GrapeParticle = GrapeVfx.GetComponent<ParticleSystem>();
    }

    public void PlayMangoPakaFxOnPosition(Vector3 position) {

        MangoPakaVFX.transform.position = position;
        MangoPakaParticle.Play();
    }

    public void PlayMangoKachaFxOnPosition(Vector3 position)
    {

        MangoKachaVFX.transform.position = position;
        MangoKachaParticle.Play();
    }
    public void PlayGrapeFxOnPosition(Vector3 position)
    {

        GrapeVfx.transform.position = position;
        GrapeParticle.Play();
    }
   
    public void PlayMangoPosaFxOnPosition(Vector3 position)
    {

        MangoPochaVFX.transform.position = position;
        MangoPosaParticle.Play();
    }
}
