using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public float maxSpeed = 10.82f;
    bool facingRight = true;

    Animator anim;

    public float jumpForce = 700f;

    public LayerMask groundLayers;

    public SphereCollider col;

    public GameObject terrain;
    public PolygonGenerator tScript;
    private LayerMask layerMask = (1 << 0);

    private byte materialType = 1;

    public int stone;
    public int soil;
    public int snow;
    public int metal;
    public int wood;
    public int bush;
    public int ice;
    public int workbench;
    public int poundsofberries;
    public int litersofwater;
    public int chair;
    public int table;

    public Text stoneText;
    public Text soilText;
    public Text snowText;
    public Text metalText;
    public Text woodText;
    public Text bushText;
    public Text iceText;
    public Text workbenchText;
    public Text poundsofberriesText;
    public Text litersofwaterText;
    public Text chairText;
    public Text tableText;

    // Start is called before the first frame update
    void Start()
    {
        stone = 0;
        soil = 0;
        snow = 0;
        metal = 0;
        wood = 0;
        bush = 0;
        ice = 0;
        workbench = 0;
        poundsofberries = 0;
        litersofwater = 0;
        chair = 0;
        table = 0;

        anim = GetComponent<Animator>();
        col = GetComponent<SphereCollider>();
        tScript = terrain.GetComponent("PolygonGenerator") as PolygonGenerator;

        SetCountText();
    }

    public void SetCountText()
    {
        stoneText.text = "Stone: " + stone.ToString();
        soilText.text = "Soil: " + soil.ToString();
        snowText.text = "Snow: " + snow.ToString();
        metalText.text = "Metal: " + metal.ToString();
        woodText.text = "Wood: " + wood.ToString();
        bushText.text = "Bush: " + bush.ToString();
        iceText.text = "Ice: " + ice.ToString();
        workbenchText.text = "Workbench: " + workbench.ToString();
        poundsofberriesText.text = "Pounds of Berries: " + poundsofberries.ToString();
        litersofwaterText.text = "Liters of Water: " + litersofwater.ToString();
        chairText.text = "Chairs: " + chair.ToString();
        tableText.text = "Tables: " + table.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody>().velocity.y);

        GameObject StaminaBar = GameObject.Find("StaminaBar");
        StaminaBar staminaBarScript = StaminaBar.GetComponent<StaminaBar>();

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Update() {
        GameObject StaminaBar = GameObject.Find("StaminaBar");
        StaminaBar staminaBarScript = StaminaBar.GetComponent<StaminaBar>();

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && staminaBarScript.Energy > 0)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            staminaBarScript.Energy -= 0.87f;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            materialType = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            materialType = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3) == true)
            materialType = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4) == true)
            materialType = 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5) == true)
            materialType = 5;
        else if (Input.GetKeyDown(KeyCode.Alpha6) == true)
            materialType = 6;
        else if (Input.GetKeyDown(KeyCode.Alpha7) == true)
            materialType = 7;
        else if (Input.GetKeyDown(KeyCode.Alpha8) == true)
            materialType = 8;
        else if (Input.GetKeyDown(KeyCode.Alpha9) == true)
            materialType = 9;
        else if (Input.GetKeyDown(KeyCode.Alpha0) == true)
            materialType = 10;

        //top break blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 1 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            stone++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 2 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            soil++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 3 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            snow++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 4 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            metal++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 5 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            wood++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 6 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            bush++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 7 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            ice++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 8 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            workbench++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 9 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            chair++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 10 && Input.GetKeyDown(KeyCode.O) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 0;
            tScript.update = true;
            table++;
            SetCountText();
        }
        //top place blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 1 && stone > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 1;
            tScript.update = true;
            stone--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 2 && soil > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 2;
            tScript.update = true;
            soil--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 3 && snow > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 3;
            tScript.update = true;
            snow--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 4 && metal > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 4;
            tScript.update = true;
            metal--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 5 && wood > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 5;
            tScript.update = true;
            wood--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 6 && bush > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 6;
            tScript.update = true;
            bush--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 7 && ice > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 7;
            tScript.update = true;
            ice--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 8 && workbench > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 8;
            tScript.update = true;
            workbench--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 9 && chair > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 9;
            tScript.update = true;
            chair--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] == 0 && Input.GetKeyDown(KeyCode.Y) == true && materialType == 10 && table > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y + 1.5f)] = 10;
            tScript.update = true;
            table--;
            SetCountText();
        }
        //right break blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 1 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            stone++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 2 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            soil++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 3 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            snow++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 4 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            metal++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 5 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            wood++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 6 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            bush++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 7 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            ice++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 8 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            workbench++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 9 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            chair++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 10 && Input.GetKeyDown(KeyCode.Semicolon) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            table++;
            SetCountText();
        }
        //right place blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 1 && stone > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 1;
            tScript.update = true;
            stone--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 2 && soil > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 2;
            tScript.update = true;
            soil--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 3 && snow > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 3;
            tScript.update = true;
            snow--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 4 && metal > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 4;
            tScript.update = true;
            metal--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 5 && wood > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 5;
            tScript.update = true;
            wood--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 6 && bush > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 6;
            tScript.update = true;
            bush--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 7 && ice > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 7;
            tScript.update = true;
            ice--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 8 && workbench > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 8;
            tScript.update = true;
            workbench--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 9 && chair > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 9;
            tScript.update = true;
            chair--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.J) == true && materialType == 10 && table > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x + 0.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 10;
            tScript.update = true;
            table--;
            SetCountText();
        }
        //left break blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 1 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            stone++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 2 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            soil++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 3 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            snow++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 4 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            metal++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 5 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            wood++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 6 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            bush++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 7 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            ice++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 8 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            workbench++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 9 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            chair++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 10 && Input.GetKeyDown(KeyCode.K) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 0;
            tScript.update = true;
            table++;
            SetCountText();
        }
        //left place blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 1 && stone > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 1;
            tScript.update = true;
            stone--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 2 && soil > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 2;
            tScript.update = true;
            soil--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 3 && snow > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 3;
            tScript.update = true;
            snow--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 4 && metal > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 4;
            tScript.update = true;
            metal--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 5 && wood > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 5;
            tScript.update = true;
            wood--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 6 && bush > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 6;
            tScript.update = true;
            bush--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 7 && ice > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 7;
            tScript.update = true;
            ice--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 8 && workbench > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 8;
            tScript.update = true;
            workbench--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 9 && chair > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 9;
            tScript.update = true;
            chair--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] == 0 && Input.GetKeyDown(KeyCode.G) == true && materialType == 10 && table > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 1.5f), Mathf.RoundToInt(transform.position.y + 0.5f)] = 10;
            tScript.update = true;
            table--;
            SetCountText();
        }
        //bottom place blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 1 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            stone++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 2 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            soil++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 3 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            snow++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 4 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            metal++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 5 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            wood++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 6 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            bush++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 7 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            ice++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 8 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            workbench++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 9 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            chair++;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 10 && Input.GetKeyDown(KeyCode.L) == true)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 0;
            tScript.update = true;
            table++;
            SetCountText();
        }
        //bottom break blocks
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 1 && stone > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 1;
            tScript.update = true;
            stone--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 2 && soil > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 2;
            tScript.update = true;
            soil--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 3 && snow > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 3;
            tScript.update = true;
            snow--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 4 && metal > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 4;
            tScript.update = true;
            metal--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 5 && wood > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 5;
            tScript.update = true;
            wood--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 6 && bush > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 6;
            tScript.update = true;
            bush--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 7 && ice > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 7;
            tScript.update = true;
            ice--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 8 && workbench > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 8;
            tScript.update = true;
            workbench--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 9 && chair > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 9;
            tScript.update = true;
            chair--;
            SetCountText();
        }
        else if (tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] == 0 && Input.GetKeyDown(KeyCode.H) == true && materialType == 10 && table > 0)
        {
            tScript.blocks[Mathf.RoundToInt(transform.position.x - 0.5f), Mathf.RoundToInt(transform.position.y - 0.5f)] = 10;
            tScript.update = true;
            table--;
            SetCountText();
        }
    }

    private bool IsGrounded ()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
