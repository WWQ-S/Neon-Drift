using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CarController : MonoBehaviour
{       
    static Rigidbody rb;    

    [Header("Controls")]
        public float Forward;
        public float Steering;
        public static float Speed;
        public static float Horizontal;
        public Joystick joystick;

    [Header("Car settings")]
        public float MaxSpeed = 50f;
        public float SpeedTrottlePercent = 0.8f;
        public float EnginePower = 100f;
        public float SteerAngle = 45f;

    [Header("Car color")]
        public Renderer BodyCar;
        public Material[] material;
        public static int NumMaterial;


    [Header("Wheels")]
        public WheelCollider[] FrontWheels;
        public WheelCollider[] RearWheels;
    
        public Transform FrontRightTransfotm;
        public Transform FrontLeftTransfotm;
        public Transform RearRightTransfotm;
        public Transform RearLeftTransfotm;
        public Transform CenterOfMassTransform;

    [Header("Game over")]
        private float TimeFixate;
        private float TimeToStop = 5;

        //private Vector3 CarLocated;
        public GameOverScript GameOver;

    [Header("Coin collect")]
        public int coins;
        public Text CoinsUI;
        public AudioClip CoinsAudio;

    private bool Left = false;
    private bool Right = false;


    public void TurnLeft()
    {
        Left = true;
    }
    public void TurnLeftOff()
    {
        Left = false;
    }
    //при отпускании мыши
    public void TurnRight()
    {
        Right = true;
    }
    public void TurnRightOff()
    {
        Right = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().centerOfMass = CenterOfMassTransform.localPosition;
        TimeFixate = Time.time;
        Time.timeScale = 1.0f;
        switch (NumMaterial)
        {
            case 0:
                BodyCar.material = material[0];
                break;
            case 1:
                BodyCar.material = material[1];
                break;
            case 2:
                BodyCar.material = material[2];
                break;
            case 3:
                BodyCar.material = material[3];
                break;
        }

        if(PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
            CoinsUI.text = coins.ToString();
        }
        PlayerPrefs.Save();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            GetComponent<AudioSource>().PlayOneShot(CoinsAudio, 1);
            coins++;
            other.gameObject.SetActive(false);
            CoinsUI.text = coins.ToString();
            PlayerPrefs.SetInt("Coins", coins);
        }
    }

    void Update()
    {              
        CarSpeed();

        if (Time.time - TimeFixate > TimeToStop) 
        {                                   
            if (rb.velocity.x < 1f & rb.velocity.z < 1f)
            {
                GameOver.GameOver();
                Time.timeScale = 0;                
            }
        }
        
        if (Left)
        {

            foreach (WheelCollider FrontWheel in FrontWheels)
                FrontWheel.steerAngle = SteerAngle * -1;
        }
        else if (Right)
        {

            foreach (WheelCollider FrontWheel in FrontWheels)
                FrontWheel.steerAngle = SteerAngle;
        }
        else
        {

            foreach (WheelCollider FrontWheel in FrontWheels)
                FrontWheel.steerAngle = 0;
        }

        //Steering = Input.GetAxis("Horizontal") * Time.deltaTime * 100;



        float maxTorqueSpeed = SpeedTrottlePercent * MaxSpeed;

        float velocity = rb.velocity.magnitude;

        float addTorque = EnginePower * 1;

        if (velocity > MaxSpeed)
        {
            addTorque = 0;
        }
        else if (velocity > maxTorqueSpeed)
        {
            double normolisedLenearTorque = (MaxSpeed - velocity) / (MaxSpeed - maxTorqueSpeed);

            addTorque *= (float)Math.Pow(normolisedLenearTorque, 2);
        }
                
        foreach (WheelCollider RearWheel in RearWheels)
            RearWheel.motorTorque = addTorque;

        //foreach (WheelCollider FrontWheel in FrontWheels)
        //    FrontWheel.steerAngle = SteerAngle * Steering;       
    }        
    public static float CarSpeed()
    {
        Speed = rb.velocity.magnitude;
        return Speed;
    }
    public static float CarHorizontalMove()
    {
        float angle = Vector3.Angle(rb.velocity, rb.transform.forward);
        return angle;
    }    
   
}
