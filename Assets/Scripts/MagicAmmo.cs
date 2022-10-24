using System.Collections;
using UnityEngine;

public class MagicAmmo : MonoBehaviour
{
    [SerializeField]
    GameObject prefabLightFade;

    bool upped;
    

    void OnTriggerEnter(Collider other)
    {
        if (upped)
            return;

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<MagicShoot>() != null)
                other.gameObject.GetComponent<MagicShoot>().AddShoots(5);

            GetComponent<Light>().enabled = false;

            StartCoroutine(GetUp());
        }
    }

    IEnumerator GetUp()
    {
        upped = true;

        if (prefabLightFade != null)
        {
            Instantiate(prefabLightFade, transform.position, Quaternion.identity);
        }

        
        Vector3 startScale = transform.localScale;
        float timer = 0;

        while(transform.localScale.x > 0)
        {
            timer += 1.0f * Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, timer);
            yield return null;
        }

        Destroy(this.gameObject);
    }
}
