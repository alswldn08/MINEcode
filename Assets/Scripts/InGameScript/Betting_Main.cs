using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Betting_Main : MonoBehaviour
{
    [Header("버튼")]
    public Button ConfirmBet;
    public Button red;
    public Button orange;
    public Button yellow;
    public Button green;
    public Button blue;

    public InputField BettingText; //배팅값 입력창
    public Text NowMoneyText; //배팅창에서 텍스트 출력
    public Text NowMoneyText2; //인게임에서 텍스트 출력
    public Image BettingPG;

    public bool BettingPlayer = false;
    public string BettingWinner = "";
    public bool startBet = false; //배팅 시작
    public bool IsStart = false; //경마 시작
    public float NowMoney = 1000000; //현재 잔액
    public float BettingAmount; //배팅한 금액
    private string selectedHorse;

    void Start()
    {

        ConfirmBet.interactable = false;
        ConfirmBet.onClick.AddListener(ConfirmBtn);

        BettingPG.gameObject.SetActive(true);
        UpdateMoneyUI();

        BettingText.onValueChanged.AddListener(Betting);

        //버튼
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
        else
        {
            Debug.Log("배팅 금액이 유효하지 않습니다.");
        }
    }

    public void UpdateMoneyUI()
    {
        BettingPlayer = true;
        NowMoneyText.text = "남은 잔액: " + NowMoney;
        NowMoneyText2.text = "남은 잔액: " + NowMoney;
    }
    public void redBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Red";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void orangeBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Orange";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void yellowBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Yellow";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void greenBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Green";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }
    public void blueBtn()
    {
        BettingPlayer = true;
        BettingWinner = "Blue";
        Debug.Log("오브젝트이름: " + BettingWinner);
    }

}
