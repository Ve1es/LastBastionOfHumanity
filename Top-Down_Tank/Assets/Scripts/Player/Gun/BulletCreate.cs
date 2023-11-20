using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    [SerializeField]
    private TurretData turretData;
    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private ObjectPool bulletPool;
    private Collider2D[] playerColliders;
    [SerializeField]
    private int bulletPoolCount = 100;
    private void Awake()
    {
        playerColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();

    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);
    }
    public void Shoot(int spread)
    {
        GameObject bullet = bulletPool.CreateObject();
        bullet.transform.position = barrel.position;
        bullet.transform.localRotation = barrel.rotation;
        bullet.transform.Rotate(0, 0, spread);
        bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);

        foreach (var collider in playerColliders)
        {
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
        }
    }
}
