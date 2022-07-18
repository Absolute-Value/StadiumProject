using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    public GameObject mark;
    private float z, addZ, alpha, beta;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        InvokeRepeating("Timer", 0, 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        z += addZ;
        addZ *= 0.999f;
        this.transform.position = new Vector3(beta * z - 0.25f, -1 * alpha * z * z + 1.75f, -18 * z + 18.5f);
        if (this.transform.position.z > 0.25f) {
            mark.transform.position = new Vector3(beta * z - 0.25f, (0.5f - alpha) * z * z + 1.25f, 0.25f);
        }
    }

    void Timer() {
        z = 0;
        alpha = 1 + 0.2f * Mathf.Sqrt(-2.0f * Mathf.Log(Random.value)) * Mathf.Sin(2.0f * Mathf.PI * Random.value);
        beta = 0.2f * Mathf.Sqrt(-2.0f * Mathf.Log(Random.value)) * Mathf.Cos(2.0f * Mathf.PI * Random.value) + 0.25f;
        addZ = getAdd(alpha);
        this.transform.position = new Vector3(-0.25f, 1.75f, 18.5f);
        mark.transform.position = new Vector3(-0.25f, 1.75f, 0.25f);
    }

    float getAdd(float _alpha) {
        float velo;
        if (alpha > 1.2f) {
            velo = 105 + 15 * Random.value;
        } else if (alpha < 0.8f) {
            velo = 140 + 15 * Random.value;
        } else {
            velo = 120 + 20 * Random.value;
        }
        float take = 18.4f / (velo * 1000 / 3600);
        return 0.02f / take;
    }
}
