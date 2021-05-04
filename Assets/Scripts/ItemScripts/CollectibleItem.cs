﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(PlayerController)))
        {
            itemBehavior();
            Destroy(this.gameObject);
        }
    }

    private void itemBehavior()
    {
        updateItemCount();
        updateScore();
    }

    protected virtual void updateItemCount() {

    }

    protected virtual void updateScore() {

    }

}
