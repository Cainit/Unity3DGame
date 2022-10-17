using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject lightFade;

    public void Shoot(Vector3 direction, float power)
    {
        GetComponent<Rigidbody>().AddForce(direction*power, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (lightFade != null)
            {
                Instantiate(lightFade, transform.position + new Vector3(0, 0.05f, 0), Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
