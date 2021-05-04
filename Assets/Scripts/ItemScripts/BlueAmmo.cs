using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAmmo : Ammo
{
    protected override void updateItemCount() {

    }

    protected override void updateScore() {
        int points = 20;
        Debug.Log("+1 blue ammo");
    }
}
