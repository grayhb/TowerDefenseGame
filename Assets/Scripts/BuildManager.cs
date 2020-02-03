using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }


    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurrenOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enogh money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        node.turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    }
}
