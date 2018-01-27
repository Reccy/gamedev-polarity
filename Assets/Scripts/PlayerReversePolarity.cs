using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReversePolarity : MonoBehaviour {

    GameObject environment;
    PlayerCharging playerCharging;

    [SerializeField] public int chargeCost = 100;

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
            StartCoroutine(ReversePolarity());
        }
    }

    IEnumerator ReversePolarity()
    {
        playerCharging.percentageCharged -= chargeCost;
        while(Time.timeScale > 0.1f)
        {
            Time.timeScale = (Time.timeScale - 0.2f);
            yield return new WaitForSecondsRealtime(0.1f);
        }

        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);

        Vector3 reversedScale = new Vector3(environment.transform.localScale.x, -environment.transform.localScale.y, 1f);
        environment.transform.localScale = reversedScale;

        Vector3 playerReversedPosition = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        transform.position = playerReversedPosition;

        yield return new WaitForSecondsRealtime(0.1f);

        while (Time.timeScale < 0.9f)
        {
            Time.timeScale = (Time.timeScale + 0.2f);
            yield return new WaitForSecondsRealtime(0.1f);
        }

        Time.timeScale = 1f;



        yield return null;
    }
}
