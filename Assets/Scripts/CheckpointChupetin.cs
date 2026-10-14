//using UnityEngine;

//public class CheckpointChupetin : MonoBehaviour
//{
//    private bool activated = false;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (!activated && collision.CompareTag("Player"))
//        {
//            CharacterBehaviour character = collision.GetComponent<CharacterBehaviour>();
//            if (character != null)
//            {
//                character.SetCheckpoint(transform.position);
//                character.healthManager.respawnCount = 0;
//                character.healthManager.currentHealth = 3;
//                character.healthManager.heartManager.UpdateHeartUI(3);
//                activated = true;
//                Debug.Log("Checkpoint activado");
//            }
//        }
//    }
//}
