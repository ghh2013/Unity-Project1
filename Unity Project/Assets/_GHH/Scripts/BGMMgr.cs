using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{
    public static BGMMgr Instance;
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    Dictionary<string, AudioClip> bgmTable;

    AudioSource audioMain;
    AudioSource audioSub;

    [Range(0, 1.0f)]
    public float masterVolume = 1.0f;
    float volumeMain = 0.0f;
    float volumeSub = 0.0f;
    float crossFadeTime = 5.0f;

    private void Start()
    {
        bgmTable = new Dictionary<string, AudioClip>();
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();
        audioMain.volume = 0.0f;
        audioSub.volume = 0.0f;
    }

    private void Update()
    {
        if(audioMain.isPlaying )
        {
            if(volumeMain <1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime ;
                if (volumeMain >= 1.0f) volumeMain = 1.0f;
            }
            if(volumeSub>0.0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if (volumeSub <= 0.0f)
                {
                    volumeSub = 0.0f;
                    audioSub.Stop();
                }

            }
         
        }
        audioMain.volume = volumeMain * masterVolume;
        audioSub.volume = volumeSub * masterVolume;
        
    }
    public void PlayBGM(string bgmName)
    {
        if(bgmTable.ContainsKey (bgmName )==false )
        {
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName)as AudioClip;

            if (bgm == null) return;

            bgmTable.Add(bgmName, bgm);
        }
        audioMain. clip = bgmTable[bgmName];
        audioMain.Play();

        volumeMain = 1.0f;
        volumeSub = 0.0f;

    }
    public void  CrossFadeBGM(string bgmName,float cfTime=1.0f)
    {
        if(bgmTable.ContainsKey(bgmName)==false)
        {
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            if (bgm == null) return;

            bgmTable.Add(bgmName, bgm);
        }

        crossFadeTime = cfTime;

        AudioSource temp = audioMain;
        audioMain = audioSub;
        audioSub = temp;

        float tempVolume = volumeMain;
        volumeMain = volumeSub;
        volumeSub = tempVolume;

        audioMain.clip = bgmTable[bgmName];
        audioMain.Play();
    }
    public void PauseBGM()
    {
        audioMain.Pause();
    }
    public void ResumeBGM()
    {
        audioMain.Play();
    }
}
