using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public BubbleManager manager;
    [SerializeField] public VirtualMouseUI _mouseCursorUI1;
    [SerializeField] public VirtualMouseUI _mouseCursorUI2;
    [SerializeField] public AudioSource _popSound;
    private Vector2 _screenPosition;
    private bool _isPopped = false;

    private void Start()
    {
        _screenPosition = Camera.main.WorldToScreenPoint(transform.position);
    }
    private void Update()
    {
        Vector2 difference1 = _screenPosition - _mouseCursorUI1.virtualMousePosition;
        Vector2 difference2 = _screenPosition - _mouseCursorUI2.virtualMousePosition;
        if (!_isPopped)
        {
            if ((Math.Abs(difference1.x) <= 40 && Math.Abs(difference1.y) <= 40) || (Math.Abs(difference2.x) <= 40 && Math.Abs(difference2.y) <= 40))
            {
                Pop();
            }
        }
    }
    private void Pop()
    {
        _isPopped = true;
        if (_popSound != null)
        {
            _popSound.pitch = UnityEngine.Random.Range(1f, 2f);
            _popSound.Play();
        }
        manager._currentBubbles--;
        Destroy(gameObject);
    }
}
