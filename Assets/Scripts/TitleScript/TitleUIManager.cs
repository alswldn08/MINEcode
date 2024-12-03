using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{
    [Header("���� ��ư")]
    public Button StartBtn;
    public Button SettingBtn;
    public Button HelpBtn;
    [Header("�ݱ� ��ư")]
    public Button ExitHelpBtn;
    public Button ExitSettingBtn;
    [Header("�̹���")]
    public Image SettingPG;
    public Image HelpPG;
    

    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(ClickStartBtn);
        SettingBtn.onClick.AddListener(ClickSettingBtn);
        HelpBtn.onClick.AddListener(ClickHelpBtn);
        ExitHelpBtn.onClick.AddListener(ClickExitHelpBtn);
        ExitSettingBtn.onClick.AddListener(ClickExitSettingBtn);

        SettingPG.gameObject.SetActive(false);
        HelpPG.gameObject.SetActive(false);
        
    }

    private void ClickStartBtn()
    {
        SceneManager.LoadScene("InGame");
    }
    private void ClickSettingBtn()
    {
        SettingPG.gameObject.SetActive(true);
    }
    private void ClickHelpBtn()
    {
        HelpPG.gameObject.SetActive(true);
    }
    private void ClickExitHelpBtn()
    {
        HelpPG.gameObject.SetActive(false);
    }
    private void ClickExitSettingBtn()
    {
        SettingPG.gameObject.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
