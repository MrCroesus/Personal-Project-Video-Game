using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float MaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();

        GameObject ThirstBar = GameObject.Find("ThirstBar");
        ThirstBar thirstBarScript = ThirstBar.GetComponent<ThirstBar>();

        GameObject CarryWeightBar = GameObject.Find("CarryWeightBar");
        CarryWeightBar carryWeightBarScript = CarryWeightBar.GetComponent<CarryWeightBar>();

        MaxSpeed = 0.14f * thirstBarScript.Water;
        playerScript.maxSpeed = MaxSpeed;

        if (carryWeightBarScript.Ratio >= 1)
        {
            playerScript.maxSpeed = MaxSpeed/ carryWeightBarScript.Ratio;
        }
        else if (carryWeightBarScript.Ratio < 1)
        {
            playerScript.maxSpeed = MaxSpeed;
        }

    }
}
