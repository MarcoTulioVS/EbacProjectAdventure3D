using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;

    public float timeBetweenShoot = 0.3f;

    private Coroutine _currentCoroutine;

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        
    }

    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine("ShootCoroutine");
    }

    public void StopShoot()
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }
}
