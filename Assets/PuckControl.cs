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
            puck.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        } else {
            puck.AddForce(new Vector2(0, -7), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player") || coll.collider.CompareTag("Opponent")){
            
            Rigidbody2D mallet = coll.collider.attachedRigidbody;

            if(mallet != null){
                Vector2 dir;
                if(mallet.linearVelocity.magnitude > 0.1f){
                    dir = mallet.linearVelocity.normalized;
                }
                else{
                    dir = (transform.position - coll.transform.position).normalized;
                }
                float forca = 15f;
                puck.linearVelocity = dir * forca;
            }
        }
    }

    void ResetBall(){
            puck.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
        }

    void RestartGame(){
        ResetBall();
        Invoke("GoPuck", 1);
    }
}
