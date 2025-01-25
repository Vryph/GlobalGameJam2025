using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public BubbleManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        manager._currentBubbles--;
        Destroy(gameObject);
    }
}
