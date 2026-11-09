using System;
using System.Collections;
using UnityEngine;

public class DrainingHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private float healthRemaining;

    public event Action<float> OnHPPctChanged = delegate (float f) { };
    public event Action OnDied = delegate { };
    public event Action<Color> OnColorChange = delegate { };

    public float CurrentHpPct
    {
        get { return healthRemaining / (float)startingHealth; }
    }

    private void Start()
    {
        healthRemaining = startingHealth;
    }

    private void Update()
    {
        if (healthRemaining < 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(LeakHealth(amount));
    }

    private IEnumerator LeakHealth(int amount)
    {
        float totalDamageTaken = 0;
        float damagePerCheck = 0.3f;
        while (totalDamageTaken <= amount)
        {
            yield return new WaitForSeconds(0.1f);
            totalDamageTaken += 0.3f;
            if (totalDamageTaken > amount)
            {
                damagePerCheck = totalDamageTaken - amount;
            }
            healthRemaining -= damagePerCheck;
            OnHPPctChanged(CurrentHpPct);
        }
    }
    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
