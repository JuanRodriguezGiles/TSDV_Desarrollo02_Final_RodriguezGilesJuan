using UnityEngine;
public class Projectile : MonoBehaviour
{
    public float hitRadius;
    int _layerMask;
    void Awake()
    {
        _layerMask = 1 << 8;
        _layerMask = ~_layerMask;
    }
    void OnTriggerEnter(Collider collider)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius, _layerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;
            targetRigidbody.GetComponent<IHittable>().OnHit();
            Destroy(gameObject);
        }
    }
}