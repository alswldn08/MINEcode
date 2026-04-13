using JetBrains.Annotations;
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
    private UIManager uiManager;

    public static GameObject[] player;
    public GameObject eventPlayer;

    public float speed = 10f;

    public static bool Win = false;
    public static bool First = false;
    public static bool timeStopInvoked = false;

    public Text text;
    public string colorName;
    public static string WinnerName;


    void Start()
    {
        Time.timeScale = 1f;
        if (text == null)
        {
            text = GameObject.Find("Text").GetComponent<Text>();
        }
        player = GameObject.FindGameObjectsWithTag("Player");
        //itemScript = GetComponent<ItemScript>();
        Betting_Main = FindObjectOfType<Betting_Main>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveUp());
        uiManager = FindObjectOfType<UIManager>();
    }
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
                text.text = "1st:<color=" + colorName + ">" + gameObject.name + "</color>";

                WinnerName = gameObject.name;
                Invoke("PlayBGM", 0.7f);
                if (WinnerName == Betting_Main.BettingWinner)
                {
                    float Reward = Betting_Main.BettingAmount * ItemScript.OnDice;
                    Betting_Main.NowMoney += Reward;
                    UpdateMoneyUI();
                }
                else if (WinnerName != Betting_Main.BettingWinner)
                {
                    Debug.Log("우승자 이름 없음");
                }

                First = true;
            }
        }
    }
    private void PlayBGM()
    {
        SoundManager.Instance.PlaySound(3);
    }

    private void UpdateMoneyUI()
    {
        Betting_Main.NowMoneyText.text = "현재 보유 금액: " + Betting_Main.NowMoney;
        Betting_Main.NowMoneyText2.text = "현재 보유 금액: " + Betting_Main.NowMoney;
    }
    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI();
            
        }
    }

    public void Action0()
    {
        int randomIndex = Random.Range(0, player.Length);
        GameObject selectedPlayer = player[randomIndex];

        Rigidbody2D selectedPlayerRigidbody = selectedPlayer.GetComponent<Rigidbody2D>();

        if (selectedPlayerRigidbody != null)
        {
            selectedPlayerRigidbody.velocity = new Vector2(-5f, selectedPlayerRigidbody.velocity.y);
        }
    }


    public void Action1()
    {
        Debug.Log("Action1");
    }
    public void Action2()
    {
        Debug.Log("Action2");
    }
}