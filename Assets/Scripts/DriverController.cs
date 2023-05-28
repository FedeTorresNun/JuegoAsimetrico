using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriverController : MonoBehaviour
{
    public Image barra;

    public float estadoActual = 0;
    public float estadoFinal = 100;

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = estadoActual/estadoFinal;
    }

    //
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Police"))
        {
            estadoActual++;
        }
        else
        {
            estadoActual--;
        }
    }
}
