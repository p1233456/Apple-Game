using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSquare : MonoBehaviour
{
    [SerializeField]
    List<Apple> selectedApple = new List<Apple>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            selectedApple.Add(collision.GetComponent<Apple>());
            collision.GetComponent<Apple>().Select();
        }
        catch
        {
            Debug.LogError("That's not Apple");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<Apple>().UnSelect();
            selectedApple.Remove(collision.GetComponent<Apple>());
        }
        catch
        {
            Debug.LogError("That's not Apple");
        }
    }

    private void RemoveApple()
    {
        int tmp = 0;
        foreach(Apple apple in selectedApple)
        {
            tmp += apple.UniquNum;
        }
        if(tmp == 10)
        {
            for(int i = selectedApple.Count - 1; i >= 0; i--)
            {
                Destroy(selectedApple[i].gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        RemoveApple();
    }

    public void DragEnd()
    {
        RemoveApple();
        Destroy(this.gameObject);
    }
}
