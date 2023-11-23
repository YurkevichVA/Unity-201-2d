using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI pipesPassedTmp;
    [SerializeField]
    private Image vitalityIndicator;

    private TMPro.TextMeshProUGUI clock;
    private float gameTime;

    void Start()
    {
        // Знайти компонент TextMeshProUGUI у іншого GameObject "ClockTMP"
        clock = GameObject.Find("ClockTMP").GetComponent<TMPro.TextMeshProUGUI>();
        GameState.vitality = 1f; // повне життя на початку гри
        StartCoroutine("vitalityReduce");
        gameTime = 0;
    }
    void Update()
    {
        gameTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        int time = (int)gameTime;
        int hour = time / 3600;
        int minute = (time % 3600) / 60;
        int second = time % 60;
        int decisecond = (int)((gameTime - time) * 10);
        clock.text = $"{hour:00}:{minute:00}:{second:00}.{decisecond:0}";
        pipesPassedTmp.text = GameState.pipesPassed.ToString();
    }
    IEnumerator vitalityReduce()
    {
        while (GameState.vitality > 0) {
            GameState.vitality -= 0.02f;
            vitalityIndicator.fillAmount = GameState.vitality;
            if (GameState.vitality <= 0) break;
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Vitality is over!");
    }
}
