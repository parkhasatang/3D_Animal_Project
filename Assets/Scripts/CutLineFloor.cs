using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLineFloor : MonoBehaviour
{
    private Transform generateFloorPosition;

    private void Awake()
    {
        generateFloorPosition = transform;
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("FreezeAnimal")) // ���Ⱑ ����, if�� ����ȉ�. = rigidBody������ �νľȉ�. �ذ�Ϸ�
        {
            Vector3 upYPosition = new Vector3(GameManager.instance.room.transform.position.x, (GameManager.instance.room.transform.position.y + 2.4f), GameManager.instance.room.transform.position.z);
            generateFloorPosition = Instantiate(GameManager.instance.room, upYPosition, Quaternion.identity).transform;
            GameManager.instance.room = generateFloorPosition.gameObject;
            GameManager.instance.launchingPad.transform.position += new Vector3(0, 2.4f, 0);
            GameManager.instance.launchingPad.StripRefresh();
            Destroy(gameObject);
        }
    }
}
