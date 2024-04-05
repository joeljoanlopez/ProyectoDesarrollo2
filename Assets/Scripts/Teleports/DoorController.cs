using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _destination;
    public Transform GetDestination()
    {
        return _destination; 
    }
}
