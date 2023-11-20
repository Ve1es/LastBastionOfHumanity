using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    private RaycastHit2D hit;

    private void Start()
    {
        DisableLaser();
    }
    private void Update()
    {
        hit = Physics2D.Raycast(firePoint.position, firePoint.up, 15);
        if (hit)
        {
            Debug.Log("hit");
            lineRenderer.SetPosition(1, new Vector3(0, hit.distance, 0)); }
        else
        { lineRenderer.SetPosition(1, new Vector3(0, 15, 0)); }
        //Debug.Log(lineRenderer.GetPosition(1));
    }
    public void EnableLaser()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(1, new Vector3(0,15,0));
    }
    public void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Vector2 startPos = firePoint.position;
        Vector2 direction = firePoint.up;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(startPos, direction*15);
    }
}
