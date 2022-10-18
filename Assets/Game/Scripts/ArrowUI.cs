using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUI : MonoBehaviour
{
    [SerializeField] private GameObject finish;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(finish.transform.position.x, 0.45f, finish.transform.position.z));
    }
}
