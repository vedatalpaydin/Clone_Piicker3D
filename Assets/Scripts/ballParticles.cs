using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem ballParticle;
    [SerializeField] private AudioClip ballClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void BallParticlePlay()
    {
        var vfx = Instantiate(ballParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.PlayOneShot(ballClip);
    }
}
