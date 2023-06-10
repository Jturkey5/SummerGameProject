using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public Transform playerBody;
    [Range(0.1f, 9f)] private float sensitivity = 3f;
    [Range(0f, 90f)] private float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        playerBody.rotation = Quaternion.Euler(0, rotation.x, 0);
        transform.localRotation = Quaternion.Euler(-rotation.y, 0, 0);
    }
}
