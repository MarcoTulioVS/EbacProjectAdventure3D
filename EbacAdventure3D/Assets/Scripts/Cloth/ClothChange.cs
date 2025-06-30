using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;
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

    public void ApplyDefaultTexture()
    {
        mesh.sharedMaterials[0].SetTexture(shaderIdName, defaultTexture);
    }

    public void ChangeTexture(ClothSetup setup)
    {
        mesh.sharedMaterials[0].SetTexture(shaderIdName, setup.texture);
    }
    
}
