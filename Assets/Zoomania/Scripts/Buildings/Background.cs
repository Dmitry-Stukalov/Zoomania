using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AudioSource Audio;
    void Start()
    {
        Audio.Play();
    }
}
