using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int intWaypointIndex= 0 ;
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[intWaypointIndex].position;
    }

  
    void Update()
    {
        if(intWaypointIndex<waypoints.Count)
        {
            Vector3 targetPosition = waypoints[intWaypointIndex].position;
            float fltDelta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, fltDelta);
            if(transform.position == targetPosition)
            {
                intWaypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
