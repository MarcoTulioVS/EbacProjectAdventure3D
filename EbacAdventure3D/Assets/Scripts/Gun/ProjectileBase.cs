using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    
    public float timeToDestroy = 2f;

    public float speed = 50f;

    public float damageAmount;

    [SerializeField]
    private bool antiChicken;
    private void Awake()
    {
        Destroy(gameObject,timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.Damage(damageAmount,antiChicken);
        }
        
        Destroy(gameObject);
    }

}
