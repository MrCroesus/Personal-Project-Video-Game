using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Image HungerBarImage;
    public Text HungerText;

    public int Food = 100;
    private float Percent;

    public void SetHunger(int hunger)
    {
        Percent = (float)Food / 100;
        HungerText.text = string.Format("{0} %",Food);

        HungerBarImage.fillAmount = Percent;
    }

    public float HungerRate = 7.2f;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("IncreaseHunger", 0, HungerRate);
    }

    public void IncreaseHunger()
    {
        Food--;
        if (Food < 0)
            Food = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        SetHunger(Food);
        if (Input.GetKeyDown(KeyCode.R) == true && playerScript.poundsofberries > 0 && Food < 100)
        {
            playerScript.poundsofberries--;
            playerScript.SetCountText();
            Food += 44;
        }
        else if (Food > 100)
        {
            Food = 100;
        }
    }
}