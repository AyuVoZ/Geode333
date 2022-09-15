using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    public int wood;
    public int stone;
    public int gold;

    void Start()
    {
        wood = 0;
        stone = 0;
        gold = 0;
    }

    public void AddWood(){
        wood++;
    }

    public void AddStone(){
        stone++;
    }

    public void AddGold()
    {
        Debug.Log("GOLD");
        gold++;
    }

    public void PayWood(int pay){
        if(pay<=wood){
            wood-=pay;
        }
    }
    public void PayStone(int pay){
        if(pay<=stone){
            stone-=pay;
        }
    }
    public void PayGold(int pay){
        if(pay<=gold){
            gold-=pay;
        }
    }
}
