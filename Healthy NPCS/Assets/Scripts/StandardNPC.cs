using UnityEngine;

public class StandardNPC : MonoBehaviour
{
    public NPC _NPC;
    public HPBar _HPBar;
    public NPCParticles _NPCParticles;
    public StandardHealth _StandardHealth;

    private void Awake()
    {
        _NPC = gameObject.AddComponent<NPC>();
        _HPBar = gameObject.AddComponent<HPBar>();
        _NPCParticles = gameObject.AddComponent<NPCParticles>();
        _StandardHealth = gameObject.AddComponent<StandardHealth>();
    }
}
