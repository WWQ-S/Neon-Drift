using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;

public class TileSpawner : MonoBehaviour
{
    public ChankForward[] ChankForward;
    public ChankLeft[] ChankLeft;
    public ChankRight[] ChankRight;    
    private List<Object> SpawnedChanks = new List<Object>();

    public GameObject referenceObject;
    public GameObject StartChunk;
    public GameObject StartChunk2;    
    
    private float distanceBetweenTiles = 200F;
    public Vector3 previousTilePosition;
    public Vector3 direction = new Vector3(0, 0, 1),
                    mainDirection = new Vector3(0, 0, 1),
                    otherDirection = new Vector3(1, 0, 0);
    public GameObject Car;
        
    int countSpawn;
    public float randomValue = 1.5f;
    int counter = 2;
    
    void Start()
    {        
        previousTilePosition = referenceObject.transform.position;
        SpawnedChanks.Add(referenceObject);                
    }
   
    void Update()
    {        
        countSpawn++;
        if (countSpawn == 5000)
        {
            Destroy(StartChunk);
            Destroy(StartChunk2);
        }
        var lastItem = SpawnedChanks.Last();
        if (Vector3.Distance(Car.transform.position, lastItem.GameObject().transform.position) <= 200)
        {
            float rnd = Random.Range(0f, 10f);            
            if (rnd < randomValue) counter++;
            if (rnd > randomValue)
            {
                if (counter % 2 == 0)
                {
                    SpawnForward(0, ChankForward);
                }
                else SpawnForward(90, ChankForward);
            }

            else
            {
                if (counter % 2 == 0)
                {
                    SpawnLeft(0, ChankLeft);
                }
                else SpawnRight(0, ChankRight);

                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }                       
        }
        
        if (Vector3.Distance(Car.transform.position, SpawnedChanks[0].GameObject().transform.position) >= 400)        {

            Destroy(SpawnedChanks[0].GameObject());
            SpawnedChanks.RemoveAt(0);            
        }
    }

    public void SpawnForward(int a, ChankForward[] ChankForward)
    {
        direction = mainDirection;
        Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
        ChankForward newChank = Instantiate(ChankForward[Random.Range(0, 12)], spawnPos, Quaternion.Euler(0, a, 0));
        SpawnedChanks.Add(newChank);
        previousTilePosition = spawnPos;              
    }
    public void SpawnLeft(int a, ChankLeft[] ChankLeft)
    {
        Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
        ChankLeft newChank = Instantiate(ChankLeft[Random.Range(0, 9)], spawnPos, Quaternion.Euler(0, a, 0));
        SpawnedChanks.Add(newChank);
        previousTilePosition = spawnPos;           
    }
    public void SpawnRight(int a, ChankRight[] ChankRight)
    {
        Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
        ChankRight newChank = Instantiate(ChankRight[Random.Range(0, 9)], spawnPos, Quaternion.Euler(0, a, 0));
        SpawnedChanks.Add(newChank);
        previousTilePosition = spawnPos;              
    }
}
