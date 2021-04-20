using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;

public class CharacterScript : MonoBehaviour
{
    DataSingleton dataSingleton;
    Animator constrainerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        dataSingleton = DataSingleton.Instance;
        constrainerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dataSingleton.getPersonCamera() == 0) // first person camera
        {
            if (Input.GetKey(KeyCode.C)) //switch to second person
            {
                dataSingleton.setPersonCamera(1);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/Running") as RuntimeAnimatorController;
                    constrainerAnimator.Play("Entry");
                }
            } else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/Walking") as RuntimeAnimatorController;
                    constrainerAnimator.Play("Entry");
                }
            }
            

            if (Input.GetKeyUp(KeyCode.W))
            {
                if (dataSingleton.getHoldingWeapon() == false)
                {
                    constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/NoWeaponIdle") as RuntimeAnimatorController;
                    constrainerAnimator.Play("Entry");
                } 
                else
                {
                    constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/WeaponIdle") as RuntimeAnimatorController;
                    constrainerAnimator.Play("Entry");
                }
            }
        } 
        else if (dataSingleton.getPersonCamera() == 1) // second person camera
        {
            if (Input.GetKey(KeyCode.C)) //switch to first person
            {
                dataSingleton.setPersonCamera(0);
            }
        }
    }
}
