using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController _charController;
    Vector3 moveDirection;

    public float speed = 0.0f;
    public float jumpHeight = 0.0f;
    private float gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical"); 
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        animator.SetFloat("Speed", Vector3.ClampMagnitude(movement, 1).magnitude);

        if (_charController.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                movement.y += jumpHeight;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.x *= 2;
            }
            if(Input.GetKey(KeyCode.LeftControl))
            {
                _charController.height = 0.6f;
            }
            else
            {
                _charController.height = 1.23f;
            }
            Debug.Log("isGround is true");
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
            Debug.Log("isGround is false");
        }
        movement = transform.TransformDirection(movement);
        _charController.Move(movement * Time.deltaTime);
        
    }

    void Move()
    {
        if (_charController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * speed;
            //moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpHeight;
            }
        }
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        _charController.Move(moveDirection * Time.deltaTime);
    }

}
