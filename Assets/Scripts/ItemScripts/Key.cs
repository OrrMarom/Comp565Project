using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectibleItem
{
    protected override void updateItemCount() {

    }

    protected override void updateScore() {
        int points = 100;
        Debug.Log("+1 key.");
    }
}
