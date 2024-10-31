using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform obj;
    public Vector3 Normaloffset;

    private UIManager manager;
    private runPlayer playerObj;

    void Start()
    {
        manager = FindObjectOfType<UIManager>();
        playerObj = FindObjectOfType<runPlayer>();
    }

    void LateUpdate()
    {
            transform.position = obj.position + Normaloffset;
    }
}
