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
                text.text = "1st: " + gameObject.name;  // �÷��̾��� �̸��� ����ڷ� ���
                Debug.Log("���");

                First = true;
            }
        }
    }

    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI(); // UIManager�� EnableCreditUI ȣ���Ͽ� �̹��� Ȱ��ȭ
        }
    }
}