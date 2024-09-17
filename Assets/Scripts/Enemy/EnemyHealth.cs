using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth =3f;
    Animator animator;

    private float currentHealth;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 1)
        {
            animator.SetTrigger("Dead");
            Invoke("Die", 2f); 
        }else if (currentHealth > 1) 
        {
            animator.SetTrigger("Hit");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
