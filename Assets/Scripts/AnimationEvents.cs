using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    List<AudioClip> footstepsSounds;
   
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void FootStep()
    {
        source.PlayOneShot(footstepsSounds[Random.Range(0, footstepsSounds.Count - 1)]);
    }
}
