using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public Betting_Main Betting;

    public Button Dice;
    public Button UnknownPotion;

    public static float OnDice = 2f;
    private bool diceCheck = false;
    private bool potionCheck = false;
    void Start()
    {
        Betting = GetComponent<Betting_Main>();
        Dice.onClick.AddListener(DiceBtn);
        UnknownPotion.onClick.AddListener(UnknownPotionBtn);
        UnknownPotion.interactable = false;
        Dice.interactable = false;
        Betting.BettingPlayer = false;
    }

    void Update()
    {
        if (Betting.BettingPlayer == true)
        {
            UnknownPotion.interactable = true;
            Dice.interactable = true;
        }
        else
        {
            UnknownPotion.interactable = false;
            Dice.interactable = false;
        }
        if (diceCheck == true)
        {
            Dice.interactable = false;
        }
        if (potionCheck == true)
        {
            UnknownPotion.interactable = false;
        }
    }


    public void DiceBtn()
    {
        if (Betting.NowMoney >= 100000f)
        {
            diceCheck = true;
            Betting.NowMoney -= 100000f;
            Betting.UpdateMoneyUI();
        }
    }

    public void UnknownPotionBtn()
    {
        if (Betting.NowMoney >= 1f)
        {
            potionCheck = true;
            Betting.NowMoney -= 1f;
            Betting.UpdateMoneyUI();
        }
    }



}

