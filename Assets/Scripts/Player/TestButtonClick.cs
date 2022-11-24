using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtonClick : MonoBehaviour
{
    public void Workbench() {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (playerScript.metal >= 7 && playerScript.wood >= 1)
        {
            playerScript.metal -= 7;
            playerScript.wood--;
            playerScript.workbench += 8;
            playerScript.SetCountText();
        }
    }
    public void PoundsOfBerries()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (playerScript.bush >= 1)
        {
            playerScript.bush--;
            playerScript.poundsofberries += 15;
            playerScript.SetCountText();
        }
    }
    public void LitersOfWater() {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (playerScript.ice >= 1)
        {
            playerScript.ice--;
            playerScript.litersofwater += 115;
            playerScript.SetCountText();
        }
    }
    public void Chair()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (playerScript.wood >= 1)
        {
            playerScript.wood--;
            playerScript.chair += 4;
            playerScript.SetCountText();
        }
    }
    public void Table() {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        if (playerScript.wood >= 1)
        {
            playerScript.wood--;
            playerScript.table += 4;
            playerScript.SetCountText();
        }
    }
}
