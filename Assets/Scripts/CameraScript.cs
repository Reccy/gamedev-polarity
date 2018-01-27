using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float movementSpeed = 10f;
    public float movementSpeedMod = 2f;
    [HideInInspector] public Vector3 cameraLeftToWorldPoint;
    public bool gameHasStarted = false;
    Camera mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (gameHasStarted && FindObjectOfType<PlayerCharacter>() != null)
        {
            Vector2 playerPos = Camera.main.WorldToViewportPoint(FindObjectOfType<PlayerCharacter>().transform.position);
            float mod = (playerPos.x - 0.5f) * 2 * movementSpeedMod;

            transform.position += new Vector3((movementSpeed + mod) * Time.deltaTime, 0f, 0f);
            cameraLeftToWorldPoint = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));  
        }
    }

}
