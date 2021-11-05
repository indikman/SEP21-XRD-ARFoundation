using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float turnSpeed = 50;
    public Transform spawnPoint;
    public GameObject cannonBallPrefab;
    public float ShootingForce = 40f;

    private GameObject robot;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootAtPlayer", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        robot = IsRobot();

        if (!robot)
        {
            return;
        }
        else
        {
            // Rotate the cannot towards the player/ robot

            Vector3 targetDirection = robot.transform.position - transform.position;
            Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(direction);
        }

    }

    private void ShootAtPlayer()
    {
        if (robot)
        {
            GameObject newCannonBall = Instantiate(cannonBallPrefab, spawnPoint.position, spawnPoint.rotation);
            newCannonBall.GetComponent<Rigidbody>().AddForce(cannonBallPrefab.transform.forward * ShootingForce);

            // Destroy the cannonball after 2 seconds
            Destroy(newCannonBall, 2f);
        }
    }

    private GameObject IsRobot()
    {
        RobotMovement robot = FindObjectOfType<RobotMovement>();

        if (robot)
        {
            return robot.gameObject;
        }

        return default;

    }

}
