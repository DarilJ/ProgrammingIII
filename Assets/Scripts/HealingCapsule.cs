using System.Collections;
using UnityEngine;

public class HealingUnit : MonoBehaviour
{
    public CharacterBase myCharacter;

    public Transform player; // Referência ao jogador
    public Transform baseLocation; // Referência à base

    public float healAmount = 10f; // Quantidade de cura
    public float healTime = 2f; // Tempo de cura
    public float rechargeTime = 5f; // Tempo de recarga
    public float healthThreshold = 0.33f; // Limiar de saúde do jogador

    private bool isHealing = false;
    private bool isRecharging = false;

    private void Start()
    {
        StartCoroutine(HealingRoutine());
    }

    private void Update()
    {
        if (!isRecharging)
        {
            if (isHealing)
            {
                MoveTowardsPlayer();
            }
            else if (Vector3.Distance(transform.position, baseLocation.position) > 0.1f)
            {
                ReturnToBase();
            }
            else
            {
                StartCoroutine(RechargeRoutine());
            }
        }
        if (myCharacter.currentHealth <= 33)
        {
            // Cura o jogador
            myCharacter.currentHealth += healAmount;

            // Certifique-se de que a saúde não ultrapasse o máximo
            myCharacter.currentHealth = Mathf.Clamp(myCharacter.currentHealth, 0f, myCharacter.maxHealth);
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;
    }

    private void ReturnToBase()
    {
        Vector3 direction = (baseLocation.position - transform.position).normalized;
        transform.position += direction * Time.deltaTime;
    }

    private IEnumerator HealingRoutine()
    {
        while (true)
        {
            float playerHealth = player.GetComponent<CharacterBase>().currentHealth;
            if (playerHealth <= player.GetComponent<CharacterBase>().maxHealth * healthThreshold)
            {
                isHealing = true;
                yield return new WaitForSeconds(healTime);
                player.GetComponent<PlayerController>().Heal(healAmount);
                isHealing = false;
            }
            yield return null;
        }
    }

    private IEnumerator RechargeRoutine()
    {
        isRecharging = true;
        yield return new WaitForSeconds(rechargeTime);
        isRecharging = false;
    }
}