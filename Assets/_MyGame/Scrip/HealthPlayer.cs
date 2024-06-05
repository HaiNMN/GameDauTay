using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    public HealthBar healthBar;

    public UnityEvent onDeath;

    
    private void OnEnable() // khi gọi inDeath thì nó sẽ gọi những cái gì có trong OnEnable
    {
        onDeath.AddListener(Death);
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onDeath.Invoke();
            _AudioManager.Instance.PlaySoundEffectMusic(_AudioManager.Instance.Dead);
        }

        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        Destroy(gameObject);
        GameManager.instance.EnemySkillPlayer();
    }
}
