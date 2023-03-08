using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectInPool;
    public int poolSize;

    List<GameObject> objectPool;  

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectInPool);
            obj.SetActive(false);
            objectPool.Add(obj);

        }
        
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var item in objectPool)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }

        GameObject obj = (GameObject)Instantiate(objectInPool);
        obj.SetActive(false);
        objectPool.Add(obj);
        
        return obj;
    }
}
