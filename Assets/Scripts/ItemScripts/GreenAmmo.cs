using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Green: extra points
public class GreenAmmo : Ammo
{
    private int points = 50;

    protected override void itemBehavior() {

    }

    protected override void updateItemCount() {
        //MazeLevel.Instance.addAmmoG(1);
    }

    protected override void updateScore() {
        MazeLevel.Instance.addToScore(points);
    }
}
