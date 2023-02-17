using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Sensibility")]
    public float sensibilityX;
    public float sensibilityY;

    [Header("Orientiation")]
    public Transform orientation;

    [Header("Rotation")]
    float xRotation;
    float yRotation;

    #region Cursor camera movement
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibilityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibilityY;

        yRotation += mouseX;
        xRotation -= mouseY;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    #endregion
}
