using UnityEngine;

public enum NPCTypes
{
    Base,
    NumberHits,
    Draining
}

public class Spawner : MonoBehaviour
{
    private GameObject NPC;
    private NPCTypes currentType = NPCTypes.Base;

    void Start()
    {
        NPC = Resources.Load("BaseNPC") as GameObject;
    }

    void ChangeLoading()
    {
        if (currentType == NPCTypes.Draining)
        {
            currentType = NPCTypes.Base;
        }
        else
        {
            currentType++;
        }
        ChangeSpawning();
    }

    void ChangeSpawning()
    {
        if (currentType == NPCTypes.Base)
        {
            NPC = Resources.Load("BaseNPC") as GameObject;
        }
        else if (currentType == NPCTypes.NumberHits)
        {
            NPC = Resources.Load("NumHitsNPC") as GameObject;
        }
        else if (currentType == NPCTypes.Draining)
        {
            NPC = Resources.Load("DrainingNPC") as GameObject;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Spawn NPC"))
        {
            Vector3 RangeLimit = new Vector3(Random.Range(-20, 20),
                0,
                Random.Range(-20, 20));
            Instantiate(NPC, RangeLimit, Quaternion.Euler(Vector3.forward));
        }
        if (GUI.Button(new Rect(10, 50, 100, 30), "Change Type"))
        {
            ChangeLoading();
        }
        GUI.Label(new Rect(10, 90, 100, 40), "Current Type: " + currentType);
    }
}
