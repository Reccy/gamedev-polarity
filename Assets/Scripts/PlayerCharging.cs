using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharging : MonoBehaviour {

    private PlayerCharacter playerCharacter;
    public float percentageCharged = 100f;
    [SerializeField] float chargingSpeed = 1f;
    [SerializeField] GameObject chargingRadialGameObject;
    Image chargingRadialImage;
    
    void Awake(){
        chargingRadialImage = chargingRadialGameObject.GetComponent<Image>();
        playerCharacter = FindObjectOfType<PlayerCharacter>();
    }
    
    private void FixedUpdate()
    {
        if (percentageCharged < 100f)
        {
            if (playerCharacter.IsGrounded)
            {
                percentageCharged = percentageCharged + (chargingSpeed * Time.deltaTime);
            }
        }

        chargingRadialImage.fillAmount = percentageCharged / 100f;
    }
}
