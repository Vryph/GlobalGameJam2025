using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public BubbleManager manager;
    [SerializeField] public VirtualMouseUI _mouseCursorUI;
    private Vector2 _screenPosition;


    private void Start()
    {
        _screenPosition = Camera.main.WorldToScreenPoint(transform.position);
    }
    private void Update()
    {
        Vector2 difference = _screenPosition - _mouseCursorUI.virtualMousePosition;
        if (Math.Abs(difference.x) <= 20 && Math.Abs(difference.y) <= 20)
        {  
            Pop();
        }
    }
    private void Pop()
    {

        manager._currentBubbles--;
        Destroy(gameObject);
    }
}
