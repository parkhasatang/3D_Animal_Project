using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] slingShotLine;
    public Transform[] stripPosition;
    public Transform idlePosition;

    private bool isMouseDown;
    void Start()
    {
        slingShotLine[0].positionCount = 2;
        slingShotLine[1].positionCount = 2;
        slingShotLine[0].SetPosition(0, stripPosition[0].position);
        slingShotLine[1].SetPosition(0, stripPosition[1].position);
    }

    
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetStripPoint(mousePosition);
        }
        else if (!isMouseDown)
        {
            IdleSlingShot();
        }
        else
        {
            return;
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
    }

    private void IdleSlingShot()
    {
        SetStripPoint(idlePosition.position);
    }
    //나머지 Line점 위치 하나 정해줘야댐
    private void SetStripPoint(Vector3 position)
    {
        slingShotLine[0].SetPosition(1, position);
        slingShotLine[1].SetPosition(1, position);
        // 두개의 Line의 점이 같은 곳의 position을 가져서 선이 이어져보임
    }
}
