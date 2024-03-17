using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public string name { set; get; }
    public AudioClip source { set; get; }
    public Audio() { }
    public Audio(string name, AudioClip source)
    {
        this.name = name;
        this.source = source;
    }

}
