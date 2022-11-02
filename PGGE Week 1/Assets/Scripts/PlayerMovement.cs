using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    CharacterController characterController;

    [SerializeField] 
    Animator animator;

    [SerializeField] 
    float walkSpeed = 1f;

    [SerializeField] 
    float rotateSpeed = 25.0f;

    void Start()
    {
        //characterController = GetComponent<CharacterController>();
       // animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator == null) return;
        if(characterController == null) return;


        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        float speed = walkSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 2 * walkSpeed;
        }

        transform.Rotate(0.0f, hInput * rotateSpeed * Time.deltaTime, 0.0f);

        Vector3 forward = transform.forward;
        characterController.Move(forward * vInput * speed * Time.deltaTime);

        float movementValue = vInput * speed / (2.0f * walkSpeed);

        animator.SetFloat("PosZ", movementValue);
    
    }
}
