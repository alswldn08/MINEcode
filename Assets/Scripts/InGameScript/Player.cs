using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("����")]
    private Rigidbody2D rigid;
    private Betting_Main Betting_Main;
    private UIManager uiManager;

    public static GameObject[] player;

    public float speed = 10f;

    public static bool Win = false; //��¼� ����� �ð� ���ο�
    public static bool First = false; //����� 1�� �ޱ�
    public static bool timeStopInvoked = false;

    public Text text;

    public string colorName; //����ڿ� ���� �ؽ�Ʈ �� ��ȯ(���׷� �۵� �ȵ�)

    public static string WinnerName; //����� �̸�


    void Start()
    {
        Time.timeScale = 1f;
        if (text == null)
        {
            text = GameObject.Find("Text").GetComponent<Text>();
        }
        player = GameObject.FindGameObjectsWithTag("Player");
        Betting_Main = FindObjectOfType<Betting_Main>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveUp());
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float move = 0f;

        if (Betting_Main.IsStart == true)
        {
            move = 1f;
        }
        rigid.velocity = new Vector2(speed * move, 0f);

        if(Win && !timeStopInvoked)
        {
            Debug.Log("����");
        }
    }

    private void Update()
    {
        if (Win && !timeStopInvoked)
        {
            Time.timeScale = 0.4f;
            
            Invoke("TimeStop", 4);
            timeStopInvoked = true;
        }

        if (Betting_Main.IsStart == false && Betting_Main.startBet == false)
        {
            Win = false;
            First = false;
            timeStopInvoked = false;
        }
    }



    private void TimeStop()
    {
        Time.timeScale = 0f;
    }

    IEnumerator MoveUp()
    {
        if (Betting_Main.ConfirmBet == true)
        {
            while (true)
            {
                speed = Random.Range(10, 15);
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("FinishLine"))
        {
            Win = true;
            Invoke("ONcredit", 0.7f);
            
            if (!First)
            {
                text.text = "1st:<color=" + colorName + ">" + gameObject.name + "</color>"; //����� �̸� ����(�ٵ� ���峲)

                WinnerName = gameObject.name;
                Invoke("PlayBGM", 0.7f);
                if (WinnerName == Betting_Main.BettingWinner)
                {
                    Debug.Log("���� ����");
                    float Reward = Betting_Main.BettingAmount * 2;
                    Betting_Main.NowMoney += Reward;
                    UpdateMoneyUI();
                }
                else if (WinnerName != Betting_Main.BettingWinner)
                {
                    Debug.Log("���� ����");
                }

                First = true; //��¼� �浹 �Է� ����
            }
        }
    }
    private void PlayBGM()
    {
        SoundManager.Instance.PlaySound(3);
    }

    private void UpdateMoneyUI()
    {
        Betting_Main.NowMoneyText.text = "���� �ܾ�: " + Betting_Main.NowMoney;
        Betting_Main.NowMoneyText2.text = "���� �ܾ�: " + Betting_Main.NowMoney;
    }
    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI();
            
        }
    }
}