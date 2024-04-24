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
    public float _additionalOddsH = 1, _additionalOddsA = 1, _additionalOddsB = 1, _basicOdds = 1;
    public GameObject _player;
    private GameObject _targetParent;

    public void Start()
    {
        _targetParent = GameObject.FindGameObjectWithTag("DropContainer");
    }

    void Update()
    {

        _additionalOddsH = _basicOdds * (_player.GetComponent<HealthManager>()._health / 100);
        //_additionalOddsA = _basicOdds * (_player.GetComponentInChildren<GunAttackHandler>()._ammo * 10 / 100);
        _additionalOddsB = _basicOdds * (_player.GetComponentInChildren<FlashLightController>()._battery / 100);
    }
    public GameObject GetDrop()
    {
        int alea;
        //formulas para ver cuanto es additionalOdds
        alea = Random.Range(0, 100);
        if (alea >= 0 - _additionalOddsA)
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
        else if (alea >= 0)
        {
            return null;
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
