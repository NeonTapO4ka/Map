using UnityEngine;

public class DroneController : MonoBehaviour
{
    CharacterController _characterController;
    private Camera _playerCamera;
    public float flyingSpeed = 5.0f;
    public float hoverSpeed = 3.0f;
    public float ascendSpeed = 5.0f;
    public float descendSpeed = 5.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public LayerMask waterLayer;
    private Vector3 _moveDirection = Vector3.zero;
    private float _rotationX = 0;
    public bool canMove = true;
    private Vector3 _forward;
    private Vector3 _right;

    private void Start()
    {
        _playerCamera = Camera.main;
        _characterController = GetComponent<CharacterController>();
        Update();
    }

    private void Update()
    {
        _forward = transform.TransformDirection(Vector3.forward);
        _right = transform.TransformDirection(Vector3.right);
        var curSpeedX = canMove ? flyingSpeed * Input.GetAxis("Vertical") : 0;
        var curSpeedY = canMove ? flyingSpeed * Input.GetAxis("Horizontal") : 0;
        var movementDirectionY = _moveDirection.y;
        _moveDirection = (_forward * curSpeedX) + (_right * curSpeedY);
        
        if (Input.GetKey(KeyCode.LeftControl)&& canMove)
        {
            _moveDirection.y = -hoverSpeed;
        }
        else if (Input.GetKey(KeyCode.Space)&& canMove)
        {
            _moveDirection.y = ascendSpeed;
        }
        else
        {
            _moveDirection.y = 0;
        }
        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }
        

        _characterController.Move(_moveDirection * Time.deltaTime);

        if (!canMove) return;

        _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}