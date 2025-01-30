using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMoveTowards : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] float speed;

    void Update()
    {
        var step = speed * Time.deltaTime * Vector2.Distance(playerPos.position, gameObject.transform.position);
        Vector2 newPos = Vector2.MoveTowards(transform.position, playerPos.position, step);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
