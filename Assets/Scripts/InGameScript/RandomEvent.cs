using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLineCollision : MonoBehaviour
{
    private bool hasCollided = false;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("EventLine") && !hasCollided)
        {

            hasCollided = true;
            int randomValue = Random.Range(0, 3);

            switch (randomValue)
            {
                case 0:
                    player.Action0();
                    break;
                case 1:
                    player.Action1();
                    break;
                case 2:
                    player.Action2();
                    break;
            }
        }
    }


    public void ResetCollision()
    {
        hasCollided = false;
    }
}
