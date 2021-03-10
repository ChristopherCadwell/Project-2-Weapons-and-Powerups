using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidPawn : Pawn
{
    //serialized so this can be accessed in editor
    [SerializeField, Tooltip("The max speed of the character")]
    private float speed = 6f;

    [SerializeField, Tooltip("Character's turning speed")]
    private float rotateSpeed = 90;

    Rigidbody pchar;

    //movement
    private float moveRight;
    private float moveUp;

    
    public override void Start()
    {
        pchar = GetComponent<Rigidbody>();//get rigidbody
        base.Start();
    }

    public override void Update()
    {
        base.Update();

    }
    public override void Move(Vector3 moveDirection)
    {
        //convert from "stick space" to worldspace so movement is based on player rotation
        moveDirection = transform.InverseTransformDirection(moveDirection);

        anim.SetFloat("Forward", moveDirection.z * speed);//set animation speed to input value * speed
        moveUp = anim.GetFloat("Forward");//set move up to match

        anim.SetFloat("Right", moveDirection.x * speed);//set animation speed to input value * speed
        moveRight = anim.GetFloat("Right");//set move right to match

        base.Move(moveDirection);//call move from parent
    }
    public override void RotateTowards(Vector3 targetPoint)
    {
        //create local var for rotation quaternion
        Quaternion targetRotation;

        //find rotation to point
        Vector3 vectorToTarget = targetPoint - transform.position; //endpoint - startpoint  where we are going to look, and where we are looking
        targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);//determine where to look
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);//combine the previous steps, and look based on frames
        base.RotateTowards(targetPoint);
    }
    
    
}