using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    AudioSource[] audioSources;

    bool alreadyPlayingGrounded = false;

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(audioSources[0].isPlaying); 
	}

    public void PlayJumpSound()
    {
        audioSources[0].PlayOneShot(audioSources[0].clip);
    }

    public void PlayGrounded()
    {
        if (!alreadyPlayingGrounded)
        {
            audioSources[1].Play();
            alreadyPlayingGrounded = true;
        }
    }

    public void StopGrounded()
    {
        audioSources[0].Stop();
    }


}
