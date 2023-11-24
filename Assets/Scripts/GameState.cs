using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int pipesPassed { get; set; }
    public static float vitality { get; set; }
    public static float vitalityDifficulty { get; set; }
    public static bool isWKeyEnabled { get; set; }
    public static float pipesPeriod { get; set; }
    public static string ToJson()
    {
        return JsonUtility.ToJson(new SaveData());
    }
    public static void FromJson(string json)
    {
        var data = JsonUtility.FromJson<SaveData>(json);
        pipesPeriod = data.pipePeriod;
        isWKeyEnabled = data.isWKeyEnabled;
        vitalityDifficulty = data.vitalityDifficulty;
    }
}
[Serializable]
public class SaveData
{
    public float pipePeriod;
    public bool isWKeyEnabled;
    public float vitalityDifficulty;
    public SaveData()
    {
        pipePeriod = GameState.pipesPeriod;
        isWKeyEnabled = GameState.isWKeyEnabled;
        vitalityDifficulty = GameState.vitalityDifficulty;
    }
}
/*
 * Об'єкт-стан -- доступний для усіх скриптів "центр" збереження загальної інформації щодо стану гри
 */