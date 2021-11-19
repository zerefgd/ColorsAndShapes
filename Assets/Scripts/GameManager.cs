using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool canClick, hasGameFinished;
    Choice playerChoice;
    string gameState;

    //Constants need to be used
    readonly List<string> cardChoice = new List<string>() { Constants.ROLL_SHAPE, Constants.ROLL_SHAPE, Constants.ROLL_SHAPE, Constants.ROLL_SHAPE, Constants.ROLL_SHAPE,
                                                   Constants.ROLL_SHAPE,
                                                   Constants.ROLL_COLOR, Constants.ROLL_COLOR, Constants.ROLL_COLOR, Constants.ROLL_COLOR, Constants.ROLL_COLOR,
                                                   Constants.ROLL_COLOR,
                                                   Constants.MOVE_FORWARD,Constants.MOVE_FORWARD,Constants.MOVE_BACK};

    readonly List<Choice> shapes = new List<Choice>() { Choice.TRIANGLE, Choice.RECTANGLE, Choice.SQUARE, Choice.STAR, Choice.HEXAGON, Choice.CIRCLE };
    readonly List<Choice> colors = new List<Choice>() { Choice.RED, Choice.BLUE, Choice.GREEN, Choice.YELLOW, Choice.PURPLE, Choice.ORANGE };

    List<Player> players;
    int currentPlayer;
    Dictionary<Player, GameObject> pieces;

    [SerializeField]
    GameObject gamePiece;

    [SerializeField]
    Vector3 startPos;

    Board myboard;

    public readonly List<Vector3> indexToVector = new List<Vector3>()
    {
        new Vector3(-2.005f,2.415f,-1f),new Vector3(-1.57f,2.415f,-1f),new Vector3(-1.135f,2.415f,-1f),new Vector3(-0.7f,2.415f,-1f),
        new Vector3(-0.265f,2.415f,-1f),new Vector3(-0.265f,1.98f,-1f),new Vector3(-0.265f,1.545f,-1f),new Vector3(0.19f,1.545f,-1f),
        new Vector3(0.625f,1.545f,-1f),new Vector3(1.06f,1.545f,-1f),new Vector3(1.5f,1.545f,-1f),new Vector3(1.95f,1.545f,-1f),
        new Vector3(1.95f,1.1f,-1f), new Vector3(1.95f,0.655f,-1f), new Vector3(1.95f,0.225f,-1f), new Vector3(1.515f,0.225f,-1f),
        new Vector3(1.08f,0.225f,-1f),new Vector3(0.645f,0.225f,-1f),new Vector3(0.645f,0.65f,-1f),new Vector3(0.21f,0.65f,-1f),
        new Vector3(-0.235f,0.65f,-1f),new Vector3(-0.675f,0.65f,-1f),new Vector3(-1.115f,0.65f,-1f),new Vector3(-1.115f,1.095f,-1f),
        new Vector3(-1.55f,1.095f,-1f),new Vector3(-1.985f,1.095f,-1f),new Vector3(-1.985f,0.66f,-1f),new Vector3(-1.985f,0.225f,-1f),
        new Vector3(-1.985f,-0.21f,-1f),new Vector3(-1.985f,-0.645f,-1f),new Vector3(-1.55f,-0.645f,-1f),new Vector3(-1.115f,-0.645f,-1f),
        new Vector3(-0.68f,-0.645f,-1f),new Vector3(-0.245f,-0.645f,-1f),new Vector3(0.19f,-0.645f,-1f),new Vector3(0.625f,-0.645f,-1f),
        new Vector3(1.08f,-0.645f,-1f),new Vector3(1.515f,-0.645f,-1f),new Vector3(1.95f,-0.645f,-1f),new Vector3(1.95f,-1.08f,-1f),
        new Vector3(1.95f,-1.515f,-1f),new Vector3(1.515f,-1.515f,-1f),new Vector3(1.08f,-1.515f,-1f),new Vector3(0.645f,-1.515f,-1f),
        new Vector3(0.21f,-1.515f,-1f),new Vector3(-0.225f,-1.515f,-1f),new Vector3(-0.66f,-1.515f,-1f),new Vector3(-1.095f,-1.515f,-1f),
        new Vector3(-1.54f,-1.515f,-1f),new Vector3(-1.975f,-1.515f,-1f),new Vector3(-1.975f,-1.95f,-1f),new Vector3(-1.975f,-2.385f,-1f),
        new Vector3(-1.54f,-2.385f,-1f),new Vector3(-1.105f,-2.385f,-1f),new Vector3(-0.67f,-2.385f,-1f),new Vector3(-0.235f,-2.385f,-1f),
        new Vector3(0.2f,-2.385f,-1f),new Vector3(1.2f,-2.385f,-1f),
    };

    public delegate void UpdateMessage(Player player);

    public event UpdateMessage message;

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        canClick = true;
        hasGameFinished = false;
        gameState = Constants.ROLL_CARD;
        players = new List<Player>();
        currentPlayer = 0;
        pieces = new Dictionary<Player, GameObject>();
        myboard = new Board();

        for (int i = 0; i < 6; i++)
        {
            players.Add((Player)i);
            GameObject currentPiece = Instantiate(gamePiece);
            currentPiece.name = i.ToString();
            currentPiece.transform.position = startPos;
            currentPiece.GetComponent<Piece>().SetColor((Player)i);
            pieces[(Player)i] = currentPiece;
        }

    }

    private void Update()
    {
        if (!canClick || hasGameFinished) return;
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (!hit.collider) return;

            if(hit.collider.CompareTag("Card"))
            {
                switch(gameState)
                {
                    case Constants.ROLL_CARD:
                        canClick = false;
                        gameState = cardChoice[Random.Range(0, cardChoice.Count)];
                        hit.collider.gameObject.GetComponent<Card>().RollCard(gameState);
                        Debug.Log("Rolling Card");
                        break;
                    case Constants.ROLL_COLOR:
                        canClick = false;
                        playerChoice = colors[Random.Range(0, colors.Count)];
                        hit.collider.gameObject.GetComponent<Card>().RollColor(playerChoice);
                        Debug.Log("Rolling COlor");
                        //gameState = Constants.ROLL_CARD;                        
                        break;
                    case Constants.ROLL_SHAPE:
                        canClick = false;
                        playerChoice = shapes[Random.Range(0, shapes.Count)];
                        hit.collider.gameObject.GetComponent<Card>().RollShape(playerChoice);
                        Debug.Log("Rolling Shape");
                        //gameState = Constants.ROLL_CARD;
                        break;
                    case Constants.MOVE_FORWARD:
                        canClick = false;
                        MovePlayer(2);
                        //gameState = Constants.ROLL_CARD;
                        break;
                    case Constants.MOVE_BACK:
                        canClick = false;
                        //gameState = Constants.ROLL_CARD;
                        MovePlayer(-1);
                        break;
                    default:
                        canClick = true;
                        return;
                }
            }
        }
    }

    public void MovePlayer()
    {
        List<int> result = myboard.UpdatePos(players[currentPlayer], playerChoice);
        gameState = Constants.ROLL_CARD;
        pieces[players[currentPlayer]].GetComponent<Piece>().SetPos(result);
        CheckSwap(result.Count > 0 ? result[result.Count - 1] : 0);
        Debug.Log("Moving Player");
        canClick = true;
        if(result.Count > 0 && result[result.Count - 1] == 57)
        {
            players.RemoveAt(currentPlayer);
            currentPlayer %= players.Count;
            if (players.Count == 1) hasGameFinished = true;
            Debug.Log("Message Called");
            message(players[currentPlayer]);
            return;
        }
        currentPlayer++; currentPlayer %= players.Count;
        Debug.Log("Message Called");
        message(players[currentPlayer]);
    }

    public void MovePlayer(int diff)
    {
        List<int> result = myboard.UpdatePos(players[currentPlayer], diff);
        gameState = Constants.ROLL_CARD;
        pieces[players[currentPlayer]].GetComponent<Piece>().SetPos(result);
        CheckSwap(result.Count > 0 ? result[result.Count - 1] : 0);
        Debug.Log("Moving forward");
        canClick = true;
        if (result.Count > 0 && result[result.Count - 1] == 57)
        {
            players.RemoveAt(currentPlayer);
            currentPlayer %= players.Count;
            if (players.Count == 1) hasGameFinished = true;
            message(players[currentPlayer]);
            return;
        }
        currentPlayer++; currentPlayer %= players.Count;
        message(players[currentPlayer]);
    }

    void CheckSwap(int lastPos)
    {
        if (lastPos != 20) return;
        List<Player> result = myboard.UpdateSwap(players[currentPlayer]);
        if (result.Count == 0) return;
        pieces[players[currentPlayer]].GetComponent<Piece>().SetPos(new List<int>() { 43 },true);
        foreach(Player player in result)
        {
            pieces[player].GetComponent<Piece>().SetPos(new List<int>() { 20 }, true);
        }
    }
}
