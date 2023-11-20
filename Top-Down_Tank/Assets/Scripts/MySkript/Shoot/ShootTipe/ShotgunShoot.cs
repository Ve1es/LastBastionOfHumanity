using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    [SerializeField]
    private float bulletQuantity = 3;
    public void Shoot(bool canShoot, float currentDelay, TurretData turretData,
       List<Transform> turretBarrels, ObjectPool bulletPool, Collider2D[] tankColliders)
    {
        if (canShoot)
        {
            // canShoot = false;
            //currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                for (int i = 0; i < bulletQuantity; i++)
                {
                    GameObject bullet = bulletPool.CreateObject();
                    bullet.transform.position = barrel.position;
                    bullet.transform.localRotation = barrel.rotation;
                    bullet.transform.Rotate(0,0,Random.Range(-30.0f, 30.0f));
                    bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);

                    foreach (var collider in tankColliders)
                    {
                        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                    }
                }

            }

            // OnShoot?.Invoke();
            //OnReloading?.Invoke(currentDelay);
        }
        else
        {
            // OnCantShoot?.Invoke();
        }
    }
}
