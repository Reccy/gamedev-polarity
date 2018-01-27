using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour {

    [SerializeField] float fadeInTime = 1f;

    Image panel;

    void Awake()
    {
        panel = GetComponent<Image>();
    }

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
	}

    public void StartFadeIn(){
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn(){
        float fadeInIncrements = 20f;

        while(panel.color.a < 1f)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + (1f/fadeInIncrements));
            yield return new WaitForSecondsRealtime(fadeInTime / fadeInIncrements);
        }

        foreach (Transform child in transform){
            child.gameObject.SetActive(true);
        }

        yield return null;
    }
}
