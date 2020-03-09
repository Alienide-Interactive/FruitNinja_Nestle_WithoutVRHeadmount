using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberOrientation : MonoBehaviour
{

    public GameObject controller;
    public bool freezZaxis;

    private Vector3 initialPositonController;
    private bool isCheckingDone;
    private Vector3 difference;




    private void Awake()
    {
        isCheckingDone = false;
        
    }

    private void Start()
    {
        initialPositonController = controller.transform.position;
        Invoke("CheckDone_invoke", 1);
    }

    public void CheckDone_invoke() {
        isCheckingDone = true;
        difference = initialPositonController - controller.transform.position;
    }
    [SerializeField] float speed = 20f;
    Quaternion lastRot;
    private void Update()
    {
        if (isCheckingDone && !freezZaxis)
        {
           

            transform.position = controller.transform.position + difference;
            transform.rotation = controller.transform.rotation;

        }
        else
        {

            transform.position = new Vector3(controller.transform.position.x,controller.transform.position.y,transform.position.z) + new Vector3(difference.x, difference.y, 0);
            Quaternion rot = controller.transform.rotation;

            float conRotAcceleration = Quaternion.Angle(lastRot, transform.rotation);
            if (Mathf.Abs(conRotAcceleration) < 0.01f)
            {
                //no movement

            }
            else
            {
                Vector3 v = new Vector3(0, 0, controller.transform.eulerAngles.x * speed * conRotAcceleration * Time.deltaTime);
                transform.Rotate(v, Space.World);
                //transform.rotation = Quaternion.Euler(controller.transform.eulerAngles.x, -90, 180);
                //Debug.Log("con eular: "+controller.transform.eulerAngles+" and saber eular: "+transform.eulerAngles);

                lastRot = transform.rotation;
            }

           
        }
    }

}
