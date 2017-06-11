using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    AudioSource bgAudio;
    AudioClip bgMusic;
    AudioClip bgSound;
    public Text myGuiText;
    bool musicEnded;

    private void Start()
    {
        bgAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        bgMusic = Resources.Load("Musics/Titlescreen", typeof(AudioClip)) as AudioClip;
        bgSound = Resources.Load("Sounds/TitlescreenJingle", typeof(AudioClip)) as AudioClip;

        bgAudio.PlayOneShot(bgMusic, 0.5f);
        musicEnded = false;
    }

    void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            bgAudio.Stop();
            musicEnded = true;
            bgAudio.PlayOneShot(bgSound, 0.5f);
            myGuiText.text = "Loading...";
        }
        if(!bgAudio.isPlaying && musicEnded)
        {
            SceneManager.LoadScene("MainScene");
        }

    }
}
