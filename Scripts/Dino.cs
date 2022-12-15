using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField]
    private float ForceFactor = 10;

    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;
    private float time;
    private float holdTime;
    private float holdTimeLimit;
    private const float deltaTimeScaler = 100;
    private const float discrete2continualFactor = 40;

    private GameStat gameStat;
    private GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        ForceDirection = Vector2.up * ForceFactor;
        time = 0;
        holdTime = 0;
        holdTimeLimit = 1;

        gameStat = GameObject.Find("GameStat").GetComponent<GameStat>();
        gameOver = GameObject.Find("GameOver").GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.AddForce(ForceDirection * discrete2continualFactor);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cactus"))
        {
            gameStat.GameScore += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cactus"))
        {

            gameOver.ShowEndOfGame(false);
            
        }

    }
}
