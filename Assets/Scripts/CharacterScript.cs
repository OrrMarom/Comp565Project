using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;

public class CharacterScript : MonoBehaviour
{
    DataSingleton dataSingleton;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        dataSingleton = DataSingleton.getInstance();
        anim = this.GetComponent<Animator>();
        anim.SetBool("Carrying Weapon", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && dataSingleton.getHoldingWeapon() == true)
        {
            dataSingleton.setHoldingWeapon(false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walking", true);
        } 
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            dataSingleton.setThrowingGrenate(true);
            anim.SetBool("Throwing Grenate", true);   
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Punch", true);
        } 
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetBool("Hard Punch", true);
        }
        else
        {
            //reseting everything
            if (dataSingleton.getThrowingGrenate() == true)
            {
                dataSingleton.setThrowingGrenate(false);
                anim.SetBool("Throwing Grenate", false);
            }
            
            if (dataSingleton.getHoldingWeapon() == true)
            {
                anim.SetBool("Carrying Weapon", true);
            } 
            else
            {
                anim.SetBool("Carrying Weapon", false);
            }

            anim.SetBool("Punch", false);
            anim.SetBool("Hard Punch", false);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walking", false);
        }

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            
            if (Input.GetKey(KeyCode.Q) && dataSingleton.getNumberOfGrenates() > 0)
            {
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/ThrowGrenate") as RuntimeAnimatorController;
                constrainerAnimator.Play("Entry");
            }
            else if (Input.GetKey(KeyCode.W))
            {
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/Running") as RuntimeAnimatorController;
                constrainerAnimator.Play("Entry");
            }
            else if (Input.GetKey(KeyCode.Mouse0) && dataSingleton.getHoldingWeapon() == false)
            {
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/HardPunch") as RuntimeAnimatorController;
                constrainerAnimator.Play("Entry");
            }

        } 
        else
        {
            if (Input.GetKey(KeyCode.Q) && dataSingleton.getNumberOfGrenates() > 0)
            {
                dataSingleton.setThrowingGrenate(true);
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/ThrowGrenate") as RuntimeAnimatorController;
                constrainerAnimator.Play("Entry");
                dataSingleton.setThrowingGrenate(false);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/Walking") as RuntimeAnimatorController;
                constrainerAnimator.Play("Entry");
            } 
            else if (Input.GetKey(KeyCode.Mouse0) && dataSingleton.getHoldingWeapon() == false)
            {
                constrainerAnimator.runtimeAnimatorController = Resources.Load("Character Anim/Punch") as RuntimeAnimatorController;
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
        }*/
    }
}
