using UnityEngine;
using System;

public class NPC1 : MonoBehaviour
{
    [SerializeField]
    private int startingHP = 100;
    [SerializeField]
    private ParticleSystem deathParticlePrefab;
    private int currentHP;
    private float CurrentHPPct { get { return (float)currentHP/(float)startingHP; } }
    public event Action<float> OnHPPctChanged = delegate { };

    private void Start()
    {
        currentHP = startingHP;
    }

    internal void TakeDamage(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException("Invalid amount specified: " + amount);
        currentHP -= amount;
        OnHPPctChanged(currentHP);
        if (currentHP <= 0)
            Die();
    }

    private void Die()
    {
        PlayDeathParticle();
        GameObject.Destroy(this.gameObject);
    }

    private void PlayDeathParticle()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        Destroy(deathParticle, 4f);
    }
}
