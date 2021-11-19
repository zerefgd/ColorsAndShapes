using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player { RED,BLUE,GREEN,YELLOW,PURPLE,ORANGE}

public enum Choice { RED, BLUE, GREEN, YELLOW, PURPLE, ORANGE, TRIANGLE, RECTANGLE, SQUARE, STAR, HEXAGON, CIRCLE }

public static class Constants
{
    public const string ROLL_CARD = "ROLL A CARD";
    public const string ROLL_COLOR = "ROLL COLOR";
    public const string ROLL_SHAPE = "ROLL SHAPE";
    public const string MOVE_BACK = "MOVE BACK 1 STEP";
    public const string MOVE_FORWARD = "MOVE FORWARD 2 STEPS";
}
