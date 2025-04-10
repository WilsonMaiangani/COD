using UnityEngine;

public class Aviao : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0f;
    private new Rigidbody rigidbody;
    [SerializeField]
    private LayerMask pontoCarePackage;
    [SerializeField]
    private float distanciaColisao = 0f;
    public CaraPackage caraPackage;
    [SerializeField]
    private bool checkedPonto;





    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (!checkedPonto)
        {

            if (Physics.Raycast(transform.position, Vector3.down, out hit, distanciaColisao, pontoCarePackage))
            {
                checkedPonto = true;

                Debug.DrawRay(transform.position, Vector3.down * distanciaColisao, Color.green);

                var _caraPackage = GameObject.FindGameObjectsWithTag("CarePackage");

                foreach (var item in _caraPackage)
                {
                    caraPackage.LargarCaixa(item);
                    // Debug.Log("Return=> " + caraPackage.LargarCaixa(item.GetComponent<FixedJoint>()));
                }
                Destroy(hit.collider.gameObject);

                Destroy(gameObject, 3f);
            }
            else
                Debug.DrawRay(transform.position, Vector3.down * distanciaColisao, Color.red);
        }
        MovimentarAviao();
    }

    public void MovimentarAviao()
    {
        // rigidbody.AddForce(new Vector3(5f * velocidade * Time.deltaTime, 0f, 0f));
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawRay(transform.position, Vector3.down * distanciaColisao);
    }



}
