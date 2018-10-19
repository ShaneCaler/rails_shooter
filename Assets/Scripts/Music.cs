using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    [SerializeField] AudioClip background;
    AudioSource audioSource;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<Music>().Length;
        if (numMusicPlayers > 1)
        { Destroy(gameObject); }
        else
        { DontDestroyOnLoad(this.gameObject); }
    }
    // Use this for initialization
    void Start () {
		audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(background);
    }
	
}
