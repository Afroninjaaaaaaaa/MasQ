using System;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFace : MonoBehaviour
{
    Material[] eyesMats;
    Material[] mouthsMats;
    Material[] Skyboxes;
    AudioClip[] mouthSounds;
    Shader DefaultShader;
    MeshRenderer eyesRenderer;
    MeshRenderer mouthRenderer;
    AudioSource mouthAudio;

    private int tabIndex;
    Dictionary<string, int[]> feelings;
    
    Process myProcess;


    void Start()
    {
        eyesRenderer = gameObject.transform.GetChild(1).gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        mouthRenderer = gameObject.transform.GetChild(0).gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        mouthAudio = mouthRenderer.gameObject.AddComponent<AudioSource>() as AudioSource;

        feelings = new Dictionary<string, int[]>();
        feelings.Add("angry",    new int[3] { 0, 1, 11 });
        feelings.Add("contempt", new int[3] { 7, 8, 12 });
        feelings.Add("fear",     new int[3] { 2, 10, 2 });
        feelings.Add("happy",    new int[3] { 5, 7, 10 });
        feelings.Add("sadness",  new int[3] { 3, 8, 5 });
        feelings.Add("surprise", new int[3] { 3, 14, 6 });
        feelings.Add("disgust",  new int[3] { 1, 10, 3 });
        feelings.Add("neutral",  new int[3] { 3, 4, 0 });

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

        Skyboxes = new Material[13];
        Skyboxes[0] = Resources.Load("Materials/Skyboxes/SkyAfterNoon", typeof(Material)) as Material;
        Skyboxes[1] = Resources.Load("Materials/Skyboxes/SkyBrightMorning", typeof(Material)) as Material;
        Skyboxes[2] = Resources.Load("Materials/Skyboxes/SkyMorning", typeof(Material)) as Material;
        Skyboxes[3] = Resources.Load("Materials/Skyboxes/SkySunset", typeof(Material)) as Material;

        Skyboxes[4] = Resources.Load("Materials/Skyboxes/CartoonNight1", typeof(Material)) as Material;
        Skyboxes[5] = Resources.Load("Materials/Skyboxes/CartoonNight2", typeof(Material)) as Material;
        Skyboxes[6] = Resources.Load("Materials/Skyboxes/CartoonSunny1", typeof(Material)) as Material;
        Skyboxes[7] = Resources.Load("Materials/Skyboxes/CartoonSunny2", typeof(Material)) as Material;

        Skyboxes[8] = Resources.Load("Materials/Skyboxes/CloudyCrown_Daybreak", typeof(Material)) as Material;
        Skyboxes[9] = Resources.Load("Materials/Skyboxes/CloudyCrown_Evening", typeof(Material)) as Material;
        Skyboxes[10] = Resources.Load("Materials/Skyboxes/CloudyCrown_Midday", typeof(Material)) as Material;
        Skyboxes[11] = Resources.Load("Materials/Skyboxes/CloudyCrown_Midnight", typeof(Material)) as Material;
        Skyboxes[12] = Resources.Load("Materials/Skyboxes/CloudyCrown_Sunset", typeof(Material)) as Material;

        mouthSounds = new AudioClip[2];
        mouthSounds[0] = Resources.Load("Sounds/aaa", typeof(AudioClip)) as AudioClip;
        mouthSounds[1] = Resources.Load("Sounds/ooo", typeof(AudioClip)) as AudioClip;


        tabIndex = 0;
        eyesRenderer.material = eyesMats[tabIndex];
        eyesRenderer.material.shader = DefaultShader;
        mouthRenderer.material = mouthsMats[tabIndex];
        mouthRenderer.material.shader = DefaultShader;
        RenderSettings.skybox = Skyboxes[tabIndex];

        InitFaceDetectionScript();
    }
    
    void Update ()
    {
        int skyIndex = GetFaceInformation();
        RenderSettings.skybox = Skyboxes[skyIndex];
        //SceneTest();
    }
    
    void InitFaceDetectionScript()
    {
        string pythonPath = @"C:\WinPython-64bit-3.5.2.3Qt5\python-3.5.2.amd64\python.exe";
        string myPythonApp = @"U:\rand.py";

        // Create new process start info 
        ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(pythonPath);
        myProcessStartInfo.UseShellExecute = false;
        myProcessStartInfo.RedirectStandardOutput = true;

        // start python app with python script pointer
        myProcessStartInfo.Arguments = myPythonApp;
        myProcess = new Process();
        myProcess.StartInfo = myProcessStartInfo;
        UnityEngine.Debug.Log("Calling Python script");
        myProcess.Start();
    }

    int GetFaceInformation()
    {
        StreamReader myStreamReader = myProcess.StandardOutput;
        String res = myStreamReader.ReadLine();

        int j;
        if (Int32.TryParse(res, out j))
            return j;
        return 0;
        // wait exit signal from the app we called and then close it. 
        //myProcess.WaitForExit();
        //myProcess.Close();
    }

    void SceneTest()
    {
        if (Input.GetKeyDown("space"))
        {
            tabIndex += 1;
            eyesRenderer.material = eyesMats[tabIndex % eyesMats.Length];
            mouthRenderer.material = mouthsMats[tabIndex % mouthsMats.Length];

            RenderSettings.skybox = Skyboxes[tabIndex % Skyboxes.Length];
        }


        // Feelings test
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            eyesRenderer.material = eyesMats[feelings["angry"][0]];
            mouthRenderer.material = mouthsMats[feelings["angry"][1]];
            RenderSettings.skybox = Skyboxes[feelings["angry"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            eyesRenderer.material = eyesMats[feelings["contempt"][0]];
            mouthRenderer.material = mouthsMats[feelings["contempt"][1]];
            RenderSettings.skybox = Skyboxes[feelings["contempt"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            eyesRenderer.material = eyesMats[feelings["fear"][0]];
            mouthRenderer.material = mouthsMats[feelings["fear"][1]];
            RenderSettings.skybox = Skyboxes[feelings["fear"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            eyesRenderer.material = eyesMats[feelings["happy"][0]];
            mouthRenderer.material = mouthsMats[feelings["happy"][1]];
            RenderSettings.skybox = Skyboxes[feelings["happy"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            eyesRenderer.material = eyesMats[feelings["sadness"][0]];
            mouthRenderer.material = mouthsMats[feelings["sadness"][1]];
            RenderSettings.skybox = Skyboxes[feelings["sadness"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            eyesRenderer.material = eyesMats[feelings["surprise"][0]];
            mouthRenderer.material = mouthsMats[feelings["surprise"][1]];
            RenderSettings.skybox = Skyboxes[feelings["surprise"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            eyesRenderer.material = eyesMats[feelings["disgust"][0]];
            mouthRenderer.material = mouthsMats[feelings["disgust"][1]];
            RenderSettings.skybox = Skyboxes[feelings["disgust"][2]];
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            eyesRenderer.material = eyesMats[feelings["neutral"][0]];
            mouthRenderer.material = mouthsMats[feelings["neutral"][1]];
            RenderSettings.skybox = Skyboxes[feelings["neutral"][2]];
        }

        // voice test
        if (tabIndex % mouthsMats.Length == 3)
        {
            mouthAudio.PlayOneShot(mouthSounds[0], 0.5f);
        }
        else if (tabIndex % mouthsMats.Length == 2)
        {
            mouthAudio.PlayOneShot(mouthSounds[1], 0.5f);
        }

        GetFaceInformation();
    }
}
