using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float movementSpeed = 10f;
    [HideInInspector] public Vector3 cameraLeftToWorldPoint;
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
        
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0f,0f);
        cameraLeftToWorldPoint = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
    }


}
