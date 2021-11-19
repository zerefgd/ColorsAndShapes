using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{

    List<Player> players;
    Dictionary<Player, int> playerPos;
    Dictionary<int, Dictionary<Choice,int>> movePositions;

    public Board()
    {
        players = new List<Player>();
        playerPos = new Dictionary<Player, int>();
        movePositions = new Dictionary<int, Dictionary<Choice, int>>();

        for (int i = 0; i < 6; i++)
        {
            players.Add((Player)i);
            playerPos[(Player)i] = 0;
        }

        SetMovePositions();
    }

    public List<int> UpdatePos(Player currentPlayer,Choice playerChoice)
    {
        List<int> result = new List<int>();
        int lastIndex;
        if(!movePositions[playerPos[currentPlayer]].TryGetValue(playerChoice, out lastIndex))
        {
            return result;
        }
        for(int i = playerPos[currentPlayer] + 1; i <= lastIndex; i++)
        {
            result.Add(i);
        }
        playerPos[currentPlayer] = lastIndex;
        return result;

    }

    public List<int> UpdatePos(Player currentPlayer, int diff)
    {
        List<int> result = new List<int>();
        int lastIndex = playerPos[currentPlayer] + diff;
        if (lastIndex < 0 || lastIndex > 57)
        {
            return result;
        }
        int diffint = diff > 0 ? 1 : -1;
        for (int i = playerPos[currentPlayer] + diffint; i != lastIndex; i += diffint )
        {
            result.Add(i);
        }
        result.Add(lastIndex);
        playerPos[currentPlayer] = lastIndex;
        return result;
    }

    public List<Player> UpdateSwap(Player currentPlayer)
    {
        List<Player> result = new List<Player>();
        foreach (Player player in players)
        {
            if(playerPos[player] == 43)
            {
                result.Add(player);
                playerPos[player] = 20;
            }
        }
        playerPos[currentPlayer] = 43;
        return result;
    }

    void SetMovePositions()
    {
        movePositions[0] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 4 },{ Choice.BLUE, 5 },{ Choice.GREEN, 3 },{ Choice.YELLOW, 2 },{ Choice.PURPLE, 1 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 4 },{ Choice.SQUARE, 1 },{ Choice.RECTANGLE, 3 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 5 },{ Choice.CIRCLE, 2 }
        };
        movePositions[1] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 4 },{ Choice.BLUE, 5 },{ Choice.GREEN, 3 },{ Choice.YELLOW, 2 },{ Choice.PURPLE, 6 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 4 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 3 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 5 },{ Choice.CIRCLE, 2 }
        };
        movePositions[2] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 4 },{ Choice.BLUE, 5 },{ Choice.GREEN, 3 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 6 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 4 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 3 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 5 },{ Choice.CIRCLE, 6 }
        };
        movePositions[3] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 4 },{ Choice.BLUE, 5 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 6 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 4 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 5 },{ Choice.CIRCLE, 6 }
        };
        movePositions[4] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 5 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 6 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 9 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 5 },{ Choice.CIRCLE, 6 }
        };
        movePositions[5] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 9 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 6 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 9 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 10 },{ Choice.CIRCLE, 6 }
        };
        movePositions[6] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 9 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 7 },
            { Choice.TRIANGLE, 9 },{ Choice.SQUARE, 7 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 10 },{ Choice.CIRCLE, 17 }
        };
        movePositions[7] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 9 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 8 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 9 },{ Choice.SQUARE, 12 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 8 },{ Choice.HEXAGON, 10 },{ Choice.CIRCLE, 17 }
        };
        movePositions[8] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 9 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 9 },{ Choice.SQUARE, 12 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 10 },{ Choice.CIRCLE, 17 }
        };
        movePositions[9] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 12 },{ Choice.GREEN, 10 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 13 },{ Choice.SQUARE, 12 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 10 },{ Choice.CIRCLE, 17 }
        };
        movePositions[10] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 11 },{ Choice.BLUE, 12 },{ Choice.GREEN, 13 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 13 },{ Choice.SQUARE, 12 },{ Choice.RECTANGLE, 11 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 14 },{ Choice.CIRCLE, 17 }
        };
        movePositions[11] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 12 },{ Choice.GREEN, 13 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 13 },{ Choice.SQUARE, 12 },{ Choice.RECTANGLE, 15 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 14 },{ Choice.CIRCLE, 17 }
        };
        movePositions[12] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 22 },{ Choice.GREEN, 13 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 13 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 15 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 14 },{ Choice.CIRCLE, 17 }
        };
        movePositions[13] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 14 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 18 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 15 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 14 },{ Choice.CIRCLE, 17 }
        };
        movePositions[14] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 19 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 15 },
            { Choice.TRIANGLE, 18 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 15 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 17 }
        };
        movePositions[15] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 19 },{ Choice.PURPLE, 16 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 18 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 16 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 17 }
        };
        movePositions[16] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 17 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 19 },{ Choice.PURPLE, 18 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 18 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 17 }
        };
        movePositions[17] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 20 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 19 },{ Choice.PURPLE, 18 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 18 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 21 }
        };
        movePositions[18] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 20 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 19 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 19 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 21 }
        };
        movePositions[19] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 20 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 24 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 20 },{ Choice.CIRCLE, 21 }
        };
        movePositions[20] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 24     },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 21 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 24 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 21 }
        };
        movePositions[21] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 24 },{ Choice.BLUE, 22 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 26 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 24 },{ Choice.RECTANGLE, 22 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[22] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 24 },{ Choice.BLUE, 27 },{ Choice.GREEN, 23 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 26 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 24 },{ Choice.RECTANGLE, 25 },{ Choice.STAR, 23 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[23] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 24 },{ Choice.BLUE, 27 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 26 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 24 },{ Choice.RECTANGLE, 25 },{ Choice.STAR, 27 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[24] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 27 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 25 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 26 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 25 },{ Choice.STAR, 27 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[25] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 27 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 30 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 26 },
            { Choice.TRIANGLE, 26 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 27 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[26] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 27 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 30 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 30 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 27 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[27] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 30 },{ Choice.PURPLE, 28 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 30 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 28 },{ Choice.CIRCLE, 29 }
        };
        movePositions[28] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 29 },{ Choice.YELLOW, 30 },{ Choice.PURPLE, 31 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 30 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 32 },{ Choice.CIRCLE, 29 }
        };
        movePositions[29] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 33 },{ Choice.YELLOW, 30 },{ Choice.PURPLE, 31 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 30 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 32 },{ Choice.CIRCLE, 34 }
        };
        movePositions[30] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 33 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 31 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 31 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 32 },{ Choice.CIRCLE, 34 }
        };
        movePositions[31] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 33 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 36 },{ Choice.ORANGE, 32 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 32 },{ Choice.CIRCLE, 34 }
        };
        movePositions[32] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 33 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 36 },{ Choice.ORANGE, 37 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 33 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 34 }
        };
        movePositions[33] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 34 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 36 },{ Choice.ORANGE, 37 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 36 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 34 }
        };
        movePositions[34] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 35 },{ Choice.BLUE, 41 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 36 },{ Choice.ORANGE, 37 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 36 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 35 },{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 38 }
        };
        movePositions[35] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 40 },{ Choice.BLUE, 41 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 36 },{ Choice.ORANGE, 37 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 36 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 37 },{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 38 }
        };
        movePositions[36] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 40 },{ Choice.BLUE, 41 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 45 },{ Choice.ORANGE, 37 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 37 },{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 38 }
        };
        movePositions[37] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 40 },{ Choice.BLUE, 41 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 38 },{ Choice.PURPLE, 45 },{ Choice.ORANGE, 42 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 47},{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 38 }
        };
        movePositions[38] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 40 },{ Choice.BLUE, 41 },{ Choice.GREEN, 39 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 42 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 39 },{ Choice.STAR, 47},{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 45 }
        };
        movePositions[39] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 40 },{ Choice.BLUE, 41 },{ Choice.GREEN, 44 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 42 },
            { Choice.TRIANGLE, 40 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 43},{ Choice.STAR, 47},{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 45 }
        };
        movePositions[40] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 43 },{ Choice.BLUE, 41 },{ Choice.GREEN, 44 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 42 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 43},{ Choice.STAR, 47},{ Choice.HEXAGON, 41 },{ Choice.CIRCLE, 45 }
        };
        movePositions[41] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 43 },{ Choice.BLUE, 46 },{ Choice.GREEN, 44 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 42 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 42 },{ Choice.RECTANGLE, 43},{ Choice.STAR, 47},{ Choice.HEXAGON, 44 },{ Choice.CIRCLE, 45 }
        };
        movePositions[42] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 43 },{ Choice.BLUE, 46 },{ Choice.GREEN, 44 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 43},{ Choice.STAR, 47},{ Choice.HEXAGON, 44 },{ Choice.CIRCLE, 45 }
        };
        movePositions[43] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 46 },{ Choice.GREEN, 44 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 47},{ Choice.HEXAGON, 44 },{ Choice.CIRCLE, 45 }
        };
        movePositions[44] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 46 },{ Choice.GREEN, 49 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 45 },{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 47},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 45 }
        };
        movePositions[45] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 46 },{ Choice.GREEN, 49 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 46 },{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 47},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 53 }
        };
        movePositions[46] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 48 },{ Choice.GREEN, 49 },{ Choice.YELLOW, 47},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 49},{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 47},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 53 }
        };
        movePositions[47] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 48 },{ Choice.GREEN, 49 },{ Choice.YELLOW, 50},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 49 },{ Choice.SQUARE, 48 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 52},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 53 }
        };
        movePositions[48] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 57 },{ Choice.GREEN, 49 },{ Choice.YELLOW, 50},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 49 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 52},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 53 }
        };
        movePositions[49] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 50},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 54 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 52},{ Choice.HEXAGON, 50 },{ Choice.CIRCLE, 53 }
        };
        movePositions[50] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 54},{ Choice.PURPLE, 52},{ Choice.ORANGE, 51 },
            { Choice.TRIANGLE, 54 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 51},{ Choice.STAR, 52},{ Choice.HEXAGON, 55 },{ Choice.CIRCLE, 53 }
        };
        movePositions[51] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 54},{ Choice.PURPLE, 52},{ Choice.ORANGE, 55 },
            { Choice.TRIANGLE, 54 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 52},{ Choice.HEXAGON, 55 },{ Choice.CIRCLE, 53 }
        };
        movePositions[52] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 53},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 54},{ Choice.PURPLE, 56},{ Choice.ORANGE, 55 },
            { Choice.TRIANGLE, 54 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 55 },{ Choice.CIRCLE, 53 }
        };
        movePositions[53] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 57},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 54},{ Choice.PURPLE, 56},{ Choice.ORANGE, 55 },
            { Choice.TRIANGLE, 54 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 55 },{ Choice.CIRCLE, 57 }
        };
        movePositions[54] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 57},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 57},{ Choice.PURPLE, 56},{ Choice.ORANGE, 55 },
            { Choice.TRIANGLE, 57 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 55 },{ Choice.CIRCLE, 57 }
        };
        movePositions[55] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 57},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 57},{ Choice.PURPLE, 56},{ Choice.ORANGE, 57 },
            { Choice.TRIANGLE, 57 },{ Choice.SQUARE, 56 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 57 },{ Choice.CIRCLE, 57 }
        };
        movePositions[56] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 57},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 57},{ Choice.PURPLE, 57},{ Choice.ORANGE, 57 },
            { Choice.TRIANGLE, 57 },{ Choice.SQUARE, 57 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 57 },{ Choice.CIRCLE, 57 }
        };
        movePositions[57] = new Dictionary<Choice, int>()
        {
            { Choice.RED, 57},{ Choice.BLUE, 57 },{ Choice.GREEN, 57 },{ Choice.YELLOW, 57},{ Choice.PURPLE, 57},{ Choice.ORANGE, 57 },
            { Choice.TRIANGLE, 57 },{ Choice.SQUARE, 57 },{ Choice.RECTANGLE, 57},{ Choice.STAR, 57},{ Choice.HEXAGON, 57 },{ Choice.CIRCLE, 57 }
        };
    }
}
