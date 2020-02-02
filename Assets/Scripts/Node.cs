using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;
    private Color startColor;
    private Renderer rend;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        GameObject turretToBuild = buildManager.GetTurretToBuild();

        if (turretToBuild == null)
            return;

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        // Build turret:
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }


    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}

