using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField]
    List<Sprite> cardSprites, colorSprites, shapeSprites;

    string cardType;
    Choice currentChoice;

    public void SetRandomCard()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = cardSprites[Random.Range(0, cardSprites.Count)];
    }

    public void SetRandomColor()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = colorSprites[Random.Range(0, colorSprites.Count)];
    }

    public void SetRandomShape()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = shapeSprites[Random.Range(0, shapeSprites.Count)];
    }

    public void RollCard(string temp)
    {
        cardType = temp;
        Animator animator = GetComponent<Animator>();
        animator.Play("RollCard", -1, 0f);
    }

    public void RollColor(Choice choice)
    {
        currentChoice = choice; 
        Animator animator = GetComponent<Animator>();
        animator.Play("RollColor", -1, 0f);
    }

    public void RollShape(Choice choice)
    {
        currentChoice = choice;
        Animator animator = GetComponent<Animator>();
        animator.Play("RollShape", -1, 0f);
    }

    public void SetCard()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = cardType == Constants.ROLL_COLOR ? cardSprites[0] : cardType == Constants.ROLL_SHAPE  ? cardSprites[1] :
                          cardType == Constants.MOVE_FORWARD ? cardSprites[1] : cardType == Constants.MOVE_BACK ? cardSprites[3] :
                         cardSprites[0];
        GameManager.instance.canClick = true;
    }

    public void SetColor()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = currentChoice == Choice.RED ? colorSprites[0] : currentChoice == Choice.BLUE ? colorSprites[1] :
                          currentChoice == Choice.GREEN ? colorSprites[2] : currentChoice == Choice.YELLOW ? colorSprites[3] :
                          currentChoice == Choice.PURPLE? colorSprites[4] : currentChoice == Choice.ORANGE? colorSprites[5] :
                          colorSprites[0];
        GameManager.instance.MovePlayer();
    }

    public void SetShape()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = currentChoice == Choice.TRIANGLE ? shapeSprites[0] : currentChoice == Choice.RECTANGLE? shapeSprites[1] :
                          currentChoice == Choice.SQUARE ? shapeSprites[2] : currentChoice == Choice.STAR? shapeSprites[3] :
                          currentChoice == Choice.HEXAGON ? shapeSprites[4] : currentChoice == Choice.CIRCLE? shapeSprites[5] :
                          shapeSprites[0];
        GameManager.instance.MovePlayer();
    }
}
