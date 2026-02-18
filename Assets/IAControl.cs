using UnityEngine;

public class IAControl : MonoBehaviour
{
    public Transform puck;
    public float velocidade = 10f;
    public float defendY = 6f;
    public float meiodaquadra = 0f;
    public float reacao = 0.2f;
    
    
    private float timer = 0f;
    private Rigidbody2D rb;
    private Vector2 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= reacao){
            timer = 0f;

            if(puck.position.y > meiodaquadra) {
                target = puck.position;
                float erro = Random.Range(-0.5f, 0.5f);
                target.x += erro;
            }
            else{
                target = new Vector2(puck.position.x, defendY);
            }
        }
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, velocidade * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}
