using UnityEngine;
public class Projectile : MonoBehaviour
{
    int _layerMask;
    void Awake()
    {
        _layerMask = 1 << 8;
        _layerMask = ~_layerMask;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IHittable>() != null)
            collider.GetComponent<IHittable>().OnHit();
    }
}