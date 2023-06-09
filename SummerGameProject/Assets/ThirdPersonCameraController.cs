using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float mouseSensitivity = 100f;
    public float distanceFromPlayer = 10f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -45f, 45f);

        xRotation += mouseX;

        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
        Vector3 adjustedPosition = Quaternion.Euler(yRotation, xRotation, 0f) * direction;

        transform.position = playerTransform.position + adjustedPosition;
    }
}
