using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int _health = 100;


    public void AddHealth(int value){
        _health += value;
    }
}
