using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Apple : MonoBehaviour
{
    private int uniqueNum;
    public int UniquNum { get { return uniqueNum; } }

    public void SetUniqueNum()
    {
        uniqueNum = Random.Range(1, 10);
    }
}
