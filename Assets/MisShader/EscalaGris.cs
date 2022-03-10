using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalaGris : MonoBehaviour
{
    public Shader currentShader;
    public float grayScaleAmount;
    private Material currentMaterial;
    Material material
    {
        get
        {
            if (currentMaterial == null)
            {
                currentMaterial = new Material(currentShader);
                currentMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return currentMaterial;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
        if (!currentShader && !currentShader.isSupported)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
    {
        if (currentShader != null)
        {
            material.SetFloat("_LuminosityAmount", grayScaleAmount);
            Graphics.Blit(sourceTexture, destTexture, currentMaterial);
        }
        else
            Graphics.Blit(sourceTexture, destTexture);
    }

    private void Update()
    {
        grayScaleAmount = Mathf.Clamp(grayScaleAmount, 0.0f, 1.0f);
    }

    private void OnDisable()
    {
        if (currentMaterial)
            DestroyImmediate(currentMaterial);
    }
}
