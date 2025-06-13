using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }
    public class ItemManager : Singleton<ItemManager>
    {
        public List<ItemSetup> itemSetups;

        //public SOInt coins;
        //public SOInt planets;
        private void Start()
        {
            Reset();
        }
        public void AddByType(ItemType itemType,int amount = 1)
        {
            if (amount < 0) return;
            itemSetups.Find(i=>i.itemType==itemType).soInt.value += amount;
            //UpdateUI();
        }

        public void RemoveByType(ItemType itemType,int amount = -1)
        {
            if (amount > 0) return;

            var item = itemSetups.Find(i=>i.itemType==itemType);
            item.soInt.value -= amount;

            if(item.soInt.value < 0)
            {
                item.soInt.value = 0;
            }
        }

        public void AddPlanet(int amount = 1)
        {
            //planets.value += amount;
            //UpdateUIPlanet();
        }

        private void Reset()
        {
            foreach(var i in itemSetups)
            {
                i.soInt.value = 0;
            }
        }

        [NaughtyAttributes.Button]
        private void AddCoin()
        {
            AddByType(ItemType.COIN);
        }

        [NaughtyAttributes.Button]
        private void AddLifePack()
        {
            AddByType(ItemType.LIFE_PACK);
        }

        [NaughtyAttributes.Button]
        private void RemoveCoin()
        {
            RemoveByType(ItemType.COIN);
        }

        //private void UpdateUI()
        //{
        //    UIInGameManager.instance.uiTextCoins.text = coins.value.ToString();


        //}
        //private void UpdateUIPlanet()
        //{

        //    UIInGameManager.instance.uiTextPlanets.text = planets.value.ToString();
        //}
    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
    }
}