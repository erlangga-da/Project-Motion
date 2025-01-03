using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class MovementExperimental : MonoBehaviour
{
    private InputAction moveAction;
    private Animator animator;
    private bool isWalking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        // manggil input aja ribet banget bgst
        var inputAction = GetComponent<PlayerInput>().actions;
        moveAction = inputAction["Move"];
    }
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        // Vector3 axis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        // float moveCoordinat = Mathf.Clamp01(Mathf.Abs(axis.x) + Mathf.Abs(axis.z));

        // check iswalking ketika action move triggered
        // please don't fucking touch the transition need days to adjust that shit
        if (moveInput != Vector2.zero)
        {
            if (!isWalking) CheckWalk("Start Walking", 0.3f);
        }
        else
        {
            // TODO : kadang kayak tai anjing stopnya gajelas
            // cek kaki terakhir pas walking -> baru decision dah mau mirro apa ga stop walkingnya
            if (isWalking) CheckWalk("Stop Walking", 0.4f);
        }
    }

    // unnecessary shit but pretty
    private void CheckWalk(string anim_name, float fixedTrans)
    {
        animator.CrossFadeInFixedTime(anim_name, fixedTrans);
        isWalking = !isWalking;
    }

}
