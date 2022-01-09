using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    AudioSource zombieDie;
    bool isDead = false;
    public bool IsDead() {  return isDead;  }
   // AudioManager audioManager;

    private void Start()
    {
        zombieDie = GetComponent<AudioSource>();
        //audioManager = FindObjectOfType<AudioManager>();
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        zombieDie.Play();
        //audioManager.Play(ZombieDie);
        GetComponent<Animator>().SetTrigger("die");
    }
}
