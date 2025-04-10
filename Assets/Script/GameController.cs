using System.Collections;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    GameObject player;
    public GameObject playerPrefab;
    public GameObject aviaoPrefab;
    public GameObject carePackagePrefab;

    public TMPro.TextMeshProUGUI[] ListTextMesh;
    private RectTransform[] rectTransform;
    private string statePlayer = "start";
    // [SerializeField]
    // private bool ChamarAviao;

    private void Awake()
    {
        // StartCoroutine(CreatePlayer());
    }
    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        EnableText(false, Vector2.zero);

        // StartCoroutine(CreatePlayer());
        // InvokeRepeating("CreatePlayer2", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(CreatePlayer());
        CreatePlayerStart();

        // if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     // ChamarAviao = true;
        //     CreateAviao();
        // }

    }
    public void Morrer()
    {
        Destroy(player);
        statePlayer = "dead";
        EnableText(true, ListTextMesh.Length - 1);
    }

    private IEnumerator CreatePlayer()
    {
        var position = Random.Range(-7, 7);

        if (statePlayer.Equals("start"))
        {
            player = Instantiate(playerPrefab, new Vector3(position, 1.81f, 0f), Quaternion.identity);
            statePlayer = string.Empty;
        }
        else if (statePlayer.Equals("dead"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EnableText(false, Vector2.zero);
                player = Instantiate(playerPrefab, new Vector3(position, 1.81f, 0f), Quaternion.identity);
                statePlayer = string.Empty;
            }
        }
        else if (!statePlayer.Equals("start") && !statePlayer.Equals("dead"))
        {
            Debug.Log($"State => {statePlayer} invalido");
        }

        yield return new WaitForSecondsRealtime(1f);

        // yield return CreatePlayer();
        StopCoroutine(CreatePlayer());

    }

    private void CreatePlayerStart()
    {
        var position = Random.Range(-7, 7);

        if (statePlayer.Equals("start"))
        {
            int a = 1 << 8;
            a = ~a;
            // Debug.Log("a=> " + transform.TransformDirection(Vector3.forward));
            player = Instantiate(playerPrefab, new Vector3(-6.57f, 1.81f, 0f), Quaternion.identity);
            statePlayer = string.Empty;
        }
        else if (statePlayer.Equals("dead"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EnableText(false, Vector2.zero);
                player = Instantiate(playerPrefab, new Vector3(position, 1.81f, 0f), Quaternion.identity);
                statePlayer = string.Empty;
            }
        }
    }

    public void CreateAviao()
    {

        var _aviao = Instantiate(aviaoPrefab, new Vector3(-10f, 7.32f, 0f), Quaternion.identity);
        var _rigidbodyAviao = _aviao.GetComponent<Rigidbody>();

        var _carePackage = Instantiate(carePackagePrefab, new Vector3(-10f, 6.8f, 0f), Quaternion.identity);
        // _carePackage.AddComponent<FixedJoint>().connectedBody = _rigidbodyAviao;
        _carePackage.GetComponent<FixedJoint>().connectedBody = _rigidbodyAviao;
        

    }

    public bool EnableText(bool value, Vector2 posicao)
    {
        foreach (var (index, textMesh) in ListTextMesh.Select((textMesh, index) => (index, textMesh)))
        {
            // textMesh.transform = new Vector3(new float)
            textMesh.enabled = value;

            // rectTransform[index].anchoredPosition = posicao;

        }

        return value;
    }
    public bool EnableText(bool value, int index)
    {
        ListTextMesh[index].enabled = value;

        return value;
    }
}
