using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{
    public Image Health;
    private float fillPercent; 
    private float fillAmount;
    private float fullHealth = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       Health.fillAmount = fullHealth;
    }

    // public updateHealth(int newHealth) {

    // }

}
