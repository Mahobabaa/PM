using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour
{
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<AudioSource>().clip == audioClips[0] && !this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().clip = audioClips[1];
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<AudioSource>().loop = true;
        }
    }
}
