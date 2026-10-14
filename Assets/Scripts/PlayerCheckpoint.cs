//using UnityEngine;

//public class PlayerCheckpoint : MonoBehaviour
//{
//    private Vector2 lastCheckpoint;

//    private void Start()
//    {
//        lastCheckpoint = transform.position;
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            lastCheckpoint = transform.position;
//        }
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Lava"))
//        {
//            transform.position = lastCheckpoint + Vector2.up * 0.5f;
//        }
//    }
//}
