using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReversePolarity : MonoBehaviour {

    GameObject environment;
    PlayerCharging playerCharging;

    [SerializeField] int chargeCost = 100;

    // Use this for initialization
    private void Awake()
    {
        environment = GameObject.FindWithTag("Environment");
        playerCharging = GetComponent<PlayerCharging>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && playerCharging.percentageCharged >= chargeCost)
        {
            ReversePolarity();
        }
    }

    public void ReversePolarity()
    {
        playerCharging.percentageCharged -= chargeCost;
        Vector3 reversedScale = new Vector3(environment.transform.localScale.x, -environment.transform.localScale.y, 1f);
        environment.transform.localScale = reversedScale;

        Vector3 playerReversedPosition = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        transform.position = playerReversedPosition;


    }
}
