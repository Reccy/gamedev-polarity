using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharging : MonoBehaviour {

    public bool grounded = false;
    public float percentageCharged = 100f;
    [SerializeField] float chargingSpeed = 1f;
    [SerializeField] GameObject chargingRadialGameObject;
    Image chargingRadialImage;

    Vector3 lastPointOfCollision;

    void Awake(){
        chargingRadialImage = chargingRadialGameObject.GetComponent<Image>();

    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        if (percentageCharged < 100f)
        {
            if (grounded)
            {
                percentageCharged = percentageCharged + (chargingSpeed * Time.deltaTime);
            }
        }

        chargingRadialImage.fillAmount = percentageCharged / 100f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment"){
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Environment")
        {
            grounded = false;
            lastPointOfCollision = transform.position;
        }
    }
}
