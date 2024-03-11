using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour, IBuildingsObject
{
    private BuildingsObject buildingsObject;

    public BuildingsObject GetBuildingsObject() { return buildingsObject; }

    public void SetBuildingsObject(BuildingsObject buildingsObject)
    {
        this.buildingsObject = buildingsObject;
    }

    public void ClearBuildingsObject()
    {
        buildingsObject = null;
    }

    public bool HasBuildingsObject()
    {
        return buildingsObject != null;
    }
}
