using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 400f;
    [SerializeField] float healin = 4f;
    [SerializeField] float healinTime = 2f;
    [SerializeField] TextMeshProUGUI lifeText;

    WaitForSeconds regenTick = new WaitForSeconds(1f);
    Coroutine regen;
    float currentHealth;
    public HealtBar healtBar;


  
    private void Start()
    {
        healtBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
            lifeText.text = ((currentHealth / maxHealth) * 100).ToString() + "%";
            healtBar.SetHealth(currentHealth);
            if (regen != null) 
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            lifeText.text = 0 + "%";
            healtBar.SetHealth(0);
            GetComponent<DeathHandler>().HandleDeath();
        }

    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(healinTime);
        while (currentHealth < maxHealth)
        {
            currentHealth += healin;
            lifeText.text = ((currentHealth / maxHealth) * 100).ToString() + "%";
            healtBar.SetHealth(currentHealth);
            yield return regenTick;
        }
        regen = null;
    }
}
