using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject NPC;

    // Update is called once per frame
    void Start()
    {
        NPC = Resources.Load("BaseNPC") as GameObject;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Spawn NPC"))
        {
            Vector3 RangeLimit = new Vector3(Random.Range(-20, 20),
                0,
                Random.Range(-20, 20));
            Instantiate(NPC, RangeLimit, Quaternion.Euler(Vector3.forward));
        }
    }
}
