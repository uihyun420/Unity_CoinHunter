using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody rb;

    // ���� ������ ����
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
            Player player = other.GetComponent<Player>();
            Destroy(gameObject); 
            player.AddCoin(1);
        }
    }

    private void Update()
    {
    }
}
