using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";

    public GameObject notification;
    private void Start()
    {
        
    }

    [NaughtyAttributes.Button]
    public void OpenChest()
    {
        animator.SetTrigger(triggerOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            HideNotification();
        }
    }

    [NaughtyAttributes.Button]
    public void ShowNotification()
    {
        notification.SetActive(true);
    }

    [NaughtyAttributes.Button]
    public void HideNotification()
    {
        notification.SetActive(false);
    }
}
