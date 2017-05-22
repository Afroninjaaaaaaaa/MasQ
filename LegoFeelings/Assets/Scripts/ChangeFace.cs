using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFace : MonoBehaviour
{
    Material[] eyesMats;
    Material[] mouthsMats;
    Material[] Skyboxes;
    Shader DefaultShader;
    MeshRenderer eyesRenderer;
    MeshRenderer mouthRenderer;

    private int tabIndex;


    void Start ()
    {     
        eyesRenderer = gameObject.transform.GetChild(1).gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        mouthRenderer = gameObject.transform.GetChild(0).gameObject.AddComponent<MeshRenderer>() as MeshRenderer;

        DefaultShader = Shader.Find("Sprites/Default");
        eyesMats = new Material[10];
        eyesMats[0] = Resources.Load("Materials/Eyes/angry", typeof(Material)) as Material;
        eyesMats[1] = Resources.Load("Materials/Eyes/bored", typeof(Material)) as Material;
        eyesMats[2] = Resources.Load("Materials/Eyes/closed", typeof(Material)) as Material;
        eyesMats[3] = Resources.Load("Materials/Eyes/default", typeof(Material)) as Material;
        eyesMats[4] = Resources.Load("Materials/Eyes/eyebrows", typeof(Material)) as Material;
        eyesMats[5] = Resources.Load("Materials/Eyes/happy", typeof(Material)) as Material;
        eyesMats[6] = Resources.Load("Materials/Eyes/mad", typeof(Material)) as Material;
        eyesMats[7] = Resources.Load("Materials/Eyes/sad", typeof(Material)) as Material;
        eyesMats[8] = Resources.Load("Materials/Eyes/sleep", typeof(Material)) as Material;
        eyesMats[9] = Resources.Load("Materials/Eyes/veryhappy", typeof(Material)) as Material;

        mouthsMats = new Material[16];
        mouthsMats[0] = Resources.Load("Materials/Mouths/angry", typeof(Material)) as Material;
        mouthsMats[1] = Resources.Load("Materials/Mouths/angry2", typeof(Material)) as Material;
        mouthsMats[2] = Resources.Load("Materials/Mouths/awe", typeof(Material)) as Material;
        mouthsMats[3] = Resources.Load("Materials/Mouths/awe2", typeof(Material)) as Material;
        mouthsMats[4] = Resources.Load("Materials/Mouths/default", typeof(Material)) as Material;
        mouthsMats[5] = Resources.Load("Materials/Mouths/laugh", typeof(Material)) as Material;
        mouthsMats[6] = Resources.Load("Materials/Mouths/laugh2", typeof(Material)) as Material;
        mouthsMats[7] = Resources.Load("Materials/Mouths/laugh3", typeof(Material)) as Material;
        mouthsMats[8] = Resources.Load("Materials/Mouths/meh", typeof(Material)) as Material;
        mouthsMats[9] = Resources.Load("Materials/Mouths/oh", typeof(Material)) as Material;
        mouthsMats[10] = Resources.Load("Materials/Mouths/scared", typeof(Material)) as Material;
        mouthsMats[11] = Resources.Load("Materials/Mouths/smile", typeof(Material)) as Material;
        mouthsMats[12] = Resources.Load("Materials/Mouths/smile2", typeof(Material)) as Material;
        mouthsMats[13] = Resources.Load("Materials/Mouths/smile3", typeof(Material)) as Material;
        mouthsMats[14] = Resources.Load("Materials/Mouths/surprised", typeof(Material)) as Material;
        mouthsMats[15] = Resources.Load("Materials/Mouths/teeth", typeof(Material)) as Material;

        Skyboxes = new Material[4];
        Skyboxes[0] = Resources.Load("Materials/Skyboxes/SkyAfterNoon", typeof(Material)) as Material;
        Skyboxes[1] = Resources.Load("Materials/Skyboxes/SkyBrightMorning", typeof(Material)) as Material;
        Skyboxes[2] = Resources.Load("Materials/Skyboxes/SkyMorning", typeof(Material)) as Material;
        Skyboxes[3] = Resources.Load("Materials/Skyboxes/SkySunset", typeof(Material)) as Material;


        tabIndex = 0;
        eyesRenderer.material = eyesMats[tabIndex];
        eyesRenderer.material.shader = DefaultShader;
        mouthRenderer.material = mouthsMats[tabIndex];

        mouthRenderer.material.shader = DefaultShader;

        RenderSettings.skybox = Skyboxes[tabIndex];
    }

    void Update ()
    {
        if(Input.GetKeyDown("space"))
        {
            tabIndex += 1;
            eyesRenderer.material = eyesMats[tabIndex % eyesMats.Length];
            mouthRenderer.material = mouthsMats[tabIndex % mouthsMats.Length];

            RenderSettings.skybox = Skyboxes[tabIndex % Skyboxes.Length];
        }
    }


}
