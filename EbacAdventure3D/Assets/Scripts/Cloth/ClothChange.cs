using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChange : MonoBehaviour
{
    public SkinnedMeshRenderer mesh;

    public Texture2D texture;

    public Texture2D defaultTexture;

    public string shaderIdName = "_EmissionMap";

    private void Start()
    {
        ApplyDefaultTexture();
    }

    [NaughtyAttributes.Button]
    private void ChangeTexture()
    {
        mesh.sharedMaterials[0].SetTexture(shaderIdName, texture);
    }

    private void ApplyDefaultTexture()
    {
        mesh.sharedMaterials[0].SetTexture(shaderIdName, defaultTexture);
    }

    
}
