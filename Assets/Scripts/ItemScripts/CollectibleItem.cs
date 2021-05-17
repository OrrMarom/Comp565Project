using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(PlayerController)))
        {
            itemBehavior();
            updateItemCount();
            updateScore();
            Destroy(this.gameObject);
        }
    }

    protected virtual void itemBehavior() {

    }

    protected virtual void updateItemCount() {

    }

    protected virtual void updateScore() {

    }

}
