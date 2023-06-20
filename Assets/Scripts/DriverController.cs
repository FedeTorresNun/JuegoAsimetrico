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
        if (estadoActual > 100)
        {
            estadoActual = 100;
        }
        if (estadoActual < 0)
        {
            estadoActual = 0;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag);
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
