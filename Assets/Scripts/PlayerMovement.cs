using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float moveAmount = Mathf.Clamp01(Mathf.Abs(movement.x) + Mathf.Abs(movement.z));

        animator.SetFloat("IdleToMove", moveAmount);
        animator.SetFloat("MoveSpeed", Mathf.Clamp01(Input.GetAxis("Running")));

        if (moveAmount > 0f)
        {
            Vector3 cam = Camera.main.transform.forward;
            movement = Quaternion.LookRotation(new Vector3(cam.x, 0f, cam.z)) * movement;
            Quaternion target_rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, 500 * Time.deltaTime);
        }
    }
}
