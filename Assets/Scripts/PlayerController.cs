using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterBase myCharacter;

    public float healthPoints;
    public float maxHealth;
    public float currentHealth;

    public float healAmount = 10f; // Quantidade de cura por segundo

    private void Start()
    {
        healthPoints = myCharacter.healthPoints;
        maxHealth = myCharacter.maxHealth;
        currentHealth = myCharacter.currentHealth;
    }

    private void Update()
    {
        // Verifique a condição para curar o jogador
        if (currentHealth <= 33)
        {
            Heal(10f);
        }
    }

    public void Heal(float amount)
    {
        // Realize a lógica de cura aqui
        myCharacter.currentHealth += healAmount * Time.deltaTime;

        // Certifique-se de que a saúde não ultrapasse o máximo
        myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);
    }
}