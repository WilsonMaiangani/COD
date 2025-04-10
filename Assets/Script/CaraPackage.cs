using UnityEngine;

public class CaraPackage : MonoBehaviour
{
    [SerializeField]
    private float velocidadeCarePackage = 2f;

    private FixedJoint fixedJoint;
    new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.CompareTag("PontoCabecaPlayer"))

        // Destroy(other.gameObject);
        // Debug.Log("+++=> " + other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PontoCabecaPlayer"))
            GameController.instance.Morrer();
    }

    public bool LargarCaixa(GameObject caixa)
    {


        if (caixa)
        {
            fixedJoint = caixa.GetComponent<FixedJoint>();
            rigidbody = caixa.GetComponent<Rigidbody>();
            Destroy(fixedJoint);
            new WaitForSecondsRealtime(5f);
            rigidbody.drag = velocidadeCarePackage;

        }


        return true;
    }

}
