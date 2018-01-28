using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    DeathPanel deathPanel;
    Music musicController;

    void Awake()
    {
        deathPanel = FindObjectOfType<DeathPanel>();
        musicController = FindObjectOfType<Music>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Death(){
        musicController.PlayDeathSound();
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
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
