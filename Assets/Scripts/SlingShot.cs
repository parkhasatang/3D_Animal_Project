using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] slingShotLine;
    public Transform[] stripPosition;
    public Transform idlePosition;

    public Transform currentAnimalTransform;

    private LaunchingPad launchingPad;

    public bool isMouseDown;

    private void Awake()
    {
        launchingPad = GetComponent<LaunchingPad>();
    }
    void Start()
    {
        Refresh();
    }

    
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 stripPosition = launchingPad.currentAnimalTransform.position;
            stripPosition.z = stripPosition.z -0.3f;
            SetStripPoint(stripPosition);
            if (stripPosition.z > idlePosition.position.z)
            {
                IdleSlingShot();
                isMouseDown = false;
            }
        }
        else
        {
            IdleSlingShot();
        }
    }
    private void IdleSlingShot()
    {
        SetStripPoint(idlePosition.position);
    }
    //������ Line�� ��ġ �ϳ� ������ߴ�
    private void SetStripPoint(Vector3 position)
    {
        slingShotLine[0].SetPosition(1, position);
        slingShotLine[1].SetPosition(1, position);
        // �ΰ��� Line�� ���� ���� ���� position�� ������ ���� �̾�������
    }

    public void Refresh()
    {
        slingShotLine[0].positionCount = 2;
        slingShotLine[1].positionCount = 2;
        slingShotLine[0].SetPosition(0, stripPosition[0].position);
        slingShotLine[1].SetPosition(0, stripPosition[1].position);
    }
}
