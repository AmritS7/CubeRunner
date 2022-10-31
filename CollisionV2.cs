using UnityEngine;

public class CollisionV2 : MonoBehaviour
{
    public PlayerMovement movement;
    public Jump jump;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            jump.enabled = false;
            FindObjectOfType<GameManager>().gameOver();
        }

    }
}
