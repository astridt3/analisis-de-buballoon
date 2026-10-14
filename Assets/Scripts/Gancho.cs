using UnityEngine;

public class Gancho : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public float climbSpeed = 1.0f;
    private CharacterBehaviour characterBehaviour;

    [SerializeField] private GameObject brazo;
    [SerializeField] private AudioClip grapple1;

    private bool isClimbing = false;
    private Vector2 targetPoint;

    void Start()
    {
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
        characterBehaviour = GetComponent<CharacterBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, 10);

            Transform closest = null;
            float minDist = Mathf.Infinity;

            foreach (var obj in objetos)
            {
                if (obj.CompareTag("Baston"))
                {
                    float bastonRadio = 10f;
                    float dist = Vector2.Distance(transform.position, obj.transform.position);
                    if (dist < bastonRadio && dist < minDist)
                    {
                        minDist = dist;
                        closest = obj.transform;
                    }
                }
            }

            if (closest != null)
            {
                targetPoint = closest.position;
                _lineRenderer.SetPosition(0, targetPoint);
                _lineRenderer.SetPosition(1, brazo.transform.position);

                _distanceJoint.connectedAnchor = targetPoint;
                _distanceJoint.enabled = true;
                _lineRenderer.enabled = true;
                isClimbing = false;

                _distanceJoint.autoConfigureDistance = false;
                _distanceJoint.distance = Vector2.Distance(transform.position, targetPoint);
                _distanceJoint.enableCollision = true;
            }
        }


        else if (Input.GetKeyUp(KeyCode.Q))
        {
            characterBehaviour.rb.velocity = Vector2.zero;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            isClimbing = false;
            
        }


        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(0, _distanceJoint.connectedAnchor);
            _lineRenderer.SetPosition(1, brazo.transform.position);


            if (_distanceJoint.distance > 0.001f)
            {
                if (!isClimbing)
                {
                    SoundManager.audioSource.volume = 0.1f;
                    SoundManager.instance.PlaySound(grapple1);
                    isClimbing = true;
                }

                Vector2 targetPosition = _distanceJoint.connectedAnchor;
                //transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * climbSpeed);
            }
        }
    }
}