using System.Collections;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public float rotationSpeed = 5;
    public Transform turret;
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
        Quaternion _lookRotation;
        do
        {
            Vector3 _direction = (worldPosition - turret.position).normalized;
            _lookRotation = Quaternion.LookRotation(_direction);
            turret.rotation = Quaternion.Slerp(turret.rotation, _lookRotation, Time.deltaTime * rotationSpeed);

            yield return null;
        } while (Quaternion.Angle(turret.rotation, _lookRotation) > 7f);
    }
}