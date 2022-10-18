using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    private int health = 5;


    public void SubtractHealth()
    {
        if (health > 1)
        {
            health--;
            healthText.text = health.ToString();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
