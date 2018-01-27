using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour {

    CameraScript cameraScript;

    private void Awake()
    {
        cameraScript = FindObjectOfType<CameraScript>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame(){
        cameraScript.gameHasStarted = true;

        gameObject.SetActive(false);
    }
}
