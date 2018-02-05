using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    float speedPower = 10.0f;
    float jumpPower = 30.0f;
    float gravityPower = 10.0f;
    float inAirVelocity = 0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var motion = transform.transform.right * Input.GetAxis("Horizontal");
        motion *= speedPower;

        if (controller.isGrounded && Input.GetButtonDown("Jump")) {
            inAirVelocity = jumpPower;
        }
        motion.y = inAirVelocity - gravityPower;
        controller.Move(motion * Time.deltaTime);

        inAirVelocity -= gravityPower * .2f;
        if (inAirVelocity < 0)
        {
            inAirVelocity = 0;
        }
}
}
