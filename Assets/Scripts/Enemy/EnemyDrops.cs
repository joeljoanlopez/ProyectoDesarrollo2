using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject _ammo;
    public GameObject _health;
    public GameObject _battery;
    public int _additionalOddsH = 1, _additionalOddsA = 1, _additionalOddsB = 1;
    public GameObject _targetParent;

    public void Start()
    {
        _targetParent = GameObject.FindGameObjectWithTag("DropContainer");
    }

    void Update()
    {
        _additionalOddsH = 1;
        _additionalOddsA = 1;
        _additionalOddsB = 1;
    }
    public GameObject GetDrop()
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
        else if (alea >= 0 - _additionalOddsA)
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

    public void DropSomething(GameObject drop)
    {
        if (drop != null)
        {
            var _item = Instantiate(drop, transform.position, transform.rotation);
            _item.transform.SetParent(_targetParent.transform, true);
        }
    }

}
