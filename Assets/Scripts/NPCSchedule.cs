using UnityEngine;
using UnityEngine.AI;

public class NPCSchedule : MonoBehaviour
{
    public Transform[] waypoints;
    public float[] scheduleTimes; // Time (in game minutes) to go to each waypoint

    private NavMeshAgent agent;
    private int currentTarget = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found on " + gameObject.name);
        }

        // Initial debug check
        if (waypoints.Length != scheduleTimes.Length)
        {
            Debug.LogError("Waypoints and scheduleTimes must be the same length!");
        }
    }

    void Update()
    {
        if (DayManager.Instance == null || agent == null) return;

        float time = DayManager.Instance.GetCurrentTime();

        if (currentTarget < scheduleTimes.Length && time >= scheduleTimes[currentTarget])
        {
            if (waypoints[currentTarget] != null)
            {
                agent.SetDestination(waypoints[currentTarget].position);
            }

            currentTarget++;
        }

        // Smooth face movement direction
        if (agent.velocity.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }


    public void ResetSchedule()
    {
        currentTarget = 0;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (waypoints != null)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                if (waypoints[i] != null)
                {
                    Gizmos.DrawSphere(waypoints[i].position, 0.2f);
                    Gizmos.DrawLine(transform.position, waypoints[i].position);

#if UNITY_EDITOR
                UnityEditor.Handles.Label(waypoints[i].position + Vector3.up * 0.5f, "Waypoint " + i);
#endif
                }
            }
        }
    }

}
