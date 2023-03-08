using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoCarrier : MonoBehaviour
{
    public static DinoCarrier carrierInstance;

    [SerializeField]
    private GameObject[] Dinos;

    private int dinoChosen;
    public int DinoChosen 
    { 
        get 
        {
            return dinoChosen;
        } 
        set
        {
            dinoChosen = value;
        } 
    }

    private void Awake()
    {
        if (carrierInstance == null)
        {
            carrierInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnlevelFinishLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnlevelFinishLoading;
    }

    private void OnlevelFinishLoading(Scene s, LoadSceneMode mode)
    {
        if (s.name == "Main")
        {
            Instantiate(Dinos[dinoChosen], new Vector3(-3.4f, -1.6f, 0), transform.rotation);
        }
    }
}
