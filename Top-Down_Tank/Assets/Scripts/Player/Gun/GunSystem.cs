using System.Collections;
using TMPro;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public BulletCreate bulletCreate;
    //Gun stats
    public GunSystemData gunSystemData;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot, spread, magazineSize=0;
    Coroutine reloadFullRoutine, reload1Routine;


    //bools 
    bool shooting, readyToShoot, reloadingFull, reloading1;

   private void Awake()
    {
        magazineSize = gunSystemData.magazineSize * gunSystemData.partsInBullet;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    public void MyInput()
    {
        //Debug.Log(readyToShoot);
        //Shoot
        if (readyToShoot && reloadFullRoutine==null && bulletsLeft > 0)
        {
            StopCourutine();           
            readyToShoot = false;
            Invoke("ResetShoot", gunSystemData.timeBetweenShooting);
            bulletsShot = gunSystemData.bulletsPerTap;
            Shoot();
        }
    }
    private void StopCourutine()
    {
        if (reload1Routine != null)
        {
            StopCoroutine(reload1Routine);
            reload1Routine = null;
        }
    }
    private void Shoot()
    {
        spread = Random.Range(-gunSystemData.spread / 2, gunSystemData.spread / 2);
        bulletCreate.Shoot(spread);


        bulletsLeft--;
        //Debug.Log(bulletsLeft);
        bulletsShot--;

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", gunSystemData.timeBetweenShots);
    }
    private void ResetShoot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        if (bulletsLeft < magazineSize)
        {
            if (gunSystemData.reloadTimeFull > 0 && gunSystemData.reloadTime1 <= 0)
            {
                /*reloadingFull = true;
                Invoke("ReloadFullFinished", gunSystemData.reloadTimeFull);*/
                reloadFullRoutine = StartCoroutine(ReloadFullAmmo());
            }else if(gunSystemData.reloadTimeFull > 0 && gunSystemData.reloadTime1 > 0)
            {
                if (bulletsLeft == 0)
                {
                    /*reloadingFull = true;
                    Invoke("ReloadFullFinished", gunSystemData.reloadTimeFull);*/
                    reloadFullRoutine = StartCoroutine(ReloadFullAmmo());
                } else
                {
                    // Invoke("Reload1", gunSystemData.reloadTime1);
                    reload1Routine = StartCoroutine(Reload1Ammo());
                }
            }else if(gunSystemData.reloadTime1 > 0&& gunSystemData.reloadTimeFull <= 0)
            {
                //Invoke("Reload1", gunSystemData.reloadTime1);
                reload1Routine = StartCoroutine(Reload1Ammo());
            }
        }
    }

    IEnumerator ReloadFullAmmo()
    {
        yield return new WaitForSeconds(gunSystemData.reloadTimeFull);
        bulletsLeft = magazineSize;
        //Debug.Log(bulletsLeft);
        reloadFullRoutine = null;
    }
    IEnumerator Reload1Ammo()
    {
        yield return new WaitForSeconds(gunSystemData.reloadTime1);
        bulletsLeft += gunSystemData.partsInBullet;
        //Debug.Log(bulletsLeft);
        //Debug.Log("Reloading");
        if (bulletsLeft < magazineSize)
        { reload1Routine = StartCoroutine(Reload1Ammo()); }
        else
        { reload1Routine = null; }
    }


   /* private void Reload1()
    {
        if (bulletsLeft < magazineSize&& reloading1)
        { 
            Invoke("Reload1", gunSystemData.reloadTime1);
            Invoke("Reload1Finished", gunSystemData.reloadTime1);
        }
    }
    private void ReloadFullFinished()
    {
        bulletsLeft = magazineSize;
        reloadingFull = false;
    }
    private void Reload1Finished()
    {
        if(reloading1)
           bulletsLeft+= gunSystemData.partsInBullet;
    }*/
}
