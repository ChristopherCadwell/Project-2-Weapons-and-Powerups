using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    //create  objects
    public Animator anim;
    public Weapons equippedWeapon;
 
    public virtual void Awake()
    {
        
    }
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }
    public virtual void Move(Vector3 moveDirection)
    {

    }
    public virtual void RotateTowards(Vector3 targetPoint)
    {

    }
    public virtual void Jump(Vector3 moveDirection)
    {

    }
    public virtual void EquipWeapon(Weapons weaponToEquip)
    {
        //handled in children
    }
    public void OnAnimatorIK(int layerIndex)
    {
        if (!equippedWeapon)
        {
            return;//no weapon, do nothing
        }
       if (equippedWeapon.rightHandPoint)//weapon has a right hand point
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, equippedWeapon.rightHandPoint.position);//tell animator to line up hand bones with right hand item point
            anim.SetIKRotation(AvatarIKGoal.RightHand, equippedWeapon.rightHandPoint.rotation);//same with rotation
            
            //set weights
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);//how much to override other animations, 0-1
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        }
        if (equippedWeapon.leftHandPoint)//weapon has a left hand point
        {
            //position and rotation
            anim.SetIKPosition(AvatarIKGoal.LeftHand, equippedWeapon.leftHandPoint.position);//same for left hand
            anim.SetIKRotation(AvatarIKGoal.LeftHand, equippedWeapon.leftHandPoint.rotation);
            //weight
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        } 
    }
}
