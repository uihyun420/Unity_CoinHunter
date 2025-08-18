using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody rb;

    // 코인 프리팹 참조
    public GameObject coinPrefab;
    public GameObject coin;
    private bool isActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.AddCoin();
            gm.AddScore();
            Destroy(gameObject);
        }
    }

    private void Update()
    {

    }
}
