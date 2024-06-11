using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public float gravity = 20f;
    public float rotspeed = 80f;
    float rotx = 0f;
    float roty = 0f;
    CameraController cinemachine;
    //CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        cinemachine = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        //cameramove();
        rotx += Input.GetAxis("Mouse X") * rotspeed * Time.deltaTime;
        roty += Input.GetAxis("Mouse Y") * rotspeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotx, 0);
    }
    void cameramove()
    {
        rotx += Input.GetAxis("Mouse X") * rotspeed * Time.deltaTime;
        roty += Input.GetAxis("Mouse Y") * rotspeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, 0, 0);
        //transform.position=new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(roty, rotx, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        //moveDirection.x =0;
        //characterController.Move(moveDirection * Time.deltaTime);
        cinemachine.MovementSmoothingValue = moveDirection.y*Time.deltaTime;
    }
}
