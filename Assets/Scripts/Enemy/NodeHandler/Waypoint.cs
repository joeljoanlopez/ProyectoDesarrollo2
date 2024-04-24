using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform GetNextWP(Transform _currentWP)
    {
        if (_currentWP == null)
            return transform.GetChild(0);
        else if (_currentWP.GetSiblingIndex() < transform.childCount - 1)
            return transform.GetChild(_currentWP.GetSiblingIndex() + 1);
        else
            return transform.GetChild(0);
    }
}
