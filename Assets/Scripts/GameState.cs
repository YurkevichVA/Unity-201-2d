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
}
/*
 * Об'єкт-стан -- доступний для усіх скриптів "центр" збереження загальної інформації щодо стану гри
 */