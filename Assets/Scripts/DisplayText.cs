using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
   public Text text;
   public bool stone;
 
   public void Update()
   {
    if(stone){
        text.text = this.GetComponent<RessourceManager>().stone.ToString();
    }
    else
    {
        text.text = this.GetComponent<RessourceManager>().wood.ToString();
    }
   }
}
