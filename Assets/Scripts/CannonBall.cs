using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RobotMovement>())
        {
            // Lose one life from the lives
            GameManager.Instance.LoseLife();

            Destroy(collision.gameObject); // Destroy the Robot
            Destroy(gameObject); // Destroy myself -> CannonBall
        }
    }
}
