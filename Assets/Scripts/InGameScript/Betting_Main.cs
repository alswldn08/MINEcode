using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Betting_Main : MonoBehaviour
{
    [Header("��ư")]
    public Button ConfirmBet;

    
    public static GameObject[] player;

    public InputField BettingText; //���ð� �Է�â
    public Text NowMoneyText; //����â���� �ؽ�Ʈ ���
    public Text NowMoneyText2; //�ΰ��ӿ��� �ؽ�Ʈ ���
    public Image BettingPG;

    public float NowMoney = 1000000; //���� �ܾ�
    public float BettingAmount; //������ �ݾ�

    private bool startBet = false; //���� ����
    public static bool IsStart; //�渶 ����

    private Player Player; //����
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

        //��ư
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
                Debug.Log("�ܾ��� �����ϰų� ��ȿ���� ���� �ݾ��Դϴ�.");
                ConfirmBet.interactable = false;
            }
        }
        else
        {
            ConfirmBet.interactable = false;
            Debug.Log("���ڸ� �Է����ּ���.");
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
            Debug.Log($"���� ����! ���� �ܾ�: {NowMoney}");
        }
        else
        {
            Debug.Log("���� �ݾ��� ��ȿ���� �ʽ��ϴ�.");
        }
    }

    private void UpdateMoneyUI()
    {
        NowMoneyText.text = "���� �ܾ�: " + NowMoney;
        NowMoneyText2.text = "���� �ܾ�: " + NowMoney;
    }
    public void redBtn()
    {
        BettingWinner = "Red";
        Debug.Log("������Ʈ�̸�: " + BettingWinner);
    }
    public void orangeBtn()
    {
        BettingWinner = "Orange";
        Debug.Log("������Ʈ�̸�: " + BettingWinner);
    }
    public void yellowBtn()
    {
        BettingWinner = "Yellow";
        Debug.Log("������Ʈ�̸�: " + BettingWinner);
    }
    public void greenBtn()
    {
        BettingWinner = "Green";
        Debug.Log("������Ʈ�̸�: " + BettingWinner);
    }
    public void blueBtn()
    {
        BettingWinner = "Blue";
        Debug.Log("������Ʈ�̸�: " + BettingWinner);
    }

}
