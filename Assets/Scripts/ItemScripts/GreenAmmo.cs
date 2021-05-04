using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAmmo : Ammo
{
    private int points = 15;

    protected override void updateItemCount() {
        MazeLevel.Instance.addAmmoG(1);
    }

    protected override void updateScore() {
        MazeLevel.Instance.addToScore(points);
    }
}
