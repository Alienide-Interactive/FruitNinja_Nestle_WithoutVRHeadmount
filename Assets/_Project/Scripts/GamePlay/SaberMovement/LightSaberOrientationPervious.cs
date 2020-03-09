using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaberOrientationPervious : MonoBehaviour
{

    public GameObject controller;
    public bool freezZaxis;

    private Vector3 initialPositionController;
    private bool isCheckingDone;
    private Vector3 difference;

    private void Awake()
    {
        isCheckingDone = false;
    }

    private void Start()
    {
        initialPositionController = controller.transform.position;
    
        Invoke("CheckDone_invoke", 1);

    }

    public void CheckDone_invoke() {
        isCheckingDone = true;
        difference = initialPositionController - Vector3.zero;

    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CheckDone_invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckDone_invoke();
            isCheckingDone = false;
        }
        if (isCheckingDone )
        {
            transform.localPosition = new Vector3(controller.transform.position.x, controller.transform.position.y, 0) - new Vector3(difference.x, difference.y, 0);
            transform.localRotation = Quaternion.Euler(controller.transform.localRotation.eulerAngles.x, controller.transform.localRotation.eulerAngles.y, -90f);
        }

        else {
            transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, 0) + new Vector3(difference.x, difference.y, 0);
            transform.localRotation = Quaternion.Euler(controller.transform.eulerAngles.x, controller.transform.eulerAngles.y, 0 );
        }
    }

}
