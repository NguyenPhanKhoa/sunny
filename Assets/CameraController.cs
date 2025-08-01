using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 3f, -5f);

    public float rotationSpeed = 100f;

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        Quaternion horizontalTurnAngle = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up);

        offset = horizontalTurnAngle * offset;

        float verticalInput = Input.GetAxis("Vertical");

        Quaternion verticalTurnAngle = Quaternion.AngleAxis(verticalInput * rotationSpeed * Time.deltaTime, transform.right);

        offset = verticalTurnAngle * offset;
        
        transform.position = target.position + offset;

        transform.LookAt(target);
    }
}