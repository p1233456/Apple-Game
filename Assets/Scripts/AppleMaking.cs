using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AppleMaking : MonoBehaviour
{
    [SerializeField]
    private Vector2 appleWhiteSpace;
    [SerializeField]
    private Space whiteSpace;
    [SerializeField]
    private GameObject applePrefab;
    public int row;
    public int column;
    public float heightSpace;
    public float widthSapce;
    private GameObject MakeApple()
    {
        GameObject appleObject = Instantiate(applePrefab);
        appleObject.GetComponent<Apple>().SetUniqueNum();
        return appleObject;
    }

    public void Test()
    {
        MakeAppleMap(row, column, heightSpace, widthSapce);
    }

    public void MakeAppleMap(int row, int column, float heightSpace, float widthSpace)
    {
        Vector2 leftUp = new Vector2(Camera.main.orthographicSize * Camera.main.aspect * -1f + widthSapce + whiteSpace.left, Camera.main.orthographicSize - heightSpace - whiteSpace.up);
        Vector2 rightDown = new Vector2(Camera.main.orthographicSize * Camera.main.aspect - widthSapce - whiteSpace.right, Camera.main.orthographicSize * -1f + heightSpace + whiteSpace.down);

        GameObject apple = null;
        Vector2 appleSize = new Vector2((rightDown.x - leftUp.x - appleWhiteSpace.x * (column - 1)) / column, (leftUp.y - rightDown.y - (row - 1) * appleWhiteSpace.y) / row);
        for (int i = 0; i < row; i++)    //세로줄
        {
            for (int ii = 0; ii < column; ii++)  //가로줄
            {
                apple = MakeApple();
                apple.transform.localScale = appleSize;
                apple.transform.position = new Vector2(leftUp.x + appleSize.x * 0.5f + ii * (appleSize.x + appleWhiteSpace.x), rightDown.y + appleSize.y * 0.5f + i * (appleSize.y + appleWhiteSpace.y));
            }
        }
    }
}

[Serializable]
public struct Space
{
    public float up;
    public float down;
    public float left;
    public float right;
}