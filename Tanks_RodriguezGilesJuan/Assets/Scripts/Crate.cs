using UnityEngine;
public class Crate : MonoBehaviour, IHittable
{
    public ParticleSystem explosion;
    public void OnHit()
    {
        explosion.transform.parent = null;
        explosion.Play();
        Destroy(explosion.gameObject, explosion.main.duration);
        Destroy(gameObject);
    }
}