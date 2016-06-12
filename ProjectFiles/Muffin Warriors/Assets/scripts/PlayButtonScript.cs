using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

    public GameObject playbutton;

    GameObject camera;
    CameraScript cameraScript;
    GameObject UICanvas;
    GameObject manager;


    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = camera.GetComponent<CameraScript>();
    }

    public void PlayGame()
    {
        cameraScript.Begin = true;
        UICanvas.SetActive(true);
        manager.SetActive(true);
        playbutton.SetActive(false);
    }
}
