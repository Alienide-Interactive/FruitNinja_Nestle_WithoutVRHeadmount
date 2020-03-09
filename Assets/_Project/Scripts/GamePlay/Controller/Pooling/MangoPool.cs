using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangoPool : MonoBehaviour
{
    public static MangoPool instance;

    public GameObject[] objectToPool;
    public int amountToPool;
    private List<GameObject> pooledObject; 


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pooledObject = new List<GameObject>();

        for (int j = 0; j<objectToPool.Length;j++)
        {
            for (int i = 0; i < amountToPool; i++)
            {

                GameObject obj = Instantiate(objectToPool[j]);
                obj.GetComponent<Rigidbody>().isKinematic = true;
                obj.SetActive(false);
                pooledObject.Add(obj);

            }
        }
       
    }

    public GameObject GetPooledObject() {

        for (int i = 0; i < pooledObject.Count; i++) {

            if (!pooledObject[i].activeInHierarchy) {
                return pooledObject[i];
            }
        }
        return null;
    }
}
