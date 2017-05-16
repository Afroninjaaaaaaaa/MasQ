using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MonoBehaviour
{
    Material DefaultFaceMat;
    Texture DefaultFaceTex;
    Shader DefaultShader;

    void Start ()
    {
        DefaultFaceMat = Resources.Load("Materials/FaceAngry.mat", typeof(Material)) as Material;
        DefaultFaceTex = Resources.Load("Textures/angry.png", typeof(Texture)) as Texture;
        MeshRenderer faceRenderer  = gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        DefaultShader = Shader.Find("Sprites/Default");

        //faceRenderer.material.mainTexture = DefaultFaceTex;
        GetComponent<Renderer>().material.SetTexture("_MainTex", DefaultFaceTex);
        faceRenderer.material.shader = DefaultShader;

    }

    void Update ()
    {
        //GetComponent<Renderer>().material = newFace;
    }
}
