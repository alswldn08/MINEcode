using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Betting_Main : MonoBehaviour
{
    [Header("Betting Button")]
    public Button ConfirmBet;
    public Button red;
    public Button orange;
    public Button yellow;
    public Button green;
    public Button blue;

    public InputField BettingText; //배팅 금액 입력창
    public Text NowMoneyText; //현재 남은 금액(인게임)
    public Text NowMoneyText2; //현재 남은 금액(배팅창)
    public Image BettingPG;

    public bool BettingPlayer = false;
    public string BettingWinner = "";
    public bool startBet = false;
    public bool IsStart = false;
    public float NowMoney = 1000000;
    public float BettingAmount;
    private string selectedHorse;

    void Start()
    {

        ConfirmBet.interactable = false;
        ConfirmBet.onClick.AddListener(ConfirmBtn);

        BettingPG.gameObject.SetActive(true);
        UpdateMoneyUI();

        BettingText.onValueChanged.AddListener(Betting);

        red.onClick.AddListener(redBtn);
        orange.onClick.AddListener(orangeBtn);
        yellow.onClick.AddListener(yellowBtn);
        green.onClick.AddListener(greenBtn);
        blue.onClick.AddListener(blueBtn);

        SoundManager.Instance.PlaySound(2);
    }


    private void Betting(string input)
    {
        if (float.TryParse(input, out BettingAmount))
        {
            if (BettingAmount > 0 && BettingAmount <= NowMoney)
            {
                ConfirmBet.interactable = true;
            }
            else
            {
                ConfirmBet.interactable = false;
            }
        }
        else
        {
            ConfirmBet.interactable = false;
        }
    }

    private void ConfirmBtn()
    {
        BettingPG.gameObject.SetActive(false);
        startBet = true;
        IsStart = true;

        SoundManager.Instance.PlaySound(1);
    }

    private void FixedUpdate()
    {
        if (startBet)
        {
            ProcessBet();
            startBet = false;
        }
    }

    private void ProcessBet()
    {
        if (BettingAmount > 0 && BettingAmount <= NowMoney)
        {
            NowMoney -= BettingAmount;
            UpdateMoneyUI();
        }
    }

    public void UpdateMoneyUI()
    {
        BettingPlayer = true;
        NowMoneyText.text = "현재 보유 금액: " + NowMoney;
        NowMoneyText2.text = "현재 보유 금액: " + NowMoney;
    }
    public void redBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Red";
    }
    public void orangeBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Orange";
    }
    public void yellowBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Yellow";
    }
    public void greenBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Green";
    }
    public void blueBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Blue";
    }

}
