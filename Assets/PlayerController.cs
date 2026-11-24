using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float walkSpeed, runSpeed, gravity, jumpHeight, turnSpeed, smooth;

    CharacterController controller;

    float vertVelo;
    Animator animator;

    public Transform child;
  

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        vertVelo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //read input
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 horizontal = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (moveInput == Vector2.zero) //not moving
        {
            animator.SetInteger("State", 0); //state 0 is IDLE
        }
        else
        {

            animator.SetInteger("State", Input.GetKey(KeyCode.LeftShift) ? 2 : 1); //state 1 is walk

            Quaternion targetRotation = Quaternion.LookRotation(horizontal);

            child.rotation = Quaternion.Slerp(child.rotation, targetRotation, smooth * Time.deltaTime);
        }


        

        
        
        



        if ( controller.isGrounded) //on ground
        {
            vertVelo = -10f;

            if (Input.GetKeyDown(KeyCode.Space))
                vertVelo = jumpHeight;


        }
        else
        {
            vertVelo -= gravity * Time.deltaTime;

        }

        // <condition> ? <value if true> : <value if false>
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        controller.Move( horizontal * speed * Time.deltaTime + vertVelo * Vector3.up * Time.deltaTime);

        transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime );


    }
}
