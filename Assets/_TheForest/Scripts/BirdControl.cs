using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    // AudioSource
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;

    private AudioSource birdAudioSource1;
    private AudioSource birdAudioSource2;
    private AudioSource birdAudioSource3;

    // Start is called before the first frame update
    void Start()
    {
        birdAudioSource1 = tree1.GetComponent<AudioSource>();
        birdAudioSource2 = tree2.GetComponent<AudioSource>();
        birdAudioSource3 = tree3.GetComponent<AudioSource>();

        InvokeRepeating("PlaySound1", 1, Random.Range(3, 5));
        InvokeRepeating("PlaySound2", 3, Random.Range(3, 5));
        InvokeRepeating("PlaySound3", 5, Random.Range(3, 5));
    }

    void PlaySound1()
    {
        birdAudioSource1.Play();
    }

    void PlaySound2()
    {
        birdAudioSource2.Play();
    }

    void PlaySound3()
    {
        birdAudioSource3.Play();
    }
}
