using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField] private GameObject[] pipePrefabs;
    [SerializeField] private GameObject foodPrefab;
    // private float pipeSpawnPeriod = 4f;     // час у секундах між появою труб
    private float pipeCountdown;            // залишок часу до появи
    private float foodCountdown;            // залишок часу до появи їжі
    void Start()
    {
        pipeCountdown = GameState.pipesPeriod;
        foodCountdown = pipeCountdown / 2f;
        SpawnPipe();
    }

    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if (pipeCountdown <= 0)
        {
            pipeCountdown = GameState.pipesPeriod;
            foodCountdown = pipeCountdown / 2f;
            SpawnPipe();
        }
        if (foodCountdown > 0)
        {
            if (foodCountdown - Time.deltaTime <= 0)
            {
                SpawnFood();
                foodCountdown = 0;
            }
            else
            {
                foodCountdown -= Time.deltaTime;
            }
        }
    }

    private void SpawnFood()
    {
        if (Random.value < GameState.vitalityDifficulty)
        {
            var food = GameObject.Instantiate(foodPrefab); // ~ new PipePrefab
            food.transform.position = this.transform.position + Vector3.up * Random.Range(-4f, 4f);
        }
    }

    private void SpawnPipe()
    {
        var pipe = Instantiate(pipePrefabs[Random.Range(0,3)]);
        pipe.transform.position = transform.position + Vector3.up * Random.Range(-1.2f, 1.1f);
    }
}
