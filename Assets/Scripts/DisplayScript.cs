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
        // ������ ��������� TextMeshProUGUI � ������ GameObject "ClockTMP"
        clock = GameObject.Find("ClockTMP").GetComponent<TMPro.TextMeshProUGUI>();
        vitalityIndicator.fillAmount = 1f;
        StartCoroutine("vitalityReduce");
        gameTime = 0;
    }

    // Update is called once per frame
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
        while (vitalityIndicator.fillAmount > 0) {
            vitalityIndicator.fillAmount -= 0.02f;
            if (vitalityIndicator.fillAmount <= 0) break;
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Vitality is over!");
    }
}
