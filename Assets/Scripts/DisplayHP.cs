using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHP : MonoBehaviour
{
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = this.GetComponent<Base>().Health.ToString();
    }
}