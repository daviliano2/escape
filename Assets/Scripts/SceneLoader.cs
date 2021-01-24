using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Invoke("LoadNextScene", 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int totalNumberScenes = SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(currentScene + 1);
    }
}
