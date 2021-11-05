using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;

    private Animator robotAnim;
    private Rigidbody robotBody;
    private Joystick joystick;


    void OnEnable()
    {
        robotAnim = GetComponent<Animator>();
        robotBody = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        //Play the open animation
        robotAnim.SetBool("Open_Anim", true);
    }

    // Update is called once per frame
    void Update()
    {

        //Movement of the robot
        if(joystick.Direction.magnitude > 0)
        {
            robotBody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        //Rotation of the robot
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);

        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
