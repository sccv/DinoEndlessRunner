using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // public GameObject[] thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public ObjectPool[] thePool;
    private CoinGenerator coinGenerator;
    private SnakeSpawning snakeSpawning;
    private int spawnCoinOrNot;

    private float[] platformWidth;
    [SerializeField]
    private float distanceMin;
    [SerializeField]
    private float distanceMax;
    private int chosenPlatform;

    // Control the platform height
    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightdifferent;
    private float heightChange;
    
    
    // Start is called before the first frame update
    void Start()
    {
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();
        snakeSpawning = FindObjectOfType<SnakeSpawning>();

        platformWidth = new float[thePool.Length];

        // Get width length of the platform
        for (int i=0; i < thePool.Length; i++)
        {
            platformWidth[i] = thePool[i].objectInPool.GetComponent<BoxCollider2D>().size.x; 
        } 

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x) // Generating the platform if the generator position x is less than generatorPoint's
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            chosenPlatform = Random.Range(0, thePool.Length);
            heightChange = transform.position.y + Random.Range(maxHeightdifferent, - maxHeightdifferent);

            if (heightChange > maxHeight)
                heightChange = maxHeight;
            else if (heightChange < minHeight)
                heightChange = minHeight;

            transform.position = new Vector3(transform.position.x + platformWidth[chosenPlatform]/2 + distanceBetween, heightChange, transform.position.z);


            // Instantiate(thePool[chosenPlatform], transform.position, transform.rotation);

            
            GameObject thePlatform = thePool[chosenPlatform].GetObjectFromPool();
            thePlatform.transform.position = transform.position;
            thePlatform.transform.rotation = transform.rotation;

            spawnCoinOrNot = Random.Range(0, 2);
            if (spawnCoinOrNot == 1)
                coinGenerator.SpawnCoin(new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z));
            else
                snakeSpawning.spawnSnake(new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z));

            thePlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + platformWidth[chosenPlatform]/2, transform.position.y, transform.position.z);

        }
    }

    
}
