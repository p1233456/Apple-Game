using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private Vector2 MousePosition
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private bool isDragging { get { return instatiatedDragSquare != null; } }
    [SerializeField]
    private Vector2 dragStart;
    [SerializeField]
    private GameObject dragSquare;
    private GameObject instatiatedDragSquare;
    private bool isPlaying;

    private void Start()
    {
        instatiatedDragSquare = null;
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying)
        {
            DragInput();
            if (isDragging)
            {
                SetDragSquare(instatiatedDragSquare, dragStart, MousePosition);
            }
        }
    }

    private void SetDragSquare(GameObject square, Vector2 dragStartPoint, Vector2 currentMousePosition)
    {
        square.transform.position = new Vector2((currentMousePosition.x - dragStartPoint.x) / 2 + dragStartPoint.x, (currentMousePosition.y - dragStartPoint.y) / 2 + dragStartPoint.y);
        square.transform.localScale = new Vector2(currentMousePosition.x - dragStartPoint.x, currentMousePosition.y - dragStartPoint.y);
    }

    private void DragStart()
    {
        dragStart = MousePosition;
        instatiatedDragSquare = Instantiate(dragSquare,dragStart,Quaternion.identity);
    }

    private void DragEnd()
    {
        instatiatedDragSquare.GetComponent<DragSquare>().DragEnd();
        instatiatedDragSquare = null;
    }

    private void DragInput()
    {
        if (Input.GetMouseButtonDown(0))
            DragStart();
        if (Input.GetMouseButtonUp(0))
            DragEnd();
    }

    public void GameStart()
    {
        isPlaying = true;
    }

    public void GameOver()
    {
        isPlaying = false;
    }
}
