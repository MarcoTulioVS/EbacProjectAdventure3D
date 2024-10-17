using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using DG.Tweening;
public class EnemyPlant : EnemyBase
{

    public override void OnDamage(float dmg, bool antiChicken)
    {
        base.OnDamage(dmg, antiChicken);

        if (graphic.localScale.x > minScaleSize)
        {
            transform.DOScale(reSize, durationSize).SetEase(startAnimationEase);
            reSize -= 1;
        }

    }
}
