using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //OnHit?.Invoke();
        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(20);
        }
    }
}
