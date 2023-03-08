using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPool coinPool;
    public float distanceBetweenCoin;
    private int randomCoinNums;

    public void SpawnCoin(Vector3 spawnPosition)
    {
        randomCoinNums = Random.Range(0, 2);
        if (randomCoinNums == 1)
        {
            GameObject coinInstance = coinPool.GetObjectFromPool();
            coinInstance.transform.position = spawnPosition;
            coinInstance.SetActive(true);
            coinInstance.transform.GetChild(0).gameObject.SetActive(true);

            GameObject coinInstance2 = coinPool.GetObjectFromPool();
            coinInstance2.transform.position = new Vector3(spawnPosition.x + distanceBetweenCoin, spawnPosition.y, spawnPosition.z);
            coinInstance2.SetActive(true);
            coinInstance2.transform.GetChild(0).gameObject.SetActive(true);

            GameObject coinInstance3 = coinPool.GetObjectFromPool();
            coinInstance3.transform.position = new Vector3(spawnPosition.x - distanceBetweenCoin, spawnPosition.y, spawnPosition.z);
            coinInstance3.SetActive(true);
            coinInstance3.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            GameObject coinInstance = coinPool.GetObjectFromPool();
            coinInstance.transform.position = spawnPosition;
            coinInstance.SetActive(true);
            coinInstance.transform.GetChild(0).gameObject.SetActive(true);
        }

        
    }
}
