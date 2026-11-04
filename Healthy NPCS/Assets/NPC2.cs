using System;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    [SerializeField] private int startingHp = 100;
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private int currentHp;

    private float CurrentHpPct
    {
        get { return (float)currentHp / (float)startingHp; }
    }


    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnNPCDied = delegate { };

    private void Start()
    {
        currentHp = startingHp;
    }

    internal void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHp -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (currentHp <= 0)
            Die();
    }

    private void Die()
    {
        OnNPCDied();
        GameObject.Destroy(this.gameObject);
    }
}