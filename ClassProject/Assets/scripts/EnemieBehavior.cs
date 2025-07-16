using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class EnemieBehavior : MonoBehaviour
{
    public Transform player;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("sir capsulote").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
    void IntializePatrolRoute()
    {
        foreach(Transform child in locations) 
        {
            locations.Add(child);
        }
    }
void MoveToNextPatrolLocation()
    {
        if(locations.Count == 0)
        {
            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.name == "sir capsulote")
        {
            agent.destination = player.position;
            Debug.Log("ATTACK!!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "sir capsulote")
        {
            Debug.Log("Resume Patrol");
        }
    }
}
