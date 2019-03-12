using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour {

    public Vector3 positionOffset;

    public Color hoverColor;//마우스를 댔을때의 색
    
    public Color notEnoughMoneyColor;

    public Color N_Turret;
    public Color P_Turret;
    public Color D_Turret;


    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgrade = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private Vector3 Turret_Offset;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;

        Turret_Offset.y = Turret_Offset.y + 1;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    int nColor = -1;
    //public int Init_Turret()
    //{
    //    return ;
    //}

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("You'd not enough money!");
            return;
        }

        PlayerStats.Money = PlayerStats.Money - blueprint.cost;
        nColor = Essential.instance.GetShopClicked();
      
        switch (Essential.instance.GetShopClicked())
        {
            case -1:
                startColor = N_Turret;
                break;
            case 0:
                startColor = P_Turret;
                break;
            case 1:
                startColor = D_Turret;
                break;
      
        }
        rend.material.color = startColor;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition() + Turret_Offset, Quaternion.identity);

        turret = _turret;

        turretBlueprint = blueprint;
        Debug.Log("Turret build! Money left : " + PlayerStats.Money);
    }

   

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("You'd not enough money to upgrade!");
            return;
        }

        PlayerStats.Money = PlayerStats.Money - turretBlueprint.upgradeCost;

        //이전 타워 파괴
        Destroy(turret);

        //업그레이드된 타워 설치
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition() + Turret_Offset, Quaternion.identity);

        isUpgrade = true;

        turret = _turret;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        
        Destroy(turret);
        turretBlueprint = null;
        nColor = -1;
        startColor = N_Turret;
        rend.material.color = startColor;
    }

    private void OnMouseEnter()
    {
        //nColor = 2;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void Update()
    {
        //if (nColor == -1)
        //    rend.material.color = N_Turret;
        //if (nColor == 0)
        //    rend.material.color = P_Turret;
        //if (nColor == 1)
        //    rend.material.color = D_Turret;
        //if (nColor == 2)
        //    rend.material.color = hoverColor

    
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
