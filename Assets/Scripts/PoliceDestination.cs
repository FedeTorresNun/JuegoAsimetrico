using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceDestination : PlayerBASE
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void GotoNextPoint()
    {
        base.GotoNextPoint();
    }


    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.destination = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            agent.ResetPath();
        }
    }
}
