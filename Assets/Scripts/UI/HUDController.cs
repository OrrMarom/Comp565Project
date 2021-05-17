using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    // Global Instance
    private static HUDController HUDInstance;
    public static HUDController Instance { get { return HUDInstance; } }

    // Text variables
    [SerializeField] private TextMeshProUGUI timeLabel;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    //[SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI ammoRLabel; // bullet
    [SerializeField] private TextMeshProUGUI ammoGLabel; // health
    [SerializeField] private TextMeshProUGUI ammoBLabel; // time
    [SerializeField] private TextMeshProUGUI keyLabel;

    // Update Methods
    public void updateTime(int time) {
        timeLabel.text = time.ToString();
    }

    public void updateScore(int score) {
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void updateHealth() {
        
    }

    public void updateAmmoR(int ammoCount) {
        ammoRLabel.text = ammoCount.ToString();
    }

    public void updateAmmoG(int ammoCount) {
        ammoGLabel.text = ammoCount.ToString();
    }

    public void updateAmmoB(int ammoCount) {
        ammoBLabel.text = ammoCount.ToString();
    }

    public void updateKeyLabel(int keysLeft) {
        keyLabel.text = "Keys Left: " + keysLeft.ToString();
    }

    // Avoid singleton copies.
    private void Awake() 
    {
        if (HUDInstance != null && HUDInstance != this)
        {
            Destroy(this.gameObject);
        } else {
            HUDInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // update HUD
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
