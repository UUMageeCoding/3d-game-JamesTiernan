using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector3.forward * 10f;
    }
}
