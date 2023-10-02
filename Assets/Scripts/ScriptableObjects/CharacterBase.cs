using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "characterAttributes", menuName = "Character")]

public class CharacterBase : ScriptableObject
{
    public float healthPoints;
    public float speed;
    public Slider healthBar;
    public float maxHealth;
    public float currentHealth = 100f;
}
