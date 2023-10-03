using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterBase myCharacter;



    private void Start()
    {
    }

    private void Update()
    {
        // Verifique a condição para curar o jogador
        if (myCharacter.currentHealth <= 33)
        {
            Heal(10f);
        }
    }

    public void Heal(float amount)
    {
        // Realize a lógica de cura aqui
        myCharacter.currentHealth += myCharacter.heal * Time.deltaTime;

        // Certifique-se de que a saúde não ultrapasse o máximo
        myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);
    }
}