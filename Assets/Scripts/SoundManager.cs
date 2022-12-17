using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }


    public AudioClip[] bgList;

    public AudioSource bgSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
            Destroy(gameObject);
    }

    /*private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bgList.Length; i++)
        {
            // 배경 오디오 이름은 씬이름과 동일하게 맞추기
            if (arg0.name == bgList[i].name)
                BgSoundPlay(bgList[i]);
        }
    }*/

    public GameObject SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject($"{sfxName} Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.volume = .5f;
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);

        return go;
    }


    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;

        //사운드 조절
        bgSound.volume = .5f;
        bgSound.Play();
    }
}
