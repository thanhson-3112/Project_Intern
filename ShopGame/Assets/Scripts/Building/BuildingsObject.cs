using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsObject : MonoBehaviour
{
    [SerializeField] private BuildingsObjectSO buildingsObjectSO;

    public BuildingsObjectSO GetBuildingsObjectSO() { return buildingsObjectSO; }

    private IBuildingsObject ibuildingsObject;

    public void SetBuildingsObject(IBuildingsObject ibuildingsObject)
    {
        if (this.ibuildingsObject != null)
        {
            this.ibuildingsObject.ClearBuildingsObject();           //Previous One
        }

        this.ibuildingsObject = ibuildingsObject;                   //New one

        if (ibuildingsObject.HasBuildingsObject())
        {
            Debug.Log("Can't!");
        }

        ibuildingsObject.SetBuildingsObject(this);

        transform.localPosition = Vector2.zero;
    }

    public void DestroyObject()
    {
        buildingsObjectSO = null;

        Destroy(gameObject);
    }

    public static BuildingsObject SpawnBuildingObject(BuildingsObjectSO buildingsObjectSO, IBuildingsObject ibuildingsObject)
    {
        Transform buildingObjectTransform = Instantiate(buildingsObjectSO.prefabs);
        BuildingsObject buildingsObject = buildingObjectTransform.GetComponent<BuildingsObject>();
        buildingsObject.SetBuildingsObject(ibuildingsObject);

        return buildingsObject;
    }
}
