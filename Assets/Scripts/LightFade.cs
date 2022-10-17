using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    [SerializeField]
    float fadeSpeed = 4;
    Light light;

    void Awake()
    {
        light = GetComponent<Light>();
        StartCoroutine(Fade()); 
    }

    IEnumerator Fade()
    {
        while(light.intensity > 0)
        {
            light.intensity -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
