using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 20;
    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddSphereCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddSphereCollider()
    {
        SphereCollider sphereCol = gameObject.AddComponent<SphereCollider>();
        sphereCol.isTrigger = false;
        sphereCol.radius = 3.36f;
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        scoreBoard.ScoreHit(scorePerHit);
        Destroy(gameObject);
    }
}
