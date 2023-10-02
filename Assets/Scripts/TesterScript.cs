using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TesterScript : MonoBehaviour

{
    public CharacterBase myCharacter;

    public float healthPoints;
    public float maxHealth;
    public float currentHealth;
    public Slider healthBar;
    public GameObject damageEffectObject;
    public GameObject healEffectObject;

    void Start()
    {
        healthPoints = myCharacter.healthPoints;
        maxHealth = myCharacter.maxHealth;
        currentHealth = myCharacter.currentHealth;
        maxHealth = 100;
        healthPoints = maxHealth;
        healthBar.value = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = healthPoints;
        

        if (Input.GetMouseButtonDown(0))
        {
            healthPoints -= 10;
            damageEffectObject.SetActive(true);
            damageEffectObject.GetComponent<AudioSource>().Play();
            damageEffectObject.GetComponent<ParticleSystem>().Play();

            if (healthPoints <= 0)
            {
                healthPoints = 0;
                Debug.Log("You are dead");
            }
            else
            {
                Debug.Log("You lost 10 health points");
                Debug.Log(healthPoints);
                healthBar.value = healthPoints;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            healthPoints += 10;
            healEffectObject.SetActive(true);
            healEffectObject.GetComponent<AudioSource>().Play();
            healEffectObject.GetComponent<ParticleSystem>().Play();

            healthBar.value = healthPoints;
            if (healthPoints > 100)
            {
                healthPoints = 100;
                Debug.Log("Your life is at the maximum");
            }
            else
            {
                Debug.Log("You were healed in 10 health points");
                Debug.Log(healthPoints);
            }       
        }

        
    }
}
