using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMoovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed=6f;
    public float gravity = 20f;
    //Vector3 direction;
    public float turnsmoothtime = 0.1f;
    float turnsmoothvvelocity;

    Animator animator;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if (vertical != 0 || horizontal != 0)
            {
                animator.SetBool("isWalk", true);
            }
            else
            {
                animator.SetBool("isWalk", false);
            }
            if (direction.magnitude >= 0.1f)
            {
                float targetangel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangel, ref turnsmoothvvelocity, turnsmoothtime);
                transform.rotation = Quaternion.Euler(0f, angel, 0f);
                //direction = Vector3.forward;
                Vector3 movedirection = Quaternion.Euler(0f, targetangel, 0f) * Vector3.forward;
                direction.y -=gravity*Time.deltaTime;
                controller.Move(movedirection.normalized * speed * Time.deltaTime);
            }

        
        }
    }
