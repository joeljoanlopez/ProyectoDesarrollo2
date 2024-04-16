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
            if (other.gameObject.name == _ammo.name)
                _gun.GetAmmo(_droppedItem.Quantity);
            else if (other.gameObject.name == _health.name)
                _healthManager.AddHealth(_droppedItem.Quantity);
            else if (other.gameObject.name == _battery.name)
                _lantern.AddBattery(_droppedItem.Quantity);
        }

    }
}
