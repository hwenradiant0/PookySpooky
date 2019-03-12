using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essential : MonoBehaviour {

    static public Essential instance;

     int ShopClicked=-1;//안눌렸을 때, 타워종료
    // Use this for initialization
    void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetShopClicked(int nTower)
    {
        ShopClicked = nTower;
    }

    public int GetShopClicked()
    {
        return ShopClicked;
    }
}
