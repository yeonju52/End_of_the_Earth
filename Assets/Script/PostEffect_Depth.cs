using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect_Depth : MonoBehaviour
{
    Shader myShader;        // image effect shader 
    Material myMaterial;

    public float depth = 10.0f;

    void Start()
    {
        myShader = Shader.Find("My/PostEffects/Depth");    // image effect shader file must have been created
        myMaterial = new Material(myShader);
    }

    private void Update()
    {
        depth = Mathf.Clamp(depth, 0.0f, 10.0f);
    }

    private void OnDisable()
    {
        if (myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Depth", depth);
        Graphics.Blit(source, destination, myMaterial);
    }
}
