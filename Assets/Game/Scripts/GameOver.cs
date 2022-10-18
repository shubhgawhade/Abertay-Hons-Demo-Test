using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject ai;
    
    [SerializeField] private Animator a;
    
    [SerializeField] private GameObject middle;
    [SerializeField] private GameObject lights;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            transform.position = middle.transform.position;
            ai.SetActive(true);
            a.SetBool("Fade", true);
            StartCoroutine(A(0));
        }
        else if (other.CompareTag("Lights"))
        {
            StartCoroutine(A(1));
        }
    }

    IEnumerator A(int type)
    {
        switch (type)
        {
            case 0:
                
                yield return new WaitForSeconds(0.5f);
                a.SetBool("Fade", false);
                break;
            
            
            case 1:
                
                yield return new WaitForSeconds(5f);
                lights.SetActive(true);
                yield return new WaitForSeconds(5f);
                SceneManager.LoadScene(0);
                break;
        }
        
    }
}