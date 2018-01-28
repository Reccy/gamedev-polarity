using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    AudioSource[] audioSources;
    [SerializeField] AudioClip backgroundMusic;
    [SerializeField] AudioClip deathSound;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(PlayMusic());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayMusic(){
        audioSources[0].PlayOneShot(audioSources[0].clip);
        yield return new WaitForSeconds(audioSources[0].clip.length -0.5f);
        audioSources[0].clip = backgroundMusic;
        audioSources[0].Play();
    }

    public void PlayDeathSound(){
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine(){
        float fadeTime = 2f;
        float startTime = 0f;
        float fadeIncrements = 20f;
        float startingVolume = audioSources[0].volume;

        audioSources[1].Play();

        while (startTime < fadeTime){
            audioSources[0].volume -= 1f / fadeIncrements;
            audioSources[1].volume += 1f / fadeIncrements;
            Mathf.Clamp(audioSources[1].volume,0f,startingVolume);
            startTime += Time.deltaTime;
            yield return new WaitForSeconds(fadeTime / fadeIncrements);
        }


        yield return null;
    }

}
