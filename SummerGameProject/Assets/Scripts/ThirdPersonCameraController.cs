using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 10f;
    public float rotationSmoothness = 10f;

    private float currentXRotation = 0f;
    private float currentYRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        currentYRotation -= mouseY;
        currentYRotation = Mathf.Clamp(currentYRotation, -45f, 45f);

        currentXRotation += mouseX;
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentYRotation, currentXRotation, 0f);
        Vector3 cameraPosition = playerTransform.position - rotation * new Vector3(0, 0, distanceFromPlayer);
        
        transform.position = Vector3.Lerp(transform.position, cameraPosition, rotationSmoothness * Time.deltaTime);
        transform.LookAt(playerTransform);
    }
}
