using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnReloading;


    private void Start()
    {
       // OnReloading?.Invoke(currentDelay);
    }

    public void Shoot(bool canShoot, float currentDelay, TurretData turretData,
       Transform barrel, ObjectPool bulletPool, Collider2D[] playerColliders)
    {
        if (canShoot)
        {
           // canShoot = false;
           // currentDelay = turretData.reloadDelay;

            GameObject bullet = bulletPool.CreateObject();
            bullet.transform.position = barrel.position;
            bullet.transform.localRotation = barrel.rotation;
            bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);

            foreach (var collider in playerColliders)
            {
                Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
            }
           // OnShoot?.Invoke();
           // OnReloading?.Invoke(currentDelay);
        }
        else
        {
           //  OnCantShoot?.Invoke();
        }
    }
}
