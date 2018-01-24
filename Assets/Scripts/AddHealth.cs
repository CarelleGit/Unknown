using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealth : MonoBehaviour
{
    public Controller player;
    public int moneyNeeded;
    public Text Money;

    // Use this for initialization
    void Start()
    {
        Money.text = "Costs: " + moneyNeeded + "$";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnClick()
    {

        if (player.money >= moneyNeeded)
        {
            foreach (Controller control in player.GetComponents<Controller>())
            {
                player.health += player.totalHealth;
                player.money -= moneyNeeded;
            }
        }
    }
}
