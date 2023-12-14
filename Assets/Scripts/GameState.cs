using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static int _pipesPassed;
    public static int pipesPassed
    {
        get { return _pipesPassed; }
        set { _pipesPassed = value; NotifyListeners(); }
    }
    private static float _vitality;
    public static float vitality
    {
        get { return _vitality; }
        set { _vitality = value; NotifyListeners(); }
    }
    private static float _vitalityDifficulty;
    public static float vitalityDifficulty
    {
        get { return _vitalityDifficulty; }
        set { _vitalityDifficulty = value; NotifyListeners(); }
    }
    private static float _pipesPeriod;
    public static float pipesPeriod
    {
        get { return _pipesPeriod; }
        set { _pipesPeriod = value; NotifyListeners(); }
    }
    private static Dictionary<String, List<Action>> propertyObservers = initPropertyObservers();
    private static Dictionary<String, List<Action>> initPropertyObservers()
    {
        Dictionary<String, List<Action>> res = new();
        foreach (var prop in typeof(GameState).GetProperties())
        {
            res[prop.Name] = new();
        }
        return res;
    }
    private static void NotifyListeners([CallerMemberName] String propertyName = "")
    {
        if (propertyObservers.ContainsKey(propertyName))
        {
            propertyObservers[propertyName]
                .ForEach(listener => listener.Invoke());
        }
    }

    
    public static event Action gameOverEvent;
    public static void OnGameOver()
    {
        pipesPassed = 0;
        vitality = 1f;
        gameOverEvent?.Invoke();
    }

    public static event Action restartEvent;
    public static void OnRestart()
    {
        restartEvent?.Invoke();
    }
}