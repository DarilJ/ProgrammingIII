using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TesterScript : MonoBehaviour

{
    public CharacterBase myCharacter;

    public Slider healthBar;
    public GameObject damageEffectObject;
    public GameObject healEffectObject;

    public UnityEvent<float, bool> OnHealthChange = new UnityEvent<float, bool>();

    void Start()
    {
        myCharacter.currentHealth = myCharacter.maxHealth;
        healthBar.value = myCharacter.currentHealth;

        OnHealthChange.AddListener(UpdateHealth);
        OnHealthChange += UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = myCharacter.currentHealth;

        if (Input.GetMouseButtonDown(0))
        {
            ApplyChange(-myCharacter.damage, false); // Aplica dano
        }

        if (Input.GetMouseButtonDown(1))
        {
            ApplyChange(myCharacter.heal, true); // Aplica cura
        }
    }
    void ApplyChange(float amount, bool isHealing)
    {
        myCharacter.currentHealth += amount;

        // Certifique-se de que a saúde não ultrapasse os limites
        myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);

        // Notifique os ouvintes com o valor do dano ou cura e se é cura ou dano
        OnHealthChange?.Invoke(amount, isHealing);
    }
    public void UpdateHealth(float amount, bool isHealing)
    {
        if (isHealing)
        {
            Debug.Log("You were healed by " + amount + " health points");
        }
        else
        {
            Debug.Log("You lost " + amount + " health points");
        }
        if (isHealing)
        {
            healEffectObject.SetActive(true);
            healEffectObject.GetComponent<AudioSource>().Play();
            healEffectObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            damageEffectObject.SetActive(true);
            damageEffectObject.GetComponent<AudioSource>().Play();
            damageEffectObject.GetComponent<ParticleSystem>().Play();
        }
        if (myCharacter.currentHealth <= 0)
        {
            myCharacter.currentHealth = 0;
            Debug.Log("You are dead");
        }
        else if (myCharacter.currentHealth >= myCharacter.maxHealth)
        {
            myCharacter.currentHealth = myCharacter.maxHealth;
            Debug.Log("Your life is at the maximum");
        }
    }
}
