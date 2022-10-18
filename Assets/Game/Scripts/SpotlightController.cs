using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class SpotlightController : MonoBehaviour
{
    [SerializeField] Slider torchBatteryUI;
    [SerializeField] private Image sliderColour;

    public bool isOn;
    public bool cooldown;

    private Light spotlight;
    public float battery;
    public float dischargeRate;
    public float rechargeRate;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
        isOn = spotlight.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !cooldown)
        {
            ToggleSpotlight();
        }

        BatteryDischarge();
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        cooldown = false;
    }

    private void BatteryDischarge()
    {
        if (isOn)
        {
            if (battery - dischargeRate >= 0)
            {
                battery -= dischargeRate;
            }
            else
            {
                battery = 0;
                cooldown = true;
                StartCoroutine(Wait(1.5f));
                ToggleSpotlight();
            }
        }
        else if (!cooldown)
        {
            if (battery + rechargeRate <= 100)
            {
                battery += rechargeRate;
            }
            else
            {
                battery = 100;
            }
        }

        torchBatteryUI.value = battery;
        sliderColour.color = Color.Lerp(Color.red, Color.yellow, battery / 100);
    }

    private void ToggleSpotlight()
    {
        isOn = !isOn;
        spotlight.enabled = isOn;
    }
}
