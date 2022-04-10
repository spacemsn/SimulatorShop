using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]// Привязка будет через компонент CharacterController

public class controllPlayer : MonoBehaviour
{ 
    [Header("Rigging Player")]
    public Transform AimConst;

    [Header("Характеристики персонажа")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header("Камера персонажа")]
    public Camera playerCamera;

    CharacterController characterController;
    Animator animator;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    // переменная для поднятия объектов в руку 
    public bool Take;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // Видимость курсора
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Нажитие Shift = бег
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        animator.SetFloat("Speed", Vector3.ClampMagnitude(moveDirection, 1).magnitude);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = 0.6f;
        }
        else
        {
            characterController.height = 1.2f;
            moveDirection.y = movementDirectionY;
        }

        //Гравитация
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
        

        // Поворот камеры  и игрока
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        Ray desiredAimRay = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Vector3 desiredPosition = desiredAimRay.origin + desiredAimRay.direction * 0.7f;
        AimConst.position = desiredPosition;

    }
}
