using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using DG.Tweening;
public class EnemyChicken : EnemyBase
{
    public override void OnDamage(float dmg, bool antiChicken)
    {
        base.OnDamage(dmg, antiChicken);

        if (transform.localScale.x < 5)
        {
            
            transform.DOScale(reSize, durationSize).SetEase(startAnimationEase);
            reSize += 1;

        }

    }
}
