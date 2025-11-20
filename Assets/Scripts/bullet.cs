using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] GameObject impactfx;
    [SerializeField] public float speed;
    [SerializeField] float drag;
    [SerializeField] public int damage;
    Rigidbody rb;
    float gravity;
    bool hit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.rotation = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            rb.angularVelocity += gameObject.transform.forward * speed * 0.5f;
            rb.linearVelocity += gameObject.transform.forward * speed;
            if (speed > 0)
            {
                speed -= drag * Time.deltaTime;
            }
            else
            {
                speed = 0;
            }
            
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactfx,transform.position,transform.rotation);
        hit = true;
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        Invoke("DestroySelf",5f);
    }
}
