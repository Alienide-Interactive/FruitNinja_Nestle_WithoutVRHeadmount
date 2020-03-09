using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Material Red, Blue, Green;
    [SerializeField] Renderer lightSaber1, lightSaber2;

    int count;

    private void Start()
    {
        lightSaber1.material = Red;
        count = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("GamePlay");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            ChangeMaterialLeft(); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            ChangeMaterialRight();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void ChangeMaterialRight() {
        count++;
        if (count == 4) {
            count = 1;
        }
        PlayerPrefs.SetInt("Count", count);
        switch (count)
        {
            case 1:
                ChangeBothSaberMaterials(Red);
                break;
            case 2:
                ChangeBothSaberMaterials(Blue);
                break;
            case 3:
                ChangeBothSaberMaterials(Green);
                break;
        }
    }
    
    public void ChangeMaterialLeft() {
        count--;
        if (count == 0) {
            count = 3;
           
        }
        PlayerPrefs.SetInt("Count", count);
        switch (count)
        {
            case 1:
                ChangeBothSaberMaterials(Red);
                break;
            case 2:
                ChangeBothSaberMaterials(Blue);
                break;
            case 3:
                ChangeBothSaberMaterials(Green);
                break;
        }
    }

    private void ChangeBothSaberMaterials(Material mat) {
        lightSaber1.material = mat;
        lightSaber2.material = mat;
    }

}
