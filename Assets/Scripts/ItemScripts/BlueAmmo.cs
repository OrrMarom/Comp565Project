using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Blue: increases remaining time
public class BlueAmmo : Ammo
{
    private int points = 20;
    private int seconds = 10;

    protected override void itemBehavior() {
        MazeLevel.Instance.addToTime(seconds); 
    }

    protected override void updateItemCount() {
        //MazeLevel.Instance.addAmmoB(1);
    }

    protected override void updateScore() {
        MazeLevel.Instance.addToScore(points);
        //MazeLevel.Instance.addToTime(10);
    }
}