using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Toggle controlWToggle;
    [SerializeField]
    private Slider pipePeriodSlider;
    [SerializeField]
    private Slider vitalitySlider;

    private bool isShow;

    void Start()
    {
        isShow = content.activeInHierarchy;
        ToggleMenu(!isShow);
        GameState.isWKeyEnabled = controlWToggle.isOn;
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
    public void CloseButtonClick()
    {
        ToggleMenu(true);
    }
    public void ControlWKeyToggleChanged(bool value)
    {
        GameState.isWKeyEnabled = value;
    }
    public void PipePeriodSliderChanged(float value)
    {
        //Debug.Log(value);
        SetPipePeriod(value);
    }
    private void SetPipePeriod(float sliderValue)
    {
        GameState.pipesPeriod = 6f - (6f - 2f) * sliderValue;
    }
    public void VitalitySliderChanged(float value)
    {
        SetVitality(value);
    }
    private void SetVitality(float value)
    {
        GameState.vitalityDifficulty = 0.8f - (0.8f - 0.3f) * value;
    }
}
