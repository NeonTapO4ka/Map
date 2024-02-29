using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float moveSpeed = 5f;                   
    public float rotationSpeed = 100f;             
    private Rigidbody rb;
    private float rotation = 0f;
    private void Start(){
        rb = GetComponent<Rigidbody>();            
    }
    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");       
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * Time.deltaTime);
        rotation += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, rotation, 0f);
        float camRotationX = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        Camera.main.transform.RotateAround(transform.position, transform.right, -camRotationX);
    }
}
