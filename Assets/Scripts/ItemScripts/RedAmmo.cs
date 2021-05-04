using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAmmo : Ammo
{

    protected override void updateItemCount() {

    }

    protected override void updateScore() {
        int points = 25;
        Debug.Log("+1 red ammo");
        //Debug.Log("test: " + testing);
    }
}
