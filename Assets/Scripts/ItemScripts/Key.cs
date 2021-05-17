using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectibleItem
{
    private int points = 100;
    protected override void updateItemCount() {
        if (MazeLevel.Instance.getKeyCount() > 0) {
            MazeLevel.Instance.subtractKeyCount(1);
        }    
    }

    protected override void updateScore() {
        Debug.Log("+1 key.");
        MazeLevel.Instance.addToScore(points);
    }
}
