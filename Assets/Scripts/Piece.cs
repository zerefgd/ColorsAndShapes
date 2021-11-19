using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField]
    List<Color> colors;

    bool canMove;
    int currentPos;
    List<int> movePos;
    float speed = 10f;

    private void Awake()
    {
        canMove = false;
        currentPos = 0;
    }

    private void Update()
    {
        if (!canMove) return;
        Vector3 targetPos = GameManager.instance.indexToVector[movePos[currentPos]];
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if(Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            currentPos++;
            if(currentPos == movePos.Count)
            {
                canMove = false;
                currentPos = 0;
            }
        }
    }

    public void SetColor(Player player)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = colors[(int)player];
    }

    public void SetPos(List<int> temp)
    {
        movePos = temp;
        if (temp.Count == 0) return;
        canMove = true;
    }

    public void SetPos(List<int> temp, bool add)
    {
        movePos.Add(temp[0]);
    }

}
