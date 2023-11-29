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
    private const string configFilename = "Assets/Files/config.json";

    void Start()
    {
        isShow = content.activeInHierarchy;
        ToggleMenu(!isShow);

        if (LoadSettings())
        {
            pipePeriodSlider.value = (6f - GameState.pipesPeriod) / (6f - 2f);
            vitalitySlider.value = (0.8f - GameState.vitality) / (0.8f - 0.3f);
        }
        else
        {
            SetPipePeriod(pipePeriodSlider.value);
            SetVitality(vitalitySlider.value);
            SaveSettings();
        }
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
    public void CloseButtonClick()
    {
        ToggleMenu(true);
    }
    public void PipePeriodSliderChanged(float value)
    {
        SetPipePeriod(value);
    }
    private void SetPipePeriod(float sliderValue)
    {
        GameState.pipesPeriod = sliderValue;
        SaveSettings();
    }
    public void VitalitySliderChanged(float value)
    {
        SetVitality(value);
    }
    private void SetVitality(float value)
    {
        GameState.vitalityDifficulty = value;
        SaveSettings();
    }
    private void SaveSettings()
    {
        File.WriteAllText(configFilename, GameState.ToJson());
    }
    private bool LoadSettings()
    {
        if (File.Exists(configFilename))
        {
            GameState.FromJson(File.ReadAllText(configFilename));
            return true;
        }
        return false;
    }
}
