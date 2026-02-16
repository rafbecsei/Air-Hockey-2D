using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;
    GameObject thePuck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePuck = GameObject.FindGameObjectWithTag("Puck"); // Busca a referência da bola
    }
    public static void Score (string wallID) {
        if (wallID == "goal_2")
        {
            PlayerScore1++;
        } else if (wallID == "goal_1")
        {
            PlayerScore2++;
        }
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12 + 330, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12 + 330, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60 + 355, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            thePuck.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            thePuck.SendMessage("ResetPuck", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            thePuck.SendMessage("ResetPuck", null, SendMessageOptions.RequireReceiver);
        }
    }
}
