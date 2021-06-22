using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apple : MonoBehaviour
{
    private int uniqueNum;
    public int UniquNum { get { return uniqueNum; } }
    [SerializeField]
    Text text;

    private void Update()
    {
        text.text = uniqueNum.ToString();
    }

    public void SetUniqueNum()
    {
        uniqueNum = Random.Range(1, 10);
    }
}
