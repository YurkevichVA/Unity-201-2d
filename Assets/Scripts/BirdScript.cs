using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D body;
    private float forceFactor = 350f;

    private Vector3 startPosition;
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        GameState.restartEvent += OnRestart;
        GameState.pipesPassed = 0;
    }
    void Update()
    {
        //body.AddForce(Vector2.right);
        if (Input.GetKeyDown(KeyCode.Space)) // на натискання
        {
            body.AddForce(Vector2.up * Time.timeScale * forceFactor);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("Edge"))
        {
            GameState.OnGameOver();
        }
        else
        {
            if (other.gameObject.CompareTag("Food"))
            {
                GameState.vitality = 1;
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PipePassed"))
        {
            GameState.pipesPassed += 1;
        }
    }
    private void OnRestart()
    {
        transform.position = startPosition;
    }
}