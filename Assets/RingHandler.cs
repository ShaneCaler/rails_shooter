using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHandler : MonoBehaviour
{
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 50;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }


    void OnTriggerEnter(Collider collision)
    {
        scoreBoard.ScoreHit(scorePerHit);
    }
}
