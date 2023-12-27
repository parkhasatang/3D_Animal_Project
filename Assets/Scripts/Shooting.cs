using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Vector3 mouseDownPosition;
    private Vector3 mouseUpPosition;

    private bool isAnimalShoot;

    private Rigidbody rb;
    private SlingShot slingShot;

    [SerializeField]private float forcePower;


    private bool isShoot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        slingShot = FindObjectOfType<SlingShot>();
    }

    private void Update()
    {
        if (!isAnimalShoot)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, 1<<8)) // ��Ҵ��� ���θ� bool�� ��ȯ�ϰ�, ���� ���� �������� ���� �����ϰ�ʹ�. �ΰ����� ��ȯ�ϰ� ���� �� out�̶�� Ű���带 ��.
            {
                transform.position = raycastHit.point;
            }
        }
    }

    private void OnMouseDown()
    {
        mouseDownPosition = Input.mousePosition;
        slingShot.isMouseDown = true;
        isAnimalShoot = false;
    }

    private void OnMouseUp()
    {
        isAnimalShoot = true;
        rb.isKinematic = false;
        mouseUpPosition = Input.mousePosition;
        Shoot(mouseDownPosition - mouseUpPosition);
    }

    private void Shoot(Vector3 shootForce)
    {
        if (isShoot)
        {
            return;
        }

        rb.AddForce(new Vector3(shootForce.x, shootForce.y, shootForce.y) * forcePower);// z�� ĭ�� shootForce.z��� ������ ���� ����Ʀ.
        isShoot = true;
    }
}
