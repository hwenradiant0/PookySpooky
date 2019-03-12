using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint laserbeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        Essential.instance.SetShopClicked(0);
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        Essential.instance.SetShopClicked(1);
        buildManager.SelectTurretToBuild(laserbeamer);
    }
}
