using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(PlayerController)))
        {
            if (MazeLevel.Instance.getKeyCount() == 0) {
                MazeLevel.Instance.GameClear();
            }
        }
    }
}
