using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NettCodeTest : MonoBehaviour
{
    public NetworkManager netManager;

    private void Start()
    {
        if (!netManager)
            netManager = GetComponent<NetworkManager>();
    }

    public void StartHost()
    {
        netManager.StartHost();
    }

    public void StartClient()
    {
        netManager.StartClient();
    }
}