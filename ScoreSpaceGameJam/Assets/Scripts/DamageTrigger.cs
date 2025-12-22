using UnityEngine;
using System;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;

    [SerializeField] AudioSource lifeSource;
    [SerializeField] AudioClip minusLife;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Grab ball component from ball
        Ball ball = other.GetComponent<Ball>();
        if (ball == null) return;

        //Grab other rigidbody2D
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        if (otherRb == null) return;

        //Checks if the y velocity is negative and if the ball made it to height
        if (otherRb.linearVelocity.y < 0f)
        {
            Debug.Log("You lost a life");

            lifeSource.PlayOneShot(minusLife);
            GameManager.Instance?.LoseLife(1);

            Destroy(other.gameObject);
        }
    }
}
