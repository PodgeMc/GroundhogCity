using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactRange))
            {
                NPCInteractable npc = hit.collider.GetComponent<NPCInteractable>();
                if (npc != null)
                {
                    npc.Interact();
                }
            }
        }
    }

    // Draw interaction ray in Scene View
    void OnDrawGizmos()
    {
        if (Camera.main != null)
        {
            Gizmos.color = Color.green;
            Vector3 origin = Camera.main.transform.position;
            Vector3 direction = Camera.main.transform.forward * interactRange;
            Gizmos.DrawLine(origin, origin + direction);
        }
    }
}
