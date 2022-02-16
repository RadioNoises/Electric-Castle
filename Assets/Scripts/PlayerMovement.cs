using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origiginalPosition, targetPosition;
    private float timeToMove = 0.2f;
    private MapManager mapManager;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
    }
        

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving && mapManager.CheckTravesability(Vector3.forward))
            StartCoroutine(MovePlayer(Vector3.forward));

        if (Input.GetKey(KeyCode.A) && !isMoving && mapManager.CheckTravesability(Vector3.left))
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving && mapManager.CheckTravesability(Vector3.back))
            StartCoroutine(MovePlayer(Vector3.back));

        if (Input.GetKey(KeyCode.D) && !isMoving && mapManager.CheckTravesability(Vector3.right))
            StartCoroutine(MovePlayer(Vector3.right));

    }


    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origiginalPosition = transform.position;
        targetPosition = origiginalPosition + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origiginalPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;


        isMoving = false;

    }
}
