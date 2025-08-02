using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragObject : MonoBehaviour
{
    private Rigidbody selectedRb;
    private float initialDepth;
    private Vector3 offset;
    private Camera cam;
    
    // [SerializeField] private float speed = 100f;
    // [SerializeField] private bool invertX;
    // [SerializeField] private bool invertY;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << LayerMask.NameToLayer("TargetCollider");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.CompareTag("Drag"))
                {
                    selectedRb = hit.collider.GetComponent<Rigidbody>();

                    initialDepth = Vector3.Dot(hit.point - cam.transform.position, cam.transform.forward);
                    offset = hit.transform.position - GetMouseWorldPos();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedRb != null)
            {
                selectedRb = null;
            }
        }
        // if (Input.GetMouseButtonDown(1))
        // {
        //
        //     Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //     ApplyRotation(mouseDelta);
        // }
    }

    void FixedUpdate()
    {
        if (selectedRb != null)
        {
            Vector3 targetPosition = GetMouseWorldPos() + offset;
            selectedRb.MovePosition(targetPosition); // Moves with collision detection
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = initialDepth;
        return cam.ScreenToWorldPoint(mousePos);
    }
    
    // private void ApplyRotation(Vector2 delta)
    // {
    //     if (delta.sqrMagnitude <= 0.01f)
    //     {
    //         return;
    //     }
    //     
    //     delta *= speed * Time.deltaTime;
    //
    //     float inversionX = invertX ? -1f : 1f;
    //     float inversionY = invertY ? 1f : -1f;
    //
    //     transform.Rotate(cam.transform.up, delta.x * inversionX, Space.World);
    //     transform.Rotate(cam.transform.right, delta.y * inversionY, Space.World);
    // }
}