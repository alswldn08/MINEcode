using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("메뉴")]
    public Button MenuBtn;
    public Button ExitMenuBtn;
    public Image MenuPG;
    public GameObject ImageS;

    public Image creditPG;

    private Player Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Player>();

        MenuBtn.onClick.AddListener(OnclickMenuBtn);
        ExitMenuBtn.onClick.AddListener(OnclickExitMenuBtn);
        MenuPG.gameObject.SetActive(false);
        creditPG.gameObject.SetActive(false);
        ImageS.gameObject.SetActive(true);
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
            creditPG.gameObject.SetActive(true); // UI 이미지 활성화
            ImageS.gameObject.SetActive(false);
        }
    }

    public void ActivateONcreditFromPlayer()
    {
        if (Player != null)
        {
            Player.ONcredit(); // Player의 ONcredit 호출
        }
    }
}
