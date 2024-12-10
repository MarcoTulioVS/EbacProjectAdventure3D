using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthBase : MonoBehaviour
{
    public float startLife = 10f;
    public bool destroyOnKill;

    [SerializeField]
    private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        ResetLife();
    }
    protected void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, 3f);
        }
        OnKill?.Invoke(this);
    }

    public virtual void Damage(float dmg)
    {
       

        //transform.position -= transform.forward;

        _currentLife -= dmg;

        if (_currentLife <= 0)
        {
            Kill();
        }

        OnDamage?.Invoke(this);
    }

    //Debug
    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }
}
