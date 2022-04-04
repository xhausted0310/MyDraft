using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public int maxHealth = 100;
    public int currentHealth;



    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation
        _animator.SetTrigger("Hurt");

        if(currentHealth<=0)
        {
            StartCoroutine(SelfDestruct());
            Die();
        }
    }

    private void Die()
    {
        //play die animation
        _animator.SetBool("isDead", true);

        //disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
