using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]

    public GameObject notification;
    public float tweenDuration = 0.2f;
    public Ease ease = Ease.OutBack;
    private float startScale;

    private void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification();
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
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale,tweenDuration);
    }

    [NaughtyAttributes.Button]
    public void HideNotification()
    {
        notification.SetActive(false);
    }
}
