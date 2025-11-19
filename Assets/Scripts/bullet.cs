using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] GameObject impactfx;
    [SerializeField] public float speed;
    [SerializeField] public int damage;
    Rigidbody rb;
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
            rb.AddForce(gameObject.transform.forward * speed);
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
