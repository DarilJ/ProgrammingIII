using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class TesterScript : MonoBehaviour

{
    //declaring the scriptable object
    public CharacterBase myCharacter;

    public Slider healthBar;
    public GameObject damageEffectObject;
    public GameObject healEffectObject;

    /*
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip healing;
    [SerializeField]
    private AudioClip damage;
    */
    public UnityEvent<float, bool> OnHealthChange = new UnityEvent<float, bool>();

    void Start()
    {
        //_audioSource = GetComponent<AudioSource>();

        myCharacter.currentHealth = myCharacter.maxHealth;
        healthBar.value = myCharacter.currentHealth;

        OnHealthChange.AddListener(UpdateHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = myCharacter.currentHealth;

        if (Input.GetMouseButtonDown(0))
        {
            ApplyChange(-myCharacter.damage, false); // The damage is applied
        }

        if (Input.GetMouseButtonDown(1))
        {
            ApplyChange(myCharacter.heal, true); // Aplica cura
        }
    }
    public void ApplyChange(float amount, bool isHealing)
    {
        Debug.Log("ApplyChange called");
        myCharacter.currentHealth += amount;

        // Certifique-se de que a saúde não ultrapasse os limites
        myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);

        // Notifique os ouvintes com o valor do dano ou cura e se é cura ou dano
        OnHealthChange?.Invoke(amount, isHealing);

        UpdateHealth(amount, isHealing);
    }
    public void UpdateHealth(float amount, bool isHealing)
    {
        Debug.Log("UpdateHealth called");
        if (isHealing)
        {
            Debug.Log("You were healed by " + amount + " health points");
            /*
            _audioSource.clip = healing;
            _audioSource.Play();
            */
            healEffectObject.SetActive(true);
            //Debug.Log("isHealing = true");
            healEffectObject.GetComponent<AudioSource>().Play();
            //Debug.Log("Audio Source On");
            healEffectObject.GetComponent<ParticleSystem>().Play();
            //Debug.Log("Particles On");
        }
        else
        {
            Debug.Log("You lost " + amount + " health points");
            damageEffectObject.SetActive(true);
            //Debug.Log("isHealing = false");
            damageEffectObject.GetComponent<AudioSource>().Play();
            //Debug.Log("Audio Source On");
            damageEffectObject.GetComponent<ParticleSystem>().Play();
            //Debug.Log("Particles On");
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
