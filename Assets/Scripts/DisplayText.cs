using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
   public Text woodText;
   public Text stoneText;
   public Text goldText;
 
   public void Update()
   {
        stoneText.text = this.GetComponent<RessourceManager>().stone.ToString();
        woodText.text = this.GetComponent<RessourceManager>().wood.ToString();
        goldText.text = this.GetComponent<RessourceManager>().gold.ToString();
   }
}
