using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int maxHealth, currentHealth;
    private float invincCounter;
    public float invincibleLenght;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        currentHealth = maxHealth;

        UiController.instance.healthSlider.maxValue = maxHealth;
        UiController.instance.healthSlider.maxValue = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0){
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount){

        if(invincCounter <= 0){

            currentHealth -= damageAmount;

            if(currentHealth <= 0){

                currentHealth = 0;
            }

            invincCounter = invincibleLenght;

            UiController.instance.healthSlider.maxValue = maxHealth;
            UiController.instance.healthSlider.maxValue = currentHealth;
        }
    }
}
