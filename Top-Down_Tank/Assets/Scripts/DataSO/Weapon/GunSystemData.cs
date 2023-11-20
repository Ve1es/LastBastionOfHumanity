using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "Data/GunData")]
public class GunSystemData : ScriptableObject
{
    public int damage;
    public float timeBetweenShooting, range, reloadTimeFull, reloadTime1, timeBetweenShots;
    public int magazineSize, bulletsPerTap, spread, partsInBullet;

} 
