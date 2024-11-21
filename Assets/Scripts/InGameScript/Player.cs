using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Betting_Main Betting_Main;
    public float speed = 10f;
    private UIManager uiManager;


    private static bool Win;

    public Text text;

    public string colorName;

    private static bool First = false;

    public static string WinnerName;


    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
        {
            text = GameObject.Find("Text").GetComponent<Text>();
        }

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
    }

    private void Update()
    {
        if (Win == true)
        {
            Time.timeScale = 0.4f;
        }
    }

    IEnumerator MoveUp()
    {
        if (Betting_Main.ConfirmBet == true)
        {
            while (true)
            {
                speed = Random.Range(4, 8);
                yield return new WaitForSeconds(3);
                Debug.Log("�ݺ�");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Win = true;

        // 0.7�� �� ONcredit �޼��� ȣ��
        Invoke("ONcredit", 0.7f);

        if (collision.CompareTag("FinishLine"))
        {
            // ���ʷ� �浹�� ��쿡�� ��� ó��
            if (!First)
            {
                text.text = "1st:<color=" + colorName + ">" + gameObject.name + "</color>"; //����� �̸� ����
                Debug.Log("<color=" + colorName + ">���</color>");


                WinnerName = gameObject.name;

                if(WinnerName == Betting_Main.BettingWinner)
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