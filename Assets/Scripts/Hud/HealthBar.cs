using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{
    public Image Health;
    private float fillAmount;
    private float fullHealth = 1.0f;
    //private int maxHealthCount = 500; // 500 health.

    // Start is called before the first frame update
    void Start()
    {
       Health.fillAmount = fullHealth;
    }

    // public updateHealth(int newHealth) {

    // }

}
