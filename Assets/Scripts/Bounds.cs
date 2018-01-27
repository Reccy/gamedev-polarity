using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

    [SerializeField] GameObject ceiling;
    [SerializeField] GameObject floor;

	// Use this for initialization
	void Start () {
        ceiling.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height));
        floor.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
