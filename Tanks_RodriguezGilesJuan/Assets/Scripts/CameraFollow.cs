using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    public Transform _playerTransform;
    void LateUpdate()
    {
        Vector3 targetPosition = _playerTransform.position + _offset;
        transform.position = Vector3.Slerp(transform.position, targetPosition, 0.5f);
        transform.rotation = Quaternion.Euler(_rotation);
    }
}
