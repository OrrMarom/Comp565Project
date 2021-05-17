using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAmmo : Ammo
{
    private int points = 20;
    protected override void updateItemCount() {
        MazeLevel.Instance.addAmmoB(1);
    }

    protected override void updateScore() {
        MazeLevel.Instance.addToScore(points);
    }
}