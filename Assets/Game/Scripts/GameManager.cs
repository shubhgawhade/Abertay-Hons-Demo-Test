using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Slider sens;
    [SerializeField] private TextMeshProUGUI sensitivity;
    
    public static float MouseSensitivity = 50;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        sens.value = MouseSensitivity;
    }

    public void SensUpdate()
    {
        sensitivity.text = sens.value.ToString();
        MouseSensitivity = sens.value;
    }
}
