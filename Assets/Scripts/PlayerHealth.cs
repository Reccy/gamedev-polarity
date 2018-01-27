using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    AudioSource audioSource;
    DeathPanel deathPanel;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        deathPanel = FindObjectOfType<DeathPanel>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death(){
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        //TODO change death sound;
        audioSource.PlayOneShot(audioSource.clip);

        deathPanel.gameObject.SetActive(true);
        deathPanel.StartFadeIn();

        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds")
        {
            Death();
        }
            
    }
}
