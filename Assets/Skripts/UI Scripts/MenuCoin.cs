using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuCoin : MonoBehaviour
{
        private int MenuCoins;
        public Text CoinsUI;

    [Header ("Red Button")]
        public Button RedButton;
        public Sprite RedSelect;
        public Sprite RedJust;
        public Sprite RedBuy;
    [Header("Black Button")]
        public Button BlackButton;
        public Sprite BlackSelect;
        public Sprite BlackJust;        
    [Header("Green Button")]
        public Button GreenButton;
        public Sprite GreenSelect;
        public Sprite GreenJust;
        public Sprite GreenBuy;
    [Header("Gradient Button")]
        public Button GradientButton;
        public Sprite GradientSelect;
        public Sprite GradientJust;
        public Sprite GradientBuy;

        int alreadyPressedRed;
        int alreadyPressedGreen;
        int alreadyPressedGradient;

        int coins;
        int colors;
    void Start()
    {
        Time.timeScale = 1.0f;
        alreadyPressedRed = PlayerPrefs.GetInt("alreadyPressedRed");
        alreadyPressedGreen = PlayerPrefs.GetInt("alreadyPressedGreen");
        alreadyPressedGradient = PlayerPrefs.GetInt("alreadyPressedGradient");
        coins = PlayerPrefs.GetInt("Coins");
        colors = PlayerPrefs.GetInt("Color");

        if (PlayerPrefs.HasKey("Coins"))
        {
            MenuCoins = PlayerPrefs.GetInt("Coins");
            CoinsUI.text = MenuCoins.ToString();
        }

        CarController.NumMaterial = PlayerPrefs.GetInt("Color");
        SynchronizedColor();
    }
    public void SynchronizedColor()
    {
         switch (colors)
        {
            case 0:
                BlackButton.GetComponent<Image>().sprite = BlackSelect;
                if (alreadyPressedGreen == 1) GreenButton.GetComponent<Image>().sprite = GreenJust;
                if (alreadyPressedRed == 1) RedButton.GetComponent<Image>().sprite = RedJust;
                if (alreadyPressedGradient == 1) GradientButton.GetComponent<Image>().sprite = GradientJust;
            break;
            case 1:
                GreenButton.GetComponent<Image>().sprite = GreenSelect;
                BlackButton.GetComponent<Image>().sprite = BlackJust;
                if (alreadyPressedRed == 1) RedButton.GetComponent<Image>().sprite = RedJust;
                if (alreadyPressedGradient == 1) GradientButton.GetComponent<Image>().sprite = GradientJust;
            break;
            case 2:
                RedButton.GetComponent<Image>().sprite = RedSelect;
                BlackButton.GetComponent<Image>().sprite = BlackJust;
                if (alreadyPressedGreen == 1) GreenButton.GetComponent<Image>().sprite = GreenJust;
                if (alreadyPressedGradient == 1) GradientButton.GetComponent<Image>().sprite = GradientJust;
                break;
            case 3:
                GradientButton.GetComponent<Image>().sprite = GradientSelect;
                BlackButton.GetComponent<Image>().sprite = BlackJust;
                if (alreadyPressedGreen == 1) GreenButton.GetComponent<Image>().sprite = GreenJust;
                if (alreadyPressedRed == 1) RedButton.GetComponent<Image>().sprite = RedJust;
                break;
        }
        PlayerPrefs.Save();
    }
    public void UpdateCoin()
    {
        PlayerPrefs.SetInt("Coins", coins);
        MenuCoins = PlayerPrefs.GetInt("Coins");
        CoinsUI.text = MenuCoins.ToString();
    }
    public void UpdateColor()
    {
        PlayerPrefs.SetInt("Color", colors);
        CarController.NumMaterial = PlayerPrefs.GetInt("Color");
    }
    public void SelectRed()
    {                      
        if (alreadyPressedRed == 0 && coins >= 300)
        {
            coins = coins - 300;
            UpdateCoin();
            
            alreadyPressedRed = 1;
            PlayerPrefs.SetInt("alreadyPressedRed", alreadyPressedRed);

            colors = 2;
            UpdateColor();

            SynchronizedColor();
        }
        else if(alreadyPressedRed == 1)
        {
            colors = 2;
            UpdateColor();
            SynchronizedColor();
        }
    }
    public void SelectGreen()
    {
        if (alreadyPressedGreen == 0 && coins >= 700)
        {
            coins = coins - 700;
            UpdateCoin();

            alreadyPressedGreen = 1;
            PlayerPrefs.SetInt("alreadyPressedGreen", alreadyPressedGreen);

            colors = 1;
            UpdateColor();

            SynchronizedColor();
        }
        else if (alreadyPressedGreen == 1)
        {
            colors = 1;
            UpdateColor();
            SynchronizedColor();
        }
    }
    public void SelectGradient()
    {
        if (alreadyPressedGradient == 0 && coins >= 1000)
        {
            coins = coins - 1000;
            UpdateCoin();

            alreadyPressedGradient = 1;
            PlayerPrefs.SetInt("alreadyPressedGradient", alreadyPressedGradient);

            colors = 3;
            UpdateColor();

            SynchronizedColor();
        }
        else if (alreadyPressedGradient == 1)
        {
            colors = 3;
            UpdateColor();
            SynchronizedColor();
        }
    }
    public void SelectBlack()
    {       
        colors = 0;
        UpdateColor();
        SynchronizedColor();
    }   
}
