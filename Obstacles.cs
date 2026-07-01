using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 2.0f;
    Rigidbody2D rb;
    public float minspeed = 500f;
    public float maxspeed = 1000f;
    public float maxSpinSpeed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       float randomSize = Random.Range(minSize, maxSize);
       transform.localScale = new Vector3(randomSize, randomSize, 1);

       rb =GetComponent<Rigidbody2D>();

       float randomSpeed = Random.Range(minspeed, maxspeed); // Adjust speed based on size (smaller objects move faster)
       Vector2 randomDirection = Random.insideUnitCircle;
       rb.AddForce(randomDirection * randomSpeed);

       float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
       rb.AddTorque(randomTorque);

    }
   
    // Update is called once per frame
    void Update()
    {
      
    }
}
