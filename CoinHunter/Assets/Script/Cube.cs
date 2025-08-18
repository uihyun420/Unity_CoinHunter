using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject cubePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.Die();
        }
    }

    private void Update()
    {

    }
}
