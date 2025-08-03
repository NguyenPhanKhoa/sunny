using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target & Offset")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1.6f, -5f);

    [Header("Controls")]
    public float rotationSpeed = 100f;
    public float zoomSpeed = 10f; // Tốc độ zoom
    public float minZoomDistance = 2f; // Khoảng cách zoom gần nhất
    public float maxZoomDistance = 10f; // Khoảng cách zoom xa nhất

    private float horizontalInput;
    private float verticalInput;
    private float scrollInput; // Input từ lăn chuột

    void Update()
    {
        // Lấy input từ các trục và chuột
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        scrollInput = Input.GetAxis("Mouse ScrollWheel"); // Lấy giá trị lăn chuột
    }

    // Nên dùng LateUpdate cho camera để đảm bảo mọi di chuyển, tính toán vật lý của đối tượng
    // đã hoàn thành trong Update() và FixedUpdate(), tránh bị giật hình (jitter).
    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // --- Xử lý Zoom ---
        // Tính toán khoảng cách mới dựa trên input lăn chuột
        // offset.magnitude là khoảng cách hiện tại từ camera tới target
        float newDistance = offset.magnitude - scrollInput * zoomSpeed;

        // Giới hạn khoảng cách zoom trong khoảng min và max
        newDistance = Mathf.Clamp(newDistance, minZoomDistance, maxZoomDistance);

        // Cập nhật lại offset với khoảng cách mới, nhưng giữ nguyên hướng
        offset = offset.normalized * newDistance;


        // --- Xử lý xoay Camera ---
        // Xoay ngang (quanh trục Y của thế giới)
        Quaternion horizontalTurnAngle = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up);
        offset = horizontalTurnAngle * offset;

        // Xoay dọc (quanh trục X của camera)
        Quaternion verticalTurnAngle = Quaternion.AngleAxis(-verticalInput * rotationSpeed * Time.deltaTime, transform.right);
        offset = verticalTurnAngle * offset;


        // --- Cập nhật vị trí và hướng của Camera ---
        // Đặt vị trí camera bằng vị trí target + offset đã được tính toán
        transform.position = target.position + offset;

        // Luôn nhìn về phía target
        transform.LookAt(target);
    }
}