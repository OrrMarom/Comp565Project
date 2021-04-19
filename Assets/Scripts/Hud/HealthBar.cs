using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{
    public Image Health;

    // Start is called before the first frame update
    void Start()
    {
       Health.fillAmount = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
