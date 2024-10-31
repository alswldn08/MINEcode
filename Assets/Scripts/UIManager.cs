using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("¸Þ´º")]
    public Button MenuBtn;
    public Button ExitMenuBtn;
    public Image MenuPG;
    // Start is called before the first frame update
    void Start()
    {
        MenuBtn.onClick.AddListener(OnclickMenuBtn);
        ExitMenuBtn.onClick.AddListener(OnclickExitMenuBtn);
        MenuPG.gameObject.SetActive(false);
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
    void Update()
    {
        
    }
}
