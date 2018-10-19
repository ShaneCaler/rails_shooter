using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("Paricle effects prefab on player")][SerializeField] GameObject deathFX;


    void OnTriggerEnter(Collider other)
    {
        if (other.name != "RingOfFire (2)")
        {
            deathFX.SetActive(true);
            StartDeathSequence();
            Invoke("ReloadLevel", levelLoadDelay);
        }
    }

    private void ReloadLevel() // referenced by string
    {
            SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("FreezeControlsOnImpact");
    }
}
