using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Red: recover health
public class RedAmmo : Ammo
{
    private int points = 25;

    protected override void itemBehavior() {
        // recover health
    }

    protected override void updateItemCount() {
        //MazeLevel.Instance.addAmmoR(1);
    }

    protected override void updateScore() {
        MazeLevel.Instance.addToScore(points);
    }
}
