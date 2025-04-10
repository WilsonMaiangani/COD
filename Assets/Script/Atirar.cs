using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject prefabBala;
    new public Transform transform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Instantiate(prefabBala, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }
}
