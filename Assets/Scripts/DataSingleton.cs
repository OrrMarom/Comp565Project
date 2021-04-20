using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSingleton : MonoBehaviour
{

    private DataSingleton()
    {
    }

    private static DataSingleton instance = null;

    private int personCamera = 0; //0 -> first person, 1 -> third Person
    private bool holdingWeapon = true;


    public static DataSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataSingleton();
            }

            return instance;
        }
    }

    public void setHoldingWeapon(bool status)
    {
        holdingWeapon = status;
    }

    public void setPersonCamera (int value)
    {
        personCamera = value;
    }

    public int getPersonCamera()
    {
        return personCamera;
    }

    public bool getHoldingWeapon()
    {
        return holdingWeapon;
    }
}
