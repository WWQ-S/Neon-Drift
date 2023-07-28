using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenColorWindow : MonoBehaviour
{
    public GameObject window;
    //public AnimationClip a;
    //public AnimationClip a;


    public void OpenWindow()
    {
        Animation Anim = window.GetComponent<Animation>();
        window.SetActive(true);
        Anim.Play("AnimOpenColorWindow");
        
    }
    public void CloseWindow()
    {
        Animation Anim = window.GetComponent<Animation>();
        Anim.Play("AnimCloseColorWindow");
        if (Anim.isPlaying == false)  window.SetActive(false);        
    }
  
}
