using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    [SerializeField] AudioClip[] audioClips;
    //List<AudioSource>

    bool alreadyPlayingGrounded = false;

    private void Awake()
    {
        foreach (AudioClip clip in audioClips){
            gameObject.AddComponent<AudioSource>();

        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayJumpSound(){
        //audioSource.PlayOneShot(jump);
    }

    public void PlayGrounded()
    {
        if (!alreadyPlayingGrounded)
        {
            //audioSource.loop = true;
            //audioSource.PlayOneShot(grounded);
            //alreadyPlayingGrounded = true;
        }
    }

    public void StopGrounded()
    {
        //audioSource.Stop();
    }
}
