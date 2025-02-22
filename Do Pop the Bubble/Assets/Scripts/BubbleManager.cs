using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameValues _gameValues;
    [SerializeField] private MinigameManager _manager;
    [SerializeField] private GameObject _bubblePrefab; 
    [SerializeField] private VirtualMouseUI _mouseCursorUI1;
    [SerializeField] private VirtualMouseUI _mouseCursorUI2;
    [SerializeField] private AudioSource _Sound;
    private int _totalBubbles;
    private float MinX = -9.5f, MaxX = 9.5f, MinY = -4, MaxY = 6;
    public int _currentBubbles;
    private bool _isReseting;
    private GameObject[] _bubbles;

    private void Start()
    {
        _isReseting = true;
        ResetBubbles();
    }

    private void ResetBubbles()
    {
        _totalBubbles = _gameValues.CurrentDifficulty * Random.Range(2, 6);
        _bubbles = new GameObject[_totalBubbles];
        CreateBubbles();
        _isReseting = false;
    }

    private void CreateBubbles()
    {
        
        for (int i = 0; i < _totalBubbles; i++)
        {
            Vector3 position = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), 0);
            GameObject bubble = Instantiate(_bubblePrefab, position, Quaternion.identity);
            bubble.GetComponent<Bubble>().manager = this;
            bubble.GetComponent<Bubble>()._mouseCursorUI1 = _mouseCursorUI1;
            bubble.GetComponent<Bubble>()._mouseCursorUI2 = _mouseCursorUI2;
            bubble.GetComponent<Bubble>()._popSound = _Sound;
            _bubbles[i] = bubble;
            _currentBubbles++;
        }
    }

    private void Update()
    {
        if (_currentBubbles <= 0 && !_isReseting)
        {
            _isReseting = true;
            _manager.MinigameWin();
            ResetBubbles();
        }
    }

}
