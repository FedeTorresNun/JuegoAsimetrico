using FishNet.Connection;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : NetworkBehaviour
{
    [SerializeField] private List<GameObject> players = new List<GameObject>();
    [SerializeField] private GameObject canvasObj;
    [SerializeField] private GameObject characterSelectorPanel;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!base.IsOwner)
        {
            canvasObj.SetActive(false);
        }
    }

    public void SpawnPolices()
    {
        characterSelectorPanel.SetActive(true);
        Spawn(0, LocalConnection);
    }

    public void SpawnPrisoner()
    {
        characterSelectorPanel.SetActive(true);
        Spawn(1, LocalConnection);
    }

    [ServerRpc(RequireOwnership = false)]
    void Spawn(int spawnIndex, NetworkConnection conn)
    {
        GameObject player = Instantiate(players[spawnIndex], SpawnPoint.instance.transform.position, Quaternion.identity);
        Spawn(player, conn);
    }
}
