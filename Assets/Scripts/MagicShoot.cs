using UnityEngine;

public class MagicShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefabProjectile;
    [SerializeField]
    GameObject prefabLightFade;
    [SerializeField]
    Transform shootOrigin;

    void Shoot()
    {
        GameObject projectile = Instantiate(prefabProjectile, shootOrigin.position, Quaternion.identity);
        
        
        projectile.GetComponent<Projectile>().Shoot(transform.forward + new Vector3(0,0.6f,0), 20f);

        if (prefabLightFade != null)
        {
            Instantiate(prefabLightFade, projectile.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }    
    }
}
