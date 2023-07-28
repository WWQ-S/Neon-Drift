using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streeching : MonoBehaviour
{    
    static AudioSource Slide;

    void Start()
    {
        Slide = GetComponent<AudioSource>();        
        Slide.volume = 0;
    }
    
    public static void MuteStreeching()
    {
        if (Slide.volume > 0)
        {
            Slide.volume -= Time.deltaTime * 5;
        }        
    }

    public static void UnmuteStreeching()
    {
        if (Slide.volume < 1)
        {
            Slide.volume += Time.deltaTime * 5;
        }
    }
}
