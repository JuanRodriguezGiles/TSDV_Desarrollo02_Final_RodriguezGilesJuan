using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Vector3 _offset;
    [SerializeField] Vector3 _rotation;
    public Transform playerTransform;
    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + _offset;
        transform.position = Vector3.Slerp(transform.position, targetPosition, 0.5f);
        transform.rotation = Quaternion.Euler(_rotation);
    }
}