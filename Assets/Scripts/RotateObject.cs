using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObject : MonoBehaviour
{
    // Các Input Action giờ là biến riêng tư, không cần gán từ Inspector
    private InputAction mouseDeltaAction;
    private InputAction rightClickAction;

    [Header("Rotation Settings")]
    [SerializeField] private float speed = 100f;
    [SerializeField] private bool invertX;
    [SerializeField] private bool invertY;

    private Transform camTransform;

    private void Awake()
    {
        camTransform = Camera.main.transform;

        // KHỞI TẠO ACTION TRỰC TIẾP TRONG CODE
        // Gán hành động cho nút chuột phải
        rightClickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/rightButton");
        
        // Gán hành động cho việc di chuyển chuột
        mouseDeltaAction = new InputAction(type: InputActionType.Value, binding: "<Mouse>/delta");
    }

    private void OnEnable()
    {
        // Kích hoạt các action khi object được bật
        rightClickAction.Enable();
        mouseDeltaAction.Enable();
    }

    private void OnDisable()
    {
        // Vô hiệu hóa và giải phóng bộ nhớ khi object bị tắt để tránh memory leak
        rightClickAction.Disable();
        mouseDeltaAction.Disable();
    }

    private void Update()
    {
        // Logic không đổi: chỉ xoay khi nút chuột phải được giữ
        if (rightClickAction.IsPressed())
        {
            Vector2 mouseDelta = mouseDeltaAction.ReadValue<Vector2>();
            ApplyRotation(mouseDelta);
        }
    }

    private void ApplyRotation(Vector2 delta)
    {
        if (delta.sqrMagnitude <= 0.01f)
        {
            return;
        }
        
        delta *= speed * Time.deltaTime;

        float inversionX = invertX ? -1f : 1f;
        float inversionY = invertY ? 1f : -1f;

        transform.Rotate(camTransform.up, delta.x * inversionX, Space.World);
        transform.Rotate(camTransform.right, delta.y * inversionY, Space.World);
    }
}
