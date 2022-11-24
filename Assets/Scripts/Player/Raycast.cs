using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject terrain;
    private PolygonGenerator tScript;
    private LayerMask layerMask = (1 << 0);
    // Start is called before the first frame update
    private void Start()
    {
        tScript = terrain.GetComponent("PolygonGenerator") as PolygonGenerator;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
        }
    }
}