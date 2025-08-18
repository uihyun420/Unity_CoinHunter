using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject coin;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            coin.SetActive(false);
        }
    }
    private void Update()
    {
        
    }
}
