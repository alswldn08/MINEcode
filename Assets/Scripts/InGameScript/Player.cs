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
                Debug.Log("반복");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Win = true;

        // 0.7초 후 ONcredit 메서드 호출
        Invoke("ONcredit", 0.7f);

        if (collision.CompareTag("FinishLine"))
        {
            // 최초로 충돌한 경우에만 우승 처리
            if (!First)
            {
                text.text = "1st:<color=" + colorName + ">" + gameObject.name + "</color>"; //우승자 이름 띄우기
                Debug.Log("<color=" + colorName + ">우승</color>");


                WinnerName = gameObject.name;

                if(WinnerName == Betting_Main.BettingWinner)
                {
                    Debug.Log("배팅 성공");
                    float Reward = Betting_Main.BettingAmount * 2;
                    Betting_Main.NowMoney += Reward;
                    UpdateMoneyUI();
                }
                else if (WinnerName != Betting_Main.BettingWinner)
                {
                    Debug.Log("배팅 실패");
                }

                First = true; //결승선 충돌 입력 정지
            }
        }
    }
    private void UpdateMoneyUI()
    {
        Betting_Main.NowMoneyText.text = "남은 잔액: " + Betting_Main.NowMoney;
        Betting_Main.NowMoneyText2.text = "남은 잔액: " + Betting_Main.NowMoney;
    }
    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI();
        }
    }
}