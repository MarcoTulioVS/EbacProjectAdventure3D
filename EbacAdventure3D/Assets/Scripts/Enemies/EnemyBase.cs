using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;
namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamageable
    {
        [SerializeField]
        private AnimationBase _animationBase;

        public FlashColor flashColor;

        public float startLife = 10f;

        [SerializeField]
        private float _currentLife;

        [Header("Start Animation")]

        public float startAnimationDuration = 0.2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        public Collider coll;

        private void Awake()
        {
            Init();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }
        protected virtual void Init()
        {
            ResetLife();
            
            if (startWithBornAnimation)
            {
                BornAnimation();
            }
            
        }
        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            //Destroy(gameObject,3);
            if (coll != null)
            {
                coll.enabled = false;
            }
            PlayAnimationByTrigger(AnimationType.DEATH);
            Destroy(gameObject, 3);
        }

        public void OnDamage(float dmg)
        {
            if(flashColor != null)
            {
                flashColor.Flash();
            }

            _currentLife-=dmg;

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5);
            }
        }

        public void Damage(float damage)
        {
            OnDamage(damage);
        }
    }
}
