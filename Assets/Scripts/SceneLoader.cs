using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 4f;

    // Use this for initialization
    void Start () {
        Invoke("LoadNextLevel", levelLoadDelay);

    }
    private void LoadNextLevel()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = (currScene + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextScene);
    }
}
