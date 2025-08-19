using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public int coinCount = 0;
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

    public void AddCoin(int count)
    {
        coinCount += count;
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameObject findGo = GameObject.FindWithTag("GameController");
        var gm = findGo.GetComponent<GameManager>();
        gm.EndGame();
    }
}
