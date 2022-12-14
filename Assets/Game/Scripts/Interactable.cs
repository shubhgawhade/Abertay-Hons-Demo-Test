using System;
using UnityEngine;


[RequireComponent(typeof (TextReader))]
[RequireComponent(typeof (Outline))]
public class Interactable : MonoBehaviour
{
    public GameObject targetLocation;
    // public bool isinteracted;

    [SerializeField] private GameObject player;

    private Outline outline;
    private RaycastHit hit;
    
    
    
    //TEST VARIABLES
    private bool testRay;
    
    
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Physics.Raycast(player.transform.position, transform.position - player.transform.position, out hit) && hit.collider.CompareTag("Interactable"))
            {
                // testRay = true;
                print(hit.collider.name);
                // isinteracted = true;
                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.needsUpdate = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            testRay = false;
            print("EXIT");
            outline.OutlineMode = Outline.Mode.OutlineHidden;
            outline.needsUpdate = true;
        }
    }

    private void OnDrawGizmos()
    {
        // if (testRay)
        {
            Gizmos.DrawLine(player.transform.position, transform.position);
        }
    }
}
