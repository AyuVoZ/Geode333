using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_Cycle : MonoBehaviour
{
    private Light sun;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sun.transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
