using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAudio : MonoBehaviour
{
    public static RunAudio instance;
    private List<Audio> audioList = new List<Audio>(); 
    [SerializeField] List<string> nameList;
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    private void Awake()
    {
       
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < nameList.Count; i++)
        {
            Audio a = new Audio(nameList[i], audioClips[i]);
           
            audioList.Add(a);
        }
        PlayBGM("BGM");
    }
    public void PlayBGM(string name)
    {
        AudioClip src = FindAudio(name,audioList);
        if (src==null||bgm==null)
        {
            return;
        }
        bgm.clip = src;
        bgm.Play();
    }
    public void PlaySound(string name)
    {
        AudioClip src = FindAudio(name, audioList);
        Debug.Log(src + " loi");
        if (src == null||sfx==null)
        {
            return;
        }
        sfx.PlayOneShot(src);
    }
    public AudioClip FindAudio(string name,List<Audio> audioList )
    {
        Debug.Log(audioList[2] + " okem ");
        foreach (Audio a in audioList)
        {
           
            if (name.Trim().ToLower().Equals(a.name.Trim().ToLower()))
            { 
               
                return a.source;
            }
        }
        return null;
    }
    public void StopSound()
    {
        sfx.Stop();
    }
}
