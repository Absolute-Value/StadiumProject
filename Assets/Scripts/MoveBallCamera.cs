using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallCamera : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camera;
    private Vector3 offset;//カメラとの距離

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Timer", 0, 10);
    }

    void Update() {
        if (this.transform.position.y < 0) {
            CancelInvoke();
            InvokeRepeating("Timer", 0, 10);
        }
        camera.transform.position = this.transform.position + offset;
    }

    void Timer()
    {
        transform.position = new Vector3(0, 1.5f, 0);
        float force_x = -1.5f + 3 * Random.value;
        float force_y = 1.0f + 2 * Random.value;
        float force_z = 2.0f + 6 * Random.value;
        rb.velocity = Vector3.zero;
        rb.AddForce(force_x, force_y, force_z, ForceMode.Impulse);

        float nom = Mathf.Sqrt(Mathf.Pow(force_x, 2) + Mathf.Pow(force_z, 2)) + 0.0000001f;
        offset =  new Vector3(-2*force_x / nom, 0.5f, -2*force_z / nom);
        camera.transform.position = this.transform.position + offset;

        float rad = Mathf.Atan2 (force_x, force_z);
        camera.transform.rotation = Quaternion.Euler(10, rad * Mathf.Rad2Deg, 0);
    }
}
