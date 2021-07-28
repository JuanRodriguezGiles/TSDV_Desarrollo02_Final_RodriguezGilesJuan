using UnityEngine;
public class PerpendicularMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public Transform raycastPoint;
    public GameObject tankModel;

    Vector3 _forwardDirection;
    float _rotationInput;
    float _movementInput;

    void Update()
    {
        _movementInput = Input.GetAxis("Vertical");
        _rotationInput = Input.GetAxis("Horizontal") * rotationSpeed;
    }
    void FixedUpdate()
    {
        GroundTank();
        RotateTank();
        MoveTank();
    }
    void GroundTank()
    {
        RaycastHit hit;
        Physics.Raycast(raycastPoint.position, Vector3.down, out hit);
        transform.up -= (transform.up - hit.normal) * 0.1f;
    }
    void RotateTank()
    {
        _rotationInput *= Time.deltaTime;
        tankModel.transform.Rotate(0.0f, _rotationInput, 0.0f);
    }
    void MoveTank()
    {
        _forwardDirection = tankModel.transform.forward;
        transform.position += _forwardDirection * Time.deltaTime * movementSpeed * _movementInput;
    }
}