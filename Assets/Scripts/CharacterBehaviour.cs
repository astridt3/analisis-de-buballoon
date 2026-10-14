using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public bool isGrounded = true;

    public HealthManager healthManager;
    public MovementManager movementManager;
    public SoundManager soundManager;
    public GameObject player;
    public float checkPoint = 0;
    public Rigidbody2D rb;
    [SerializeField] private float impulse;
    [SerializeField] private AudioClip victory;
    [SerializeField] private AudioClip action1;
    [SerializeField] private AudioClip action2;
    public Vector3 lastGroundPosition;
    private Animator anima;
    public GameObject victoria;
    [SerializeField]
    private float Up = 200;
    public Vector3 checkpointPosition;
    private bool firstCheckpointSet = false;

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        movementManager = GetComponent<MovementManager>();
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        AudioClip selectedClip = (Random.Range(0, 2) == 0) ? action1 : action2;
        //checkpointPosition = Vector3.zero;
        lastGroundPosition = transform.position;
        checkpointPosition = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud"))
        {
            Debug.Log("colision");
            isGrounded = true;
            anima.SetBool("Jumping", false);
            lastGroundPosition = transform.position;

            //if (!firstCheckpointSet)
            //{
            //    //checkpointPosition = new GameObject("FirstCheckpoint");
            //    checkpointPosition.transform.position = transform.position;
            //    firstCheckpointSet = true;
            //}

            if (movementManager.bubbleMode && isGrounded)
            {
                
                if (movementManager.timesPressed >= movementManager.useLimit)
                {
                    anima.SetBool("Gording", false);
                    anima.SetBool("Skinny", true);
                    movementManager.bubbleMode = false;
                    Debug.Log("salio de bubblemode por colision");
                }

                movementManager.timesPressed = 0; 
            }
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            healthManager.TakeDamage(1, false);
            impulse = 5;
            Vector2 direccion = (transform.position - collision.transform.position).normalized;
            rb.AddForce(direccion * impulse, ForceMode2D.Impulse);
            //if (rb != null)
            //{
            //    rb.velocity = Vector2.zero;
            //    impulse = 7;
            //}
            //impulse = 10;
        }
        
        if (collision.gameObject.CompareTag("Bubble"))
        {
            healthManager.TakeDamage(1, false);
            Vector2 direccion = Vector2.up;
            isGrounded = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(direccion * impulse, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Exit"))
        {
            Time.timeScale = 0;
            victoria.SetActive(true);
            SoundManager.instance.PlaySound(victory);

            firstCheckpointSet = false;
        }
        //        if(!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Cloud"))
        //{
        //            anima.SetBool("Jumping", true);
        //        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud"))
        {
            isGrounded = true;
            anima.SetBool("Jumping", false);
            if (movementManager.bubbleMode)
            {
                movementManager.bubbleMode = false;
                anima.SetBool("Gording", false);
                anima.SetBool("Skinny", true);
                Debug.Log("Modo gordo desactivado al aterrizar");
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud"))
        {
            isGrounded = false;
            //anima.SetBool("Jumping", true);
            //anima.SetBool("Running", false);
            //anima.SetBool("Idle", false);
            //anima.SetBool("Gording", false);
            //anima.SetBool("Skinny", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            healthManager.TakeDamage(1, true);
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            SetCheckpoint(collision.gameObject);
        }
    }
    public void ResetPhysicsWithDelay(Vector3 respawnPosition)
    {
        StartCoroutine(ResetPhysicsCoroutine(respawnPosition));
    }

    private IEnumerator ResetPhysicsCoroutine(Vector3 respawnPosition)
    {
        rb.simulated = false;
        transform.position = respawnPosition;
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = true;
        isGrounded = false;
    }
    public void RespawnAtCheckpoint()
    {
        transform.position = checkpointPosition + Vector3.up * 0.5f;
        ResetPhysicsWithDelay(checkpointPosition);
    }
    public void RespawnAtLastGround()
    {
        transform.position = lastGroundPosition + Vector3.up * 0.5f;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }
    public void SetCheckpoint(GameObject newCheckpoint)
    {
        checkpointPosition = newCheckpoint.transform.position;
    }
}


