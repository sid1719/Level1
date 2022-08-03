using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 jump;
    private CharacterController charController;
    private CharacterAnimations charAnimations;

    public float movement_speed = 2f, jumpForce =2f;
    public float gravity = 9.8f;
    public float rotation_speed=0.15f;
    public float rotateDegreesPerSecond = 180f;
    // Start is called before the first frame update
    void Awake()
    {
        charController = GetComponent<CharacterController>();
        charAnimations = GetComponent<CharacterAnimations>();
     
    }
 
    // Update is called once per frame
    void Update()
    {
        Move();
        Fly();
        Rotate();
        AnimateWalk();
    }

    void  Fly()
    {
        if(Input.GetKey(KeyCode.Space))
        {
                                
            Vector3 moveDirection = transform.up;
           // moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_speed*30 * Time.deltaTime);
            this.transform.position = new Vector3(this.transform.position.x, 3f, this.transform.position.z);
            charAnimations.Fly();
        }
    
    }
    void Move()
    {
        if(Input.GetAxis("Vertical")>0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_speed * Time.deltaTime);
        }
        else if(Input.GetAxis("Vertical")<0)

        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_speed * Time.deltaTime);
        }
        else
        {
            charController.Move(Vector3.zero);
        }
    }
    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis("Horizontal") > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }
        if (Input.GetAxis("Horizontal") < 0)

        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }

        if(rotation_Direction!=Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }
    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude!=0)
        {
            charAnimations.Walk(true);
        }
        else
        {
            charAnimations.Walk(false);
        }
    }
}
