using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    [SerializeField]
    Transform UIPanel;

    public bool isCrafting;

    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
        isCrafting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject CraftingManager = GameObject.Find("Crafting Manager");
        WorkbenchCraftingManager workbenchCraftingManager = CraftingManager.GetComponent<WorkbenchCraftingManager>();
        if (Input.GetKeyDown(KeyCode.C) && !isCrafting && !workbenchCraftingManager.isWorkbenchCrafting)
            OpenCraft();
        else if (Input.GetKeyDown(KeyCode.C) && isCrafting)
            CloseCraft();
    }
    public void OpenCraft() {
        isCrafting = true;
        UIPanel.gameObject.SetActive(true);
    }
    public void CloseCraft() {
        isCrafting = false;
        UIPanel.gameObject.SetActive(false);
    }
}
