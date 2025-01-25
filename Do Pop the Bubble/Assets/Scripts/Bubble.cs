using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public BubbleManager manager;
    [SerializeField] public VirtualMouseUI _mouseCursorUI1;
    [SerializeField] public VirtualMouseUI _mouseCursorUI2;
    private Vector2 _screenPosition;


    private void Start()
    {
        _screenPosition = Camera.main.WorldToScreenPoint(transform.position);
    }
    private void Update()
    {
        Vector2 difference1 = _screenPosition - _mouseCursorUI1.virtualMousePosition;
        Vector2 difference2 = _screenPosition - _mouseCursorUI2.virtualMousePosition;
        if ((Math.Abs(difference1.x) <= 20 && Math.Abs(difference1.y) <= 20) || (Math.Abs(difference2.x) <= 20 && Math.Abs(difference2.y) <= 20))
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
