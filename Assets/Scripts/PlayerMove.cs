using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    [Range(1, 10)]
    [SerializeField] private float speed;
    private void Update()
    {
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rigidbody.velocity = movement * speed;
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.z);
        if (movement != Vector3.zero)
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);
    }
    private void FixedUpdate()
    {

    }
}
