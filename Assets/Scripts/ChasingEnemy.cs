using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height /2));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector2(0f, Screen.height / 2));
	}
}
