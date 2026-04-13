using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    private Player player;

    [Header("Button")]
    public Button plyer0;
    public Button plyer1;
    public Button plyer2;
    public Button plyer3;
    public Button plyer4;

    [Header("VirtualCamera")]
    public CinemachineVirtualCamera view0;
    public CinemachineVirtualCamera view1;
    public CinemachineVirtualCamera view2;
    public CinemachineVirtualCamera view3;
    public CinemachineVirtualCamera view4;

    private CinemachineVirtualCamera activeCamera;

    public Transform finishLine;

    [Header("UI")]
    public Text distanceText;

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

        activeCamera = view2;
        finishLine = GameObject.FindGameObjectWithTag("FinishLine").transform;

        if (distanceText == null)
        {
            Debug.LogError("텍스트 없음");
        }
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

        if (activeCamera != null && finishLine != null)
        {
            float distance = Mathf.Abs(activeCamera.transform.position.x - finishLine.position.x);

            if (distanceText != null)
            {
                distanceText.text = "남은 거리: " + distance.ToString("F2") + "M";
            }
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

        activeCamera = targetCamera;
    }
}
