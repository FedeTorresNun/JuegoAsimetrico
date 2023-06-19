using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class PoliceDestination : NetworkBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public NetworkObject myself;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!IsOwner) return;

        UpdateServerRPC();

        //// Choose the next destination point when the agent gets
        //// close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
        //{
        //    GotoNextPoint();
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //    {
        //        agent.destination = hit.point;
        //    }
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    agent.ResetPath();
        //}
    }

    [ServerRpc]
    public void UpdateServerRPC()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
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
