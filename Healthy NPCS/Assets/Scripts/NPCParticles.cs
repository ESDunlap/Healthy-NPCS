using UnityEngine;

public class NPCParticles : MonoBehaviour
{
    private GameObject deathParticlePrefab;

    private void Start()
    {
        deathParticlePrefab = Resources.Load("DeathExplosion") as GameObject;
        GetComponent<IHealth>().OnDied += HandleNPCDied;
    }

    private void HandleNPCDied()
    {
        var deathparticle = Instantiate(deathParticlePrefab, transform.position, transform.rotation);
        Destroy(deathparticle, 3f);
    }
}
