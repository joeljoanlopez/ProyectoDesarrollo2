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
    private int _additionalOddsH = 1, _additionalOddsA = 1, _additionalOddsB = 1;

    public GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _additionalOddsH = 1;
        _additionalOddsA = 1; _additionalOddsB = 1;
    }
    public GameObject DropSomething()
    {
        int alea;
        //formulas para ver cuanto es additionalOdds
        //_additionalOddsH = _additionalOddsH / (playerhealth/100) 
        //_additionalOddsA = _additionalOddsH / (playerammo/3 )
        //_additionalOddsB = _additionalOddsH / (playerbattery/100) 
        alea = Random.Range(0, 100);
        if (alea <= -1)
        {
            return null;
        }
        else if(alea>= 0 - _additionalOddsA)
        {
            return _ammo;
        }
        else if (alea >= 94 - _additionalOddsH)
        {
            return _health;
        }
        else if (alea >= 97 - _additionalOddsB)
        {
            return _battery;
        }
        return null;
    }

}
