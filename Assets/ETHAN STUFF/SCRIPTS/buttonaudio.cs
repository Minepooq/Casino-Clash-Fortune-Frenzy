using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonaudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip button;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void buttonaudioplay()
    {
        audioSource.clip = button;
        audioSource.Play();
    }
}
