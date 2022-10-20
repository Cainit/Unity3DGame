using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> footstepsSounds;
    AudioClip shootSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void PlayFootStep()
    {
        source.PlayOneShot(footstepsSounds[Random.Range(0, footstepsSounds.Count - 1)]);
    }

    void PlayShoot()
    {
        source.PlayOneShot(shootSound);
    }
}
