using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityBase : MonoBehaviour
{
    protected Player player;

    private void OnValidate()
    {
        if(player == null)
        {
            player = GetComponent<Player>();
        }
    }

    private void Start()
    {
        Init();
        OnValidate();
        RegisterListeners();
    }

    private void OnDestroy()
    {
        RemoveListerners();
    }

    protected virtual void Init() { }
    protected virtual void RegisterListeners() { }

    protected virtual void RemoveListerners() { }
}
