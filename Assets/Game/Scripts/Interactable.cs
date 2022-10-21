using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.needsUpdate = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.OutlineMode = Outline.Mode.OutlineHidden;
            outline.needsUpdate = true;
        }
    }
}
