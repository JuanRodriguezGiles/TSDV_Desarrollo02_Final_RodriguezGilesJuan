using System.Collections;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public float rotationSpeed = 5;
    public Transform turret;
    public Transform projectileSpawn;
    public Rigidbody projectile;
    public float projectileForce = 20;
    Vector3 worldPosition;
    void Start()
    {
        rotationSpeed /= 10;
    }
    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
        }

        StartCoroutine(Rotate());
    }
    IEnumerator Rotate()
    {
        Quaternion lookRotation;
        do
        {
            Vector3 direction = (worldPosition - turret.position).normalized;
            lookRotation = Quaternion.LookRotation(direction);
            lookRotation.eulerAngles = new Vector3(0, lookRotation.eulerAngles.y, 0);
            turret.rotation = Quaternion.Slerp(turret.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            turret.rotation = Quaternion.Euler(0, turret.eulerAngles.y, 0);
            yield return null;
        } while (Quaternion.Angle(turret.rotation, lookRotation) > 5f);
        Fire();
    }
    void Fire()
    {
        Rigidbody shellInstance = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        shellInstance.velocity = projectileForce * projectileSpawn.forward;
    }
}