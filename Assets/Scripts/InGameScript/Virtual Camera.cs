using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEditor.Purchasing;


public class VirtualCamera : MonoBehaviour
{
    private Player player;

    [Header("시점 이동")]
    public Button plyer0;
    public Button plyer1;
    public Button plyer2;
    public Button plyer3;
    public Button plyer4;

    [Header("카메라")]
    public CinemachineVirtualCamera view0;
    public CinemachineVirtualCamera view1;
    public CinemachineVirtualCamera view2;
    public CinemachineVirtualCamera view3;
    public CinemachineVirtualCamera view4;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();

        plyer0.onClick.AddListener(plyer0Btn);
        plyer1.onClick.AddListener(plyer1Btn);
        plyer2.onClick.AddListener(plyer2Btn);
        plyer3.onClick.AddListener(plyer3Btn);
        plyer4.onClick.AddListener(plyer4Btn);


        view0.Priority = 0;
        view1.Priority = 0;
        view2.Priority = 10;
        view3.Priority = 0;
        view4.Priority = 0;
    }

    void plyer0Btn()
    {
        SetCameraPriority(view0);
    }
    void plyer1Btn()
    {
        SetCameraPriority(view1);
    }
    void plyer2Btn()
    {
        SetCameraPriority(view2);
    }
    void plyer3Btn()
    {
        SetCameraPriority(view3);
    }
    void plyer4Btn()
    {
        SetCameraPriority(view4);
    }

    private void FixedUpdate()
    {
        if (Player.Win == true)
        {
            Move();
        }
    }

    public void Move()
    {
        if (Player.First == true)
        {
            if (Player.WinnerName == "Red")
            {
                SetCameraPriority(view0);
            }
            if (Player.WinnerName == "Orange")
            {
                SetCameraPriority(view1);
            }
            if (Player.WinnerName == "Yellow")
            {
                SetCameraPriority(view2);
            }
            if (Player.WinnerName == "Green")
            {
                SetCameraPriority(view3);
            }
            if (Player.WinnerName == "Blue")
            {
                SetCameraPriority(view4);
            }
        }
    }

    private void SetCameraPriority(CinemachineVirtualCamera targetCamera)
    {
        view0.Priority = 0;
        view1.Priority = 0;
        view2.Priority = 0;
        view3.Priority = 0;
        view4.Priority = 0;

        targetCamera.Priority = 10;
    }
}
