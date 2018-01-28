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
    PlayerAudio playeraudio;
    
    void Awake(){
        chargingRadialImage = chargingRadialGameObject.GetComponent<Image>();
        playerCharacter = FindObjectOfType<PlayerCharacter>();
        playeraudio = GetComponent<PlayerAudio>();
    }

    private void Update()
    {
        percentageCharged = Mathf.Clamp(percentageCharged, 0, 100);
    }

    private void FixedUpdate()
    {
        if (percentageCharged < 100f)
        {
            if (playerCharacter.IsGrounded)
            {
                percentageCharged = percentageCharged + (chargingSpeed * Time.deltaTime);
                playeraudio.PlayGrounded();
            } else{
                playeraudio.StopGrounded();
            }
        }else {
            playeraudio.StopGrounded();
        }

        chargingRadialImage.fillAmount = percentageCharged / 100f;
    }
}
