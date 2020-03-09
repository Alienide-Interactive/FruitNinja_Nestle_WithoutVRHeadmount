using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("MangoPaka"))
        {
          
            ResetFruits(other.gameObject, new Vector3(-0.5006191f, -0.8289245f, 0.04559683f), new Vector3(-0.5006191f, -0.8289245f, 0.04559745f));

        }
        else if (other.CompareTag("MangoKacha")) {
         
            ResetFruits(other.gameObject, new Vector3(-0.6691473f, -0.3927605f, 0.005531055f), new Vector3(-0.6691472f, -0.3927605f, 0.005531055f));
        }
        else if (other.CompareTag("MangoPocha")) {
        
            ResetFruits(other.gameObject, new Vector3(-0.0194714f, -0.7614011f, 0.01190288f), new Vector3(-0.0194712f, -0.7614002f, 0.01190288f));
        }
        else if (other.CompareTag("MangoBeshiPocha")) {
           
            ResetFruits(other.gameObject, new Vector3(0.3005994f, -1.452705f, 0.04275314f), new Vector3(0.3006018f, -1.452704f, 0.04275345f));
        }
        else if (other.CompareTag("Grape")) {
           
            ResetFruits(other.gameObject, new Vector3(-2.160299f, -1.277728f, 1.460419f), new Vector3(-2.160299f, -1.277728f, 1.46042f));
        }


    }


    private void ResetFruits(GameObject other, Vector3 one, Vector3 two)
    {
        other.transform.GetChild(0).gameObject.SetActive(true);
        other.transform.GetChild(1).gameObject.SetActive(false);
        other.transform.GetChild(1).transform.localPosition = one;

        other.transform.GetChild(2).gameObject.SetActive(false);
        other.transform.GetChild(2).transform.localPosition = two;

        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        other.gameObject.SetActive(false);
    }

}
