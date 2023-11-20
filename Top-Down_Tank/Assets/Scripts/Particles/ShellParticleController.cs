
using UnityEngine;

public class ShellParticleController : MonoBehaviour
{
    public Transform shellPlase;
    public Transform shootPlase;
    public void Character_OnShoot()
    {
        Vector3 quadPosition = shellPlase.position;

        Vector3 shootDir = (shootPlase.position - shellPlase.position).normalized/3;
        quadPosition += shootDir;
        shootDir = Quaternion.Euler(0, 0, -90) * shootDir;
        Debug.Log(shootDir);
        float rotation = 0f;

        ShellParticleSystemHandler.Instance.SpawnShell(quadPosition, shootDir);
    }
}
