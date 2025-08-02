using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 3f, -5f);

    public float rotationSpeed = 100f;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        horizontalInput *= -1.0f;

        Quaternion horizontalTurnAngle = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up);

        offset = horizontalTurnAngle * offset;
        
        Quaternion verticalTurnAngle = Quaternion.AngleAxis(verticalInput * rotationSpeed * Time.deltaTime, transform.right);

        offset = verticalTurnAngle * offset;
        
        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}