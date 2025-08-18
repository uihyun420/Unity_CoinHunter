using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(h, 0f, v);
        if (velocity.magnitude > 1f)
        {
            velocity.Normalize();
        }
        velocity *= Speed;
        body.linearVelocity = velocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
