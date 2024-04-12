using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _ammo;
    public GameObject _health;
    public GameObject _battery;
    private int _additionalOddsH, _additionalOddsA, _additionalOddsB;

    public GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_additionalOddsH = _additionalOddsH / (playerhealth/100) 
        //_additionalOddsA = _additionalOddsH / (playerammo/3 )
        //_additionalOddsB = _additionalOddsH / (playerbattery/100) 
    }
    public GameObject DropSomething()
    {
        int alea;
        alea = Random.Range(0, 100);
        if (alea <= 90)
        {
            return null;
        }
        else if(alea<= 94)
        {
            return _ammo;
        }
        else if (alea <= 98)
        {
            return _health;
        }
        else 
        {
            return _battery;
        }
    }

}
