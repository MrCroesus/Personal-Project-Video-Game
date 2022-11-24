using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkbenchCraftingManager : MonoBehaviour
{
    [SerializeField]
    Transform UIPanel;

    public bool isWorkbenchCrafting;

    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
        isWorkbenchCrafting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayableCharacter = GameObject.Find("PlayableCharacter");
        PlayerControllerScript playerScript = PlayableCharacter.GetComponent<PlayerControllerScript>();
        GameObject CraftingManager = GameObject.Find("Crafting Manager");
        CraftingManager craftingManager = CraftingManager.GetComponent<CraftingManager>();
        if (((playerScript.tScript.blocks[Mathf.RoundToInt(PlayableCharacter.transform.position.x - 0.5f), Mathf.RoundToInt(PlayableCharacter.transform.position.y + 1.5f)] == 8) || (playerScript.tScript.blocks[Mathf.RoundToInt(PlayableCharacter.transform.position.x + 0.5f), Mathf.RoundToInt(PlayableCharacter.transform.position.y + 0.5f)] == 8) || (playerScript.tScript.blocks[Mathf.RoundToInt(PlayableCharacter.transform.position.x - 1.5f), Mathf.RoundToInt(PlayableCharacter.transform.position.y + 0.5f)] == 8) || (playerScript.tScript.blocks[Mathf.RoundToInt(PlayableCharacter.transform.position.x - 0.5f), Mathf.RoundToInt(PlayableCharacter.transform.position.y - 0.5f)] == 8)) && Input.GetKeyDown(KeyCode.E) == true && !isWorkbenchCrafting && !craftingManager.isCrafting)
        {
            OpenWorkbenchCraft();
        }
        else if (Input.GetKeyDown(KeyCode.E) == true && isWorkbenchCrafting)
        {
            CloseWorkbenchCraft();
        }
    }
    public void OpenWorkbenchCraft() {
        isWorkbenchCrafting = true;
        UIPanel.gameObject.SetActive(true);
    }
    public void CloseWorkbenchCraft() {
        isWorkbenchCrafting = false;
        UIPanel.gameObject.SetActive(false);
    }
}
