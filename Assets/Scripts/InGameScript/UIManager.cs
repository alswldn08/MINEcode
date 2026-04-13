using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    public Button MenuBtn;
    public Button ExitMenuBtn;
    public Button GoTitle;
    public Button RePlay;

    [Header("Page")]
    public Image MenuPG;
    public Image creditPG;
    public Image EndingPG;

    public GameObject ImageS;

    private Player player;
    private Betting_Main Betting;
    private ItemScript itemScript;

    void Start()
    {
        itemScript = GetComponent<ItemScript>();
        Betting = GetComponent<Betting_Main>();
        player = GetComponent<Player>();

        if (PlayerPrefs.HasKey("NowMoney"))
        {
            Betting.NowMoney = PlayerPrefs.GetFloat("NowMoney");
        }

        GoTitle.onClick.AddListener(OnClickGoTitle);
        MenuBtn.onClick.AddListener(OnclickMenuBtn);
        ExitMenuBtn.onClick.AddListener(OnclickExitMenuBtn);
        RePlay.onClick.AddListener(OnClickRePlay);
        MenuPG.gameObject.SetActive(false);
        creditPG.gameObject.SetActive(false);
        ImageS.gameObject.SetActive(true);
        EndingPG.gameObject.SetActive(false);
    }

    public void OnClickGoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    private void OnClickRePlay()
    {
        SaveMoney();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        Betting.BettingAmount = 0;
        Betting.BettingWinner = "";
        Betting.IsStart = false;
        Betting.startBet = false;
        Betting.BettingPlayer = false;
        //itemScript.OnDice = 1f;
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetFloat("NowMoney", Betting.NowMoney);
        PlayerPrefs.Save();
    }

    private void OnclickExitMenuBtn()
    {
        MenuPG.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnclickMenuBtn()
    {
        MenuPG.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    public void EnableCreditUI()
    {
        if (creditPG != null)
        {
            creditPG.gameObject.SetActive(true);
            ImageS.gameObject.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
        if (Betting.NowMoney == 5000000f)
        {
            EndingPG.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void ActivateONcreditFromPlayer()
    {
        if (player != null)
        {
            player.ONcredit();
        }
    }
}
