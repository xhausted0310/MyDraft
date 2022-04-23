using System;
using System.Collections;
using UnityEngine;
using Pathfinding;



   public class Enemy : MonoBehaviour
   {
        [SerializeField] private Animator _animator;
        [SerializeField] AnimatedCharacterSelection _animatedCharacterSelection;

        public int maxHealth = 100;
        public int currentHealth;
        public AIPath aiPath;
        

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            if (aiPath.desiredVelocity.x >= 0.01f)
            {
                _animator.SetFloat("Speed", aiPath.desiredVelocity.x * aiPath.desiredVelocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }else if (aiPath.desiredVelocity.x <= -0.01f)
            {
                _animator.SetFloat("Speed", aiPath.desiredVelocity.x * aiPath.desiredVelocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            //else if(aiPath.desiredVelocity.x == 0 && aiPath.desiredVelocity.y == 0)
            //{
            //    _animator.SetFloat("Speed", 0);
            //}
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            //play hurt animation
            _animator.SetTrigger("Hurt");

            if (currentHealth <= 0)
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
