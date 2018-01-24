using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDamage : MonoBehaviour
{
    public PlayerLevel player;
    public GameObject weapon;
    public GameObject weapon2;
    public int lvNeeded;
    public Text addDamage;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        addDamage.text = "LV Needed: " + lvNeeded;

    }
    public void OnClick()
    {

        if (player.level >= lvNeeded)
        {
            weapon2.GetComponent<Weapon>().damage += 10;
            weapon.GetComponent<Weapon>().damage += 10;
        }

        if (player.level >= lvNeeded)
        {
            lvNeeded = player.level + 2;
        }
        addDamage.text = "LV Needed: " + lvNeeded;
    }
}
