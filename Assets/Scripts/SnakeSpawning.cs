using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawning : MonoBehaviour
{
    public ObjectPool snakePool;
    private float randomPos;

    public void spawnSnake(Vector3 position)
    {
        randomPos = Random.Range(0.2f, 1f);

        GameObject snakeInstance = snakePool.GetObjectFromPool();
        snakeInstance.transform.position = new Vector3(position.x + randomPos, position.y, position.z);
        snakeInstance.SetActive(true);
    }
}
