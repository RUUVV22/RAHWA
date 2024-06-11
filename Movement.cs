using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = 20f;
    public float jump = 8f;
    public float rotspeed = 80f;
    float rotx = 0f;
    float roty = 0f;
    float Hor;
    float Ver;
    CharacterController characterController;
    //Rigidbody rigidbody;
    Vector3 moveDirection = Vector3.zero;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        Hor = Input.GetAxis("Horizontal");
        Ver = Input.GetAxis("Vertical");
        if( characterController.isGrounded)
        {
            moveDirection=new Vector3(0, 0,Ver);
            moveDirection*=speed;
            moveDirection=transform.TransformDirection(moveDirection);
            if (Input.GetButton("Jump"))
            {
                animator.SetBool("isJumping", true);
                moveDirection.y=jump;
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
        if (Ver!=0)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10f;
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
            speed = 6f;
        }
        rotx += Input.GetAxis("Mouse X") * rotspeed * Time.deltaTime;
        //roty += Input.GetAxis("Mouse Y") * 50f * Time.deltaTime;

        //transform.eulerAngles = new Vector3(0, 0, 0);
        ////transform.position=new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotx, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        ////moveDirection.x =0;
        characterController.Move(moveDirection * Time.deltaTime);

    }
}
