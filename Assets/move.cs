using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody rb;
    GameObject center;
    public GameObject Indicator;
    public GameObject Indicator2;
    public float speed = 10;
    bool hasPower = false;
    public float force = 15;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        center = GameObject.Find("center");
    }

    // Update is called once per frame
    void Update()
    {
        float value = Input.GetAxis("Vertical");
        Debug.Log(value);
        rb.AddForce(center.transform.forward * value * speed );
        Indicator.gameObject.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        Indicator2.gameObject.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }
    private void OnCollisionEnter(Collision col)

    {
        if(col.gameObject.CompareTag("enemy") && hasPower)
        {

            Rigidbody enbody = col.gameObject.GetComponent<Rigidbody>();
            enbody.AddForce((col.gameObject.transform.position - transform.position)*force, ForceMode.Impulse);
        }
        if ( col.gameObject.CompareTag("food"))
        {
            hasPower = true;
            Indicator.gameObject.SetActive(true);
            Indicator2.gameObject.SetActive(true);
            Destroy(col.gameObject);
        }
    }


}
