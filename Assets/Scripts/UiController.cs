using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Slider healthSlider;
    public Image fill;
    public Gradient gradient;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health){

        healthSlider.value = health;

        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void setMaxHealth(int health) {

        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
}
