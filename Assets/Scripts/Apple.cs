using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apple : MonoBehaviour
{
    private int uniqueNum;
    public int UniqueNum { get { return uniqueNum; } }
    [SerializeField]
    private List<GameObject> Numbers;
    [SerializeField]
    private GameObject selectedLight;
    private bool selected;

    private void Start()
    {
        selectedLight.SetActive(false);
    }

    public void SetUniqueNum()
    {
        uniqueNum = Random.Range(1, 10);
        Instantiate(Numbers[uniqueNum - 1],gameObject.transform).transform.position = Vector2.zero;
    }

    public void Select()
    {
        selectedLight.SetActive(true);
        selected = true;
    }

    public void UnSelect()
    {
        selectedLight.SetActive(false);
        selected = false;
    }

    private void OnDestroy()
    {
        FindObjectOfType<ScoreManager>().GetScore();
    }
}
