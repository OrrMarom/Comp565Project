using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HealthBar : MonoBehaviour
{
    public Image Health;
    private float fillRatio; 
    private float fillAmount;
    private float completeFill = 1.0f;
    private int playerHealth;
    public int fullHealth = 1000;

    public int getPlayerHealth() {
        return playerHealth;
    }

    public void setPlayerHealth(int newHealth) {
        playerHealth = newHealth;
    }

    public void changeFillAmount() {
        fillRatio = ((float) playerHealth) / fullHealth;
        if (fillRatio < 0.05f) {
            fillRatio = 0.0f;
        }
        Debug.Log("fillRatio: " + fillRatio);

        Health.fillAmount = fillRatio;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = fullHealth;
        Health.fillAmount = completeFill;
    }
}
