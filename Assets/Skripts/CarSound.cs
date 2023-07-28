using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarSound : MonoBehaviour
{    
    public AudioSource Audio;
    public float Speed;
    public float AngleVector;
    
    void Start()
    {        
        Audio = GetComponent<AudioSource>();  
    }

    void Update()
    {                
        Speed = CarController.CarSpeed();
        AngleVector = CarController.CarHorizontalMove();
        float InterpolizedSpeed;

        if (Speed >= 0f && Speed < 15f)
        {
            InterpolizedSpeed = (Speed - 0) / (15 - 0);
            if (Audio.isPlaying) { Audio.pitch = Mathf.Lerp(0.7f, 1.4f, InterpolizedSpeed); }            
        }
        else if (Speed >= 15f && Speed < 25f)
        {
            InterpolizedSpeed = (Speed - 15) / (25 - 15);
            if (Audio.isPlaying) { Audio.pitch = Mathf.Lerp(0.7f, 1.4f, InterpolizedSpeed); }            
        }
        else if (Speed >= 25f && Speed < 40f)
        {
            InterpolizedSpeed = (Speed - 25) / (40 - 25);
            if (Audio.isPlaying) { Audio.pitch = Mathf.Lerp(1f, 1.5f, InterpolizedSpeed); }
        }
        else if (Speed >= 40f && Speed < 55f)
        {
            InterpolizedSpeed = (Speed - 40) / (55 - 40);
            if (Audio.isPlaying) { Audio.pitch = Mathf.Lerp(1f, 1.5f, InterpolizedSpeed); }
        }

        if (AngleVector > 8 && AngleVector < 40 && Speed > 23f) Streeching.UnmuteStreeching();
        else Streeching.MuteStreeching();               
    }
}
