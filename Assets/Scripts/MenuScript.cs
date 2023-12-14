using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Slider pipePeriodSlider;
    [SerializeField]
    private Slider vitalitySlider;

    private bool isShow;
    //private const string configFilename = "Assets/Files/config.json";

    void Start()
    {
        isShow = content.activeInHierarchy;
        ToggleMenu(!isShow);

        pipePeriodSlider.value = PlayerPrefs.GetFloat("PipePeriod", 4f);
        vitalitySlider.value = PlayerPrefs.GetFloat("VitalityDiff", 0.6f);

        SetPipePeriod(pipePeriodSlider.value);
        SetVitality(vitalitySlider.value);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu(isShow);
        }
    }
    private void ToggleMenu(bool isDisplay)
    {
        if (isDisplay)
        {
            isShow = false;
            content.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isShow = true;
            content.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void StartButtonClick()
    {
        ToggleMenu(true);
    }
    public void PipePeriodSliderChanged(float value)
    {
        SetPipePeriod(value);
    }
    private void SetPipePeriod(float value)
    {
        GameState.pipesPeriod = value;
        PlayerPrefs.SetFloat("PipePeriod", value);
    }
    public void VitalitySliderChanged(float value)
    {
        SetVitality(value);
    }
    private void SetVitality(float value)
    {
        GameState.vitalityDifficulty = value;
        PlayerPrefs.SetFloat("VitalityDiff", value);
    }
}
