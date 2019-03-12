using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    /*
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    */
    private TurretBlueprint turretToBuild;

    private House selectNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    

    /*
    private void Start()
    {
        Make_Button = Build_Prefab;
        Make_Button2 = Cencel_Prefab;
        turretToBuild = standardTurretPrefab;
    }
    
    private GameObject Make_Button;
    private GameObject Make_Button2;
        
    public GameObject Build_Prefab;
    public GameObject Cencel_Prefab;
    */
    
    public void SelectNode(House node)
    {
        if (selectNode == node)
        {
            DeselectNode();
            return;
        }

        selectNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectNode = null;

        nodeUI.Hide();
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectNode = null;

        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
