using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

    private string checkpointKey = "CheckpointKey";

    private bool checkpointActived;
    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActived && other.gameObject.tag == "Player")
        {
            CheckCheckpoint();
        }
        
    }

    private void CheckCheckpoint()
    {
        TurnItOn();
        SaveCheckpoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_Color", Color.yellow);
        
    }

    [NaughtyAttributes.Button]
    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_Color", Color.white);
    }

    private void SaveCheckpoint()
    {
        //if (PlayerPrefs.GetInt(checkpointKey) > key)
        //{
        //    PlayerPrefs.SetInt(checkpointKey, key);
        //}

        CheckpointManager.instance.SaveCheckpoint(key);
        checkpointActived = true;
    }
}
