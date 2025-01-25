using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] public GameValues gameValues;
    private int _minigameDifficulty;
    private float _totalTime;
    public float _currentTime;
    [SerializeField] TextMeshProUGUI _timerText;

    [SerializeField] private float _timePerDifficulty = 1f;
    [SerializeField] private float _baseTime = 7f;
    [SerializeField] private int _minLevelsForDifficultyIncrease = 3;


    private void Start()
    {
        _minigameDifficulty = gameValues.CurrentDifficulty;
        _totalTime = _baseTime - (_minigameDifficulty * _timePerDifficulty);
        _currentTime = _totalTime;
    }

    private void Update()
    {

        _currentTime -= Time.deltaTime;
        if (Input.anyKeyDown)
        {
            MinigameWin();
        }

        if(_currentTime <= 0)
        {
            MinigameLoss();
        }

        SetTimer();
    }

    public void MinigameLoss()
    {
        return;
    }

    public void MinigameWin()
    {
        gameValues.CompletedMinigames++;
        gameValues.LastMinigame = gameValues.CurrentMinigame;
        gameValues.CurrentMinigame = SelectNextMinigame();
    }

    private void DifficultyUpdate()
    {
        int minigamesSinceLastIncrease = gameValues.CompletedMinigames - gameValues.LastDifficultyIncrease;
        if (minigamesSinceLastIncrease >= _minLevelsForDifficultyIncrease)
        {
            int chance = Random.Range(0, 100);
            if (chance < minigamesSinceLastIncrease * 7)
            {
                gameValues.LastDifficultyIncrease = gameValues.CompletedMinigames;
                gameValues.CurrentDifficulty++;
            }
        }
    }

    private int SelectNextMinigame()
    {
        int nextMinigame = gameValues.LastMinigame;
        while(nextMinigame == gameValues.LastMinigame)
        {
            nextMinigame = RollMinigame();
        }
        return nextMinigame;
    }

    private int RollMinigame()
    {
        return Random.Range(0, gameValues.TotalExistingMinigames);
    }

    private void SetTimer()
    {
        if(_currentTime >= 0)
        {
            int seconds = Mathf.FloorToInt(_currentTime % 60);
            int milliseconds = Mathf.FloorToInt((_currentTime % 1) * 100);
            string tempString = string.Format("{0:00}.{1:00}", seconds, milliseconds);
            _timerText.text = $"Remaining Time: {tempString}s \n";
        }
    }
}
