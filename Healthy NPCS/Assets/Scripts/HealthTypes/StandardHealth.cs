using System;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int startingHealth = 100;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };
    public event Action<Color> OnColorChange = delegate { };

    private StandardHealth(int healthAmount)
    {
        startingHealth = healthAmount;
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHPPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHealth -= amount;
        Debug.Log((float)currentHealth / (float)startingHealth);
        OnHPPctChanged((float)currentHealth / (float)startingHealth);

        if (CurrentHPPct <= 0)
            Die();
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
