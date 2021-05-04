using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAmmo : Ammo
{
    protected override void updateItemCount() {

    }

    protected override void updateScore() {
        int points = 15;
        Debug.Log("+1 green ammo");
    }
}
