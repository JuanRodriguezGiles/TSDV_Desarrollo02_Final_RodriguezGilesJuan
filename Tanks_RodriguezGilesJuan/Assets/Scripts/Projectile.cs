using UnityEngine;
public class Projectile : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IHittable>() != null)
            collider.GetComponent<IHittable>().OnHit();
    }
}