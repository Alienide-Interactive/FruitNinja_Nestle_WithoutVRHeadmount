using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public static ObjectThrower instance;
    private void Awake()
    {
        instance = this;
    }
    public float launchTime, intervalTime;

    public GameObject[] Spawners;
    public float torqueSpeed;
    public float speed;


    private IEnumerator holder;
    private void Start()
    {
        holder = LaunchObject(launchTime);
    }

    public void StartLaucngObjects()
    {
        StartCoroutine(holder);
    }

    IEnumerator LaunchObject(float time) {
        yield return new WaitForSeconds(time);
        GameObject randomSpawner = Spawners[Random.Range(0, Spawners.Length)];
        Vector3 direction = randomSpawner.transform.GetChild(0).transform.position - randomSpawner.transform.position;

        GameObject go = MangoPool.instance.GetPooledObject();
        if (go != null)
        {
            go.transform.position = randomSpawner.transform.position;
            go.transform.rotation = randomSpawner.transform.rotation;
            go.SetActive(true);

            go.GetComponent<Rigidbody>().isKinematic = false;
            go.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            go.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 5, 50) * torqueSpeed, ForceMode.Impulse);
        }

        StartCoroutine(LaunchObject(Random.Range(.5f,intervalTime)));
    }


    public void StopObjectThrow() {
        StopAllCoroutines();
    }

}


