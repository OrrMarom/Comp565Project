using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{
    public Image Health;
    private float fillAmount;
    private float fullHealth = .75f;
    //private int maxHealthCount = 500; // 500 health.

    // Start is called before the first frame update
    void Start()
    {
       Health.fillAmount = 0.5f;
    }

    // public updateHealth(int newHealth) {

    // }

}
