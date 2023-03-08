using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    public Transform waterGenerator;
    private ScoreManager scoreManager;
    private float deadDistance;

    private Vector3 waterGeneratorOrigin;
    private Vector3 cameraOriginPosition;
    private Vector3 platformStartPoint;
    private Player player;
    private Vector3 playerStartPoint;
    [SerializeField]
    private FollowPlayer cameraInstance;

    public static GameManager instance;

    private PlatformCollector[] platformList;

    public DeathMenu deathMenu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deadDistance = 20f;
        scoreManager = FindObjectOfType<ScoreManager>();
        platformStartPoint = platformGenerator.position;
        
        cameraOriginPosition = cameraInstance.transform.position;
        waterGeneratorOrigin = waterGenerator.position;
       
    }

    private void FixedUpdate()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
            playerStartPoint = player.transform.position;
        }

        if (Vector3.Distance(player.GetPosition(), cameraInstance.gameObject.transform.position) > deadDistance)
        {
            RestartGame();
            player.ChangeSpeed();
        }
    }

    public void RestartGame()
    {
        scoreManager.ScoreIncreasing = false;
        player.gameObject.SetActive(false);
        Time.timeScale = 0f;

        // StartCoroutine("RestartGameCouroutine");

        deathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        Time.timeScale = 1f;

        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformCollector>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        cameraInstance.transform.position = cameraOriginPosition;
        waterGenerator.position = waterGeneratorOrigin; 

        player.gameObject.SetActive(true);
        scoreManager.ScoreCount = 0;
        scoreManager.ScoreIncreasing = true;

    }

    /*
    IEnumerator RestartGameCouroutine()
    {
        scoreManager.ScoreIncreasing = false;
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformCollector>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.ScoreCount = 0;
        scoreManager.ScoreIncreasing = true;
    }
    */
}
