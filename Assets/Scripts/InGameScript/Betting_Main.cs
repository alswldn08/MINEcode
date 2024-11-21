using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Betting_Main : MonoBehaviour
{
    [Header("버튼")]
    public Button ConfirmBet;

    
    public static GameObject[] player;

    public InputField BettingText; //배팅값 입력창
    public Text NowMoneyText; //배팅창에서 텍스트 출력
    public Text NowMoneyText2; //인게임에서 텍스트 출력
    public Image BettingPG;

    public float NowMoney = 1000000; //현재 잔액
    public float BettingAmount; //배팅한 금액

    private bool startBet = false; //배팅 시작
    public static bool IsStart; //경마 시작

    private Player Player; //참조
    private string selectedHorse;

    public Button red;
    public Button orange;
    public Button yellow;
    public Button green;
    public Button blue;

    public string BettingWinner = "";
    void Start()
    {
        ConfirmBet.interactable = false;
        ConfirmBet.onClick.AddListener(ConfirmBtn);

        BettingPG.gameObject.SetActive(true);
        UpdateMoneyUI();

        BettingText.onValueChanged.AddListener(ValidateBettingAmount);

        //버튼
        red.onClick.AddListener(redBtn);
        orange.onClick.AddListener(orangeBtn);
        yellow.onClick.AddListener(yellowBtn);
        green.onClick.AddListener(greenBtn);
        blue.onClick.AddListener(blueBtn);

    }

    private void ValidateBettingAmount(string input)
    {
        if (float.TryParse(input, out BettingAmount))
        {
            if (BettingAmount > 0 && BettingAmount <= NowMoney)
            {
                ConfirmBet.interactable = true;
            }
            else
            {
                Debug.Log("잔액이 부족하거나 유효하지 않은 금액입니다.");
                ConfirmBet.interactable = false;
            }
        }
        else
        {
            ConfirmBet.interactable = false;
            Debug.Log("숫자를 입력해주세요.");
        }
    }

    private void ConfirmBtn()
    {
        BettingPG.gameObject.SetActive(false);
        startBet = true;
        IsStart = true;
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
            Debug.Log($"배팅 성공! 남은 잔액: {NowMoney}");
        }
        else
        {
            Debug.Log("배팅 금액이 유효하지 않습니다.");
        }
    }

    private void UpdateMoneyUI()
    {
        NowMoneyText.text = "남은 잔액: " + NowMoney;
        NowMoneyText2.text = "남은 잔액: " + NowMoney;
    }
    public void redBtn()
    {
        BettingWinner = "Red";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void orangeBtn()
    {
        BettingWinner = "Orange";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void yellowBtn()
    {
        BettingWinner = "Yellow";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void greenBtn()
    {
        BettingWinner = "Green";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void blueBtn()
    {
        BettingWinner = "Blue";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }

}
