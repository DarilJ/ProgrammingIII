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
        // Verifique a condi��o para curar o jogador
        if (myCharacter.currentHealth <= 33)
        {
            Heal(10f);
        }
    }

    public void Heal(float amount)
    {
        // Realize a l�gica de cura aqui
        myCharacter.currentHealth += myCharacter.heal * Time.deltaTime;

        // Certifique-se de que a sa�de n�o ultrapasse o m�ximo
        myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);
    }
}