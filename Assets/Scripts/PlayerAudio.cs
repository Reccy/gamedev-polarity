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
        audioSources[1].Stop();
        alreadyPlayingGrounded = false;
    }

    public void PlayPolaritySound()
    {
        audioSources[2].PlayOneShot(audioSources[2].clip);

    }

    public void PlayFailSound(){
        audioSources[3].PlayOneShot(audioSources[3].clip);

    }
}
