using UnityEngine;

public class Goals : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Puck")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }

}
