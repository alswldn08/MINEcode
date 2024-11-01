using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runPlayer : MonoBehaviour
{
    public Button StartBtn;
    public static bool IsStart;
    public GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(OnclickStartBtn);
    }

    public void OnclickStartBtn()
    {
        IsStart = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
