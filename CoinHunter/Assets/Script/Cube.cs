using UnityEngine;

public class Cube : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject cubePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f); // 3초 있다가 삭제
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
