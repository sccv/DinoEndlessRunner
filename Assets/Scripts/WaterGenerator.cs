using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public ObjectPool waterPool;

    private float theWidth;

    private void Start()
    {
        theWidth = waterPool.objectInPool.GetComponent<BoxCollider2D>().size.x;
    }

    private void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + theWidth, transform.position.y, transform.position.z);

            GameObject theWaterObject = waterPool.GetObjectFromPool();
            theWaterObject.transform.position = transform.position;
            theWaterObject.transform.rotation = transform.rotation;

            theWaterObject.SetActive(true);
        }
    }
}
