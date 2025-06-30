using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;

        public string compareTag = "Player";

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            HideObject();

            var setup = ClothManager.instance.GetSetupByType(clothType);

            Player.instance.clothChange.ChangeTexture(setup);
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}

