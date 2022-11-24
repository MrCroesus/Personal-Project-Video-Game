using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image StaminaBarImage;

    public float Energy = 100;
    private float Percent;

    public void SetStamina(float stamina)
    {
        Percent = (float)stamina / 100;
        StaminaBarImage.fillAmount = Percent;
    }

    public float EnergyRate = 0.9f;
    public float RunningExhaustionRate = 0.753f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("IncreaseEnergy", 0, EnergyRate);
    }
    public void IncreaseEnergy()
    {
        Energy++;
    }
    void Update()
    {
        SetStamina(Energy);

        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (PlayableCharacter.GetComponent<Rigidbody>().velocity.magnitude > 0 && Input.GetKey(KeyCode.A))
        {
            Energy -= 2*Time.deltaTime / RunningExhaustionRate;
        }
        else if (PlayableCharacter.GetComponent<Rigidbody>().velocity.magnitude > 0 && Input.GetKey(KeyCode.D))
        {
            Energy -= 2*Time.deltaTime / RunningExhaustionRate;
        }
        else if (PlayableCharacter.GetComponent<Rigidbody>().velocity.magnitude == 0 && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            Energy += 2*Time.deltaTime / EnergyRate;
        }
        if (Energy > 100)
        {
            Energy = 100;
        }
        else if (Energy <= 0 && playerScript.maxSpeed > 2.78f)
        {
            Energy = 0;
            playerScript.maxSpeed = 2.78f;
        }
    }
}