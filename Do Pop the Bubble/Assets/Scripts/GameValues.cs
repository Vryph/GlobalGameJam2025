using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameValues", order = 1)]
public class GameValues : ScriptableObject
{
    public int CompletedMinigames;
    public int CurrentDifficulty;
    public int CurrentMinigame;
    public int LastMinigame;

    public bool DoPop = true;

    public int LastDifficultyIncrease;
    public int TotalExistingMinigames;
}
