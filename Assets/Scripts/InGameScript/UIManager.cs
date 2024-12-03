using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [Header("메뉴")]
    public Button MenuBtn;
    public Button ExitMenuBtn;
    public Image MenuPG;
    public GameObject ImageS;
    public Image creditPG;
    public Button GoTitle;
    public Button RePlay;

    private Player player;
    private Betting_Main Betting;
    public Image EndingPG;
    public bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        Betting = GetComponent<Betting_Main>();
        player = GetComponent<Player>();

        if (PlayerPrefs.HasKey("NowMoney"))
        {
            Betting.NowMoney = PlayerPrefs.GetFloat("NowMoney");
        }

        GoTitle.onClick.AddListener(OnClickGoTitle);
        MenuBtn.onClick.AddListener(OnclickMenuBtn);
        ExitMenuBtn.onClick.AddListener(OnclickExitMenuBtn);
        MenuPG.gameObject.SetActive(false);
        creditPG.gameObject.SetActive(false);
        ImageS.gameObject.SetActive(true);

        EndingPG.gameObject.SetActive(false);
        RePlay.onClick.AddListener(OnClickRePlay);
    }


    public void OnClickGoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    private void OnClickRePlay()
    {
        SaveMoney(); // 현재 잔액 저장
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 씬 재로드
        
        Betting.BettingAmount = 0;
        Betting.BettingWinner = "";
        Betting.IsStart = false;
        Betting.startBet = false;
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetFloat("NowMoney", Betting.NowMoney); // NowMoney를 PlayerPrefs에 저장
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

    // Update is called once per frame
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
            player.ONcredit(); // Player의 ONcredit
        }
    }
}
