using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody rb;

    // ���� ������ ����
    public GameObject coinPrefab;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
 
    }
}
