'''
- Main Camera (Camera)
- Canvas (Canvas 元件)
   - Panel (Grid Layout Group)
       - Button_0 (Button + Text)
       - Button_1 (Button + Text)
       - Button_2 (Button + Text)
       - Button_3 (Button + Text)
       - Button_4 (Button + Text)
       - Button_5 (Button + Text)
       - Button_6 (Button + Text)
       - Button_7 (Button + Text)
       - Button_8 (Button + Text)
   - RestartButton (Button + Text)
   - ResultText (Text)  // 顯示勝利結果
- EventSystem (自動生成)
- GameManager (TicTacToeManager 腳本)
script in game
'''

using UnityEngine;
using UnityEngine.UI;

public class TicTacToeManager : MonoBehaviour
{
    public Button[] buttons;
    public Text resultText;
    private string currentPlayer = "X";
    private string[] board = new string[9];

    void Start()
    {
        ResetBoard();
    }

    public void OnButtonClick(int index)
    {
        if (board[index] == "")
        {
            board[index] = currentPlayer;
            buttons[index].GetComponentInChildren<Text>().text = currentPlayer;
            buttons[index].interactable = false;

            if (CheckWinner())
            {
                resultText.text = currentPlayer + " Wins!";
            }
            else
            {
                currentPlayer = (currentPlayer == "X") ? "O" : "X";
            }
        }
    }

    private bool CheckWinner()
    {
        int[][] winConditions = {
            new int[] {0,1,2}, new int[] {3,4,5}, new int[] {6,7,8},
            new int[] {0,3,6}, new int[] {1,4,7}, new int[] {2,5,8},
            new int[] {0,4,8}, new int[] {2,4,6}
        };

        foreach (var condition in winConditions)
        {
            if (board[condition[0]] != "" &&
                board[condition[0]] == board[condition[1]] &&
                board[condition[1]] == board[condition[2]])
            {
                return true;
            }
        }
        return false;
    }

    public void ResetBoard()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            board[i] = "";
            buttons[i].GetComponentInChildren<Text>().text = "";
            buttons[i].interactable = true;
        }
        currentPlayer = "X";
        resultText.text = "Player X's Turn";
    }
}
