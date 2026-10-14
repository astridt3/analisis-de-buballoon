
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private float velocidad = 9;
    [SerializeField] private float jumpHeight = 5.5f;
    public GameObject player;
    public bool flipped = false;
    public Rigidbody2D rb;
    public CharacterBehaviour characterBehaviour;
    [SerializeField] public float timesPressed = 0;
    [SerializeField] public float useLimit = 1;
    public bool isRunning = false;
    [SerializeField] public bool bubbleMode = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip jump1;
    [SerializeField] private AudioClip jump2;
    [SerializeField] private AudioClip inflate;
    [SerializeField] private AudioClip impulse1;
    [SerializeField] private AudioClip impulse2;
    private Animator anima;
    void Start()
    {
        Time.timeScale = 1;  
        rb = player.GetComponent<Rigidbody2D>();
        characterBehaviour = player.GetComponent<CharacterBehaviour>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        anima = player.GetComponent<Animator>();
        anima.SetBool("Skinny", true);
    }
    void Update()
    {
        Movement();
        checkMode();
        checkSound();
        //isFat = bubbleMode;
    }
    private void Movement()
    {
        if (player != null)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(inputHorizontal * velocidad * Time.deltaTime, 0, 0);
            player.transform.Translate(movement);

            if (inputHorizontal != 0 && characterBehaviour.isGrounded)
            {
                //anima.Play("RunningPlayer");
                //Debug.Log(isFat);
                anima.SetBool("Running", true);
                isRunning = true;
            }
            else if (inputHorizontal == 0 && characterBehaviour.isGrounded)
            {
                //anima.Play("IdlePlayer");
                //Debug.Log(isFat);
                anima.SetBool("Running", false);
                isRunning = false;
            }
            if (!characterBehaviour.isGrounded)
            {
                anima.SetBool("Jumping", true);
                anima.SetBool("Running", false);
            }


            if (inputHorizontal < 0 && flipped == false)
            {
                flipped = true;
            }
            else if (inputHorizontal > 0 && flipped == true)
            {
                flipped = false;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if(bubbleMode == false)
                {
                    bubbleMode = true;
                    timesPressed = 0;
                    anima.SetBool("Skinny", false);
                    anima.SetBool("Gording", true);
                    SoundManager.instance.PlaySound(inflate);
                }

            }

            if (Input.GetKeyDown(KeyCode.Space) )
            {
                if (bubbleMode == false && characterBehaviour.isGrounded == true)
                {
                    jumpHeight = 7;
                    anima.SetBool("Jumping", true);
                    Jump();
                    Debug.Log("salto flaco");
                    jumpSound();
                }

                if (bubbleMode == true && characterBehaviour.isGrounded)
                {
                    jumpHeight = 10;
                    anima.SetBool("Jumping", true);
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                    timesPressed++;
                    Debug.Log("salta gordito");
                    jumpSound();
                    if(characterBehaviour.isGrounded == false)
                    {
                        AudioClip selectedClip = (Random.Range(0, 2) == 0) ? impulse1 : impulse2;
                        SoundManager.instance.PlaySound(selectedClip);
                    }
                }
                characterBehaviour.isGrounded = false;

            }
            if(flipped == true)
            {
                spriteRenderer.flipX = true;
            } 
            else if (flipped == false)
            {
                spriteRenderer.flipX = false;
            }
        }
    }


    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    private void checkMode()
    {
        if (bubbleMode == true)
        { 
            rb.gravityScale = 0.6f;
        } else
        {
            rb.gravityScale = 1;
        }
        if (timesPressed >= useLimit)
        {
   
        }
    }

    private void jumpSound()
    {
        AudioClip selectedClip = (Random.Range(0, 2) == 0) ? jump1 : jump2;
        SoundManager.instance.PlaySound(selectedClip);
    }


    private void checkSound()
    {
        //while (isRunning == true)
        //{
        //    AudioClip selectedClip = (Random.Range(0, 2) == 0) ? step1 : step2;
        //    SoundManager.instance.PlaySound(selectedClip);
        //}
    }

}
