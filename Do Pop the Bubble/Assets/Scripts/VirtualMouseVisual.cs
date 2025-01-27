using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouseVisual : MonoBehaviour
{
    [SerializeField] private VirtualMouseUI _cursor;
    [SerializeField] private Transform _pivot;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(_cursor.virtualMousePosition.x, _cursor.virtualMousePosition.y, 180));
        _pivot.position = mousePosition;
    }
}
