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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.GetComponent<Health>() != null)
                other.gameObject.GetComponent<Health>().Damage(5);

            if (lightFade != null)
            {
                Instantiate(lightFade, transform.position + new Vector3(0, 0.05f, 0), Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
