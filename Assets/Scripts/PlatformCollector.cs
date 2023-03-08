using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : MonoBehaviour
{
    private GameObject platformCollectionPoint;


    // Start is called before the first frame update
    void Start()
    {
        platformCollectionPoint = GameObject.Find("PlatformCollectionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformCollectionPoint.transform.position.x)
        {
            // Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
