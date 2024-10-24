using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamageable
{
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;

    private float vSpeed = 0;

    public float jumpSpeed;
    public Animator animator;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    private void Update()
    {
        transform.Rotate(0,Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime,0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
            }
        }


        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        var isWalking = inputAxisVertical != 0;

        if (isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        characterController.Move(speedVector * Time.deltaTime);
        animator.SetBool("Run", inputAxisVertical != 0);
        
    }

    public void Damage(float damage, bool antiChicken)
    {
       //Do nothing here
    }

    public void Damage(float damage, bool antiChicken, Vector3 dir)
    {
        Damage(damage);
    }

    public void Damage(float damage)
    {
        flashColors.ForEach(i => i.Flash());
    }
}
