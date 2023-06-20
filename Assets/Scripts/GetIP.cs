using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine.UI;
using System.Linq;
using FishNet.Transporting.Tugboat;

public class GetIP : MonoBehaviour
{
    public Text ip;
    public Tugboat tb;
    //Start is called before the first frame update
    void Start()
    {
        ip.text = GetLocalIPv4();
        tb._clientAddress = GetLocalIPv4();
    }

    public string GetLocalIPv4()
    {
        return Dns.GetHostEntry(Dns.GetHostName())
        .AddressList.First(
        f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        .ToString();
    }
}
