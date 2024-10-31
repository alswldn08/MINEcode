using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private runPlayer runPlayer;
    public float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        runPlayer = FindObjectOfType<runPlayer>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveUp());
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
    IEnumerator MoveUp()
    {
        if (runPlayer.StartBtn == true)
        {
            while (true)
            {
                speed = Random.Range(4, 8);
                yield return new WaitForSeconds(3);
                Debug.Log("นÝบน");
            }
        }
    }
}
