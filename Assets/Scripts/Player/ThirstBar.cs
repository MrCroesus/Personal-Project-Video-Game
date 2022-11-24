using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirstBar : MonoBehaviour
{
    public Image ThirstBarImage;
    public Text ThirstText;

    public int Water = 100;
    private float Percent;

    public void SetThirst(int thirst)
    {
        Percent = (float)thirst / 100;
        ThirstText.text = string.Format("{0} %", Water);

        ThirstBarImage.fillAmount = Percent;
    }

    public float ThirstRate = 57.6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseThirst", 0, ThirstRate);
    }
    public void IncreaseThirst()
    {
        Water--;
        if (Water < 0)
            Water = 0;
    }
    void Update()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        SetThirst(Water);
        if(Input.GetKeyDown(KeyCode.F) == true && playerScript.litersofwater > 0 && Water < 100)
        {
            playerScript.litersofwater--;
            playerScript.SetCountText();
            Water += 25;
        }
        else if (Water > 100)
        {
            Water = 100;
        }
    }
}