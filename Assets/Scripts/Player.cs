using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private runPlayer runPlayer;
    public float speed = 10f;
    private UIManager uiManager;

    bool Win;

    // Start is called before the first frame update
    void Start()
    {
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
        rigid.velocity = new Vector2(speed * move,0f);
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

        Invoke("ONcredit", 0.7f);


    }

    public void ONcredit()
    {
        if (uiManager != null)
        {
            uiManager.EnableCreditUI(); // UIManager의 EnableCreditUI 호출하여 이미지 활성화
        }
    }
}
