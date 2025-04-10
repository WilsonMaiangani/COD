using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 10f;
    public float jumpForce = 10f;
    new Rigidbody rigidbody;
    [SerializeField]
    private bool pegarItem;
    GameObject _item;
    [SerializeField]
    private bool podePular;
    [SerializeField]
    private LayerMask layerMaskChao;
    [SerializeField]
    private float maxDistanciaChao = 5f;
    [SerializeField]
    private GameObject ponto;
    // Start is called before the first frame update

    private void Awake()
    {
#if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
#endif
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentPlayer();
        PegarItem();

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // Debug.Log("aqui");
            var _ponto = Instantiate(ponto, new Vector3(transform.position.x, 0.8482f, 0f), Quaternion.identity);
            GameController.instance.CreateAviao();
            
        }
    }

    private void PegarItem()
    {
        if (pegarItem)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(_item);
                GameController.instance.EnableText(false, Vector2.zero);
            }
        }
    }

    private void FixedUpdate()
    {
        // MovimentPlayer();
    }

    void MovimentPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (rigidbody.velocity.magnitude <= 3f)
            rigidbody.AddForce(new Vector3(horizontal * velocity * Time.deltaTime, 0f, 0f));

        // rigidbody.velocity = new Vector3(horizontal * velocity, rigidbody.velocity.y, rigidbody.velocity.z);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistanciaChao, layerMaskChao))
        {
            podePular = true;
            if (Input.GetKeyDown(KeyCode.Space) && podePular)
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else podePular = false;

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.down * maxDistanciaChao);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("CarePackage"))
        {
            _item = other.gameObject;
            Vector2 posicao = new Vector2(_item.transform.position.x, _item.transform.position.y);
            pegarItem = GameController.instance.EnableText(true, posicao);
        }
    }
    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.CompareTag("CarePackage"))
        {
            _item = null;
            pegarItem = GameController.instance.EnableText(false, Vector2.zero);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 6) //ZonaMorte
            GameController.instance.Morrer();
    }
}
