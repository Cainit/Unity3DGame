using UnityEngine;

public class MagicShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefabProjectile;
    [SerializeField]
    GameObject prefabLightFade;
    [SerializeField]
    Transform shootOrigin;
    [SerializeField]
    AudioClip shootSound;

    void Shoot()
    {
        GameObject projectile = Instantiate(prefabProjectile, shootOrigin.position, Quaternion.identity);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2500))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(hit.point);
            Vector3 dir = hit.point - transform.position;

            projectile.GetComponent<Projectile>().Shoot(dir.normalized, 30f);

            if (prefabLightFade != null)
            {
                Instantiate(prefabLightFade, projectile.transform.position, Quaternion.identity);
            }

            GetComponent<AudioSource>().PlayOneShot(shootSound);
        }

        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetTrigger("Shoot");
        }    
    }
}
