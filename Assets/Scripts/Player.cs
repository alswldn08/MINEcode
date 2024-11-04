using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private runPlayer runPlayer;
    public float speed = 10f;
    private UIManager uiManager;


    public static bool Win;

    public Text text;

    private bool First = false;
    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
        {
            text = GameObject.Find("Text").GetComponent<Text>();
        }

        runPlayer = FindObjectOfType<runPlayer>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveUp());
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float move = 0f;

        if (runPlayer.IsStart == true)
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
        if (runPlayer.StartBtn == true)
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
                text.text = "1st: " + gameObject.name;  // 플레이어의 이름을 우승자로 기록
                Debug.Log("우승");

                First = true;
            }
        }
    }

    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI(); // UIManager의 EnableCreditUI 호출하여 이미지 활성화
        }
    }
}