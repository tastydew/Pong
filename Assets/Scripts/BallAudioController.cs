using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController : MonoBehaviour
{

    private AudioSource ballSoundSouce;
    public AudioClip wallHitSound;
    public AudioClip paddleHitSound;

    // Use this for initialization
    void Awake()
    {
        ballSoundSouce = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            ballSoundSouce.clip = wallHitSound;
            ballSoundSouce.Play();
        }

        if (collision.collider.tag == "Player")
        {
            ballSoundSouce.clip = paddleHitSound;
            ballSoundSouce.Play();
        }
    }

}
