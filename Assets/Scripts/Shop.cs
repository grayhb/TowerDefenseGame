using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurret()
    {
        Debug.Log("Выбрана стандартная туррель");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Выбрана другая туррель");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
