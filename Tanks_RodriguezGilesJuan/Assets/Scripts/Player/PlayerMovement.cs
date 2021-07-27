using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public float turretRotationSpeed;

    float _movementInput;
    float _rotationInput;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _movementInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        MoveTank();
        RotateTank();
    }
    void MoveTank()
    {
        Vector3 movement = transform.forward * _movementInput * movementSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }
    void RotateTank()
    {
        float degreesToRotate = _rotationInput * rotationSpeed * Time.deltaTime;
        Quaternion yRotation = Quaternion.Euler(0, degreesToRotate, 0);
        _rigidbody.MoveRotation(_rigidbody.rotation * yRotation);
    }
}