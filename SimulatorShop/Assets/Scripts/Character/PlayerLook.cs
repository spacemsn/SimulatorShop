using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform player;

    public float Sensitivity = 100.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    float _rotationX = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);

        player.transform.Rotate(Vector3.up * mouseX);
    }
}
