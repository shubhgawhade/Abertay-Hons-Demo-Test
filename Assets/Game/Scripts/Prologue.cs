using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
