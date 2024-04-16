using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPickupHandler : MonoBehaviour
{
    //Get possible pickups
    public GameObject _ammo;
    public GameObject _health;
    public GameObject _battery;

    // Get where the pickups will go
    public GunAttackHandler _gun;
    public FlashLightController _lantern;
    private HealthManager _healthManager;

    public void Start()
    {
        _healthManager = GetComponent<HealthManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DroppedItem _droppedItem;
        if (other.TryGetComponent<DroppedItem>(out _droppedItem))
        {
            if (other.gameObject.tag == _ammo.tag)
                _gun.GetAmmo(_droppedItem.Quantity);
            else if (other.gameObject.tag == _health.tag)
                _healthManager.AddHealth(_droppedItem.Quantity);
            else if (other.gameObject.tag == _battery.tag)
                _lantern.AddBattery(_droppedItem.Quantity);
        }

    }
}
