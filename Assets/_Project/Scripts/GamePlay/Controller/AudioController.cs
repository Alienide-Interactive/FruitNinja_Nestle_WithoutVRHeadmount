using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource singleHitSource, ComboHitSource;
    [SerializeField] AudioClip[] splashSingleHit, ComboSound;


    public void PlaySingleHit() {


            singleHitSource.PlayOneShot(splashSingleHit[Random.Range(0, splashSingleHit.Length)]);
        
    }


    public void PlayCombo()
    {

        if (!ComboHitSource.isPlaying)
        {
            ComboHitSource.PlayOneShot(ComboSound[Random.Range(0, splashSingleHit.Length)]);
        }
    }
}
