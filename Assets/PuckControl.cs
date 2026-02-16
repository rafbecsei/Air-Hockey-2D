using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D puck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puck = GetComponent<Rigidbody2D>(); 
        Invoke("GoPuck", 2);
    }

    void GoPuck(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            puck.AddForce(new Vector2(0, 25));
        } else {
            puck.AddForce(new Vector2(0, -25));
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = puck.velocity.x;
            vel.y = (puck.velocity.y) + (coll.collider.attachedRigidbody.velocity.y);
            puck.velocity = vel;

            puck.velocity *= 1.01f;
        }
    }

    void ResetBall(){
            puck.velocity = Vector2.zero;
            transform.position = Vector2.zero;
        }

    void RestartGame(){
        ResetBall();
        Invoke("GoPuck", 1);
    }
}
