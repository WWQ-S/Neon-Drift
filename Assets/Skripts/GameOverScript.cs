using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public GameObject GameOverImage;
    public void GameOver()
    {                  
            GameOverImage.SetActive (true);         
    }
}
