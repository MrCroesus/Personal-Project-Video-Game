using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarryWeightBar : MonoBehaviour
{
    public Image CarryWeightBarImage;
    public Text CarryWeightText;

    public float Weight;
    public float MaxWeight;
    private float Percent;
    public float Ratio;
    private float TextPercent;

    public void SetWeight(float weight)
    {
        Percent = (float)weight / MaxWeight;
        CarryWeightBarImage.fillAmount = Percent;

        TextPercent = Mathf.Round(100*Percent);
        CarryWeightText.text = string.Format("{0} %", TextPercent);
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        Weight = (441.48f*playerScript.stone)
            +(366.52f*playerScript.soil)
            +(16.54f*playerScript.snow)
            +(1419.23f*playerScript.metal)
            +(211.89f*playerScript.wood)
            +(15*playerScript.bush)
            +(253.53f*playerScript.ice)
            +(1268.31f*playerScript.workbench)
            +(playerScript.poundsofberries)
            +(2.21f*playerScript.litersofwater)
            +(52.97f*playerScript.chair)
            +(52.97f*playerScript.table);

        GameObject HungerBar = GameObject.Find("HungerBar");
        HungerBar hungerBarScript = HungerBar.GetComponent<HungerBar>();
        MaxWeight = 123.11f * hungerBarScript.Food + 82.07f;

        SetWeight(Weight);

        Ratio = Weight / MaxWeight;

        GameObject ThirstBar = GameObject.Find("ThirstBar");
        ThirstBar thirstBarScript = ThirstBar.GetComponent<ThirstBar>();

        if (Weight <= 0)
        {
            Weight = 0;
        }
    }
}