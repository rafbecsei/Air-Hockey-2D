using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D mallet_blue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mallet_blue = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;
        if (pos.y >= -1f){
            pos.y = -1f;
        }
        if (pos.y <= -6.6f){
            pos.y = -6.6f;
        }
        if (pos.x <= -3.66f){
            pos.x = -3.66f;
        }
        if (pos.x >= 3.66f){
            pos.x = 3.66f;
        }
        transform.position = pos;
    }
}
