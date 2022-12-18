using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect_Reverse : MonoBehaviour
{
    Shader myShader;        // image effect shader 
    Material myMaterial;

    void Start()
    {
        myShader = Shader.Find("My/PostEffects/Reverse");    // image effect shader file must have been created
        myMaterial = new Material(myShader);
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
        Graphics.Blit(source, destination, myMaterial, 0);
    }
}
