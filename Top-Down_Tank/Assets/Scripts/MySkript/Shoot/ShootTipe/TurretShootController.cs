using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

[RequireComponent(typeof(ObjectPool))]
public class TurretShootController : MonoBehaviour
{
    [SerializeField]
    float shootTipe = 0;
    public OneShoot oneShoot;
    public ShotgunShoot shotgunShoot;
    public RayShoot rayShoot;


    public List<Transform> turretBarrels;

    public TurretData turretData;
    public TurretData turretDataTest;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private ObjectPool bulletPool;
    private ObjectPool bulletPoolTest;
    //public GameObject bulletPrefab;
    [SerializeField]
    private int bulletPoolCount = 10;

    public UnityEvent OnShoot, OnCantShoot, SlowShoot;
    public UnityEvent<float> OnReloading;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
        bulletPoolTest = GetComponent<ObjectPool>();

    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);
        bulletPoolTest.Initialize(turretDataTest.bulletPrefab, bulletPoolCount);
        OnReloading?.Invoke(currentDelay);
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            OnReloading?.Invoke(currentDelay / turretData.reloadDelay);
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        //Debug.Log("Shoot");
        oneShoot.Shoot(canShoot, currentDelay, turretData, turretBarrels, bulletPool, tankColliders);
        //rayShoot.DisableLaser();


      /*  if (canShoot)
        {
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }

            }

            OnShoot?.Invoke();
            OnReloading?.Invoke(currentDelay);
        }
        else
        {
            OnCantShoot?.Invoke();
        }*/
    }


    public void DelayShoot()
    {
        //Debug.Log("DelayShoot");
        shotgunShoot.Shoot(canShoot, currentDelay, turretDataTest, turretBarrels, bulletPoolTest, tankColliders);
        //rayShoot.EnableLaser();
    }
}
