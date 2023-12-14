using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void Start()
    {
        GameState.gameOverEvent += OnGameOver;
    }
    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OnRestartButtonClick()
    {
        var pipes = GameObject.FindGameObjectsWithTag("PipePassed");
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i]);
        }
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        GameState.OnRestart();
    }
}
