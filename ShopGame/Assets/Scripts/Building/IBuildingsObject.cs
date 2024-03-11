using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingsObject
{
    public BuildingsObject GetBuildingsObject();

    public void SetBuildingsObject(BuildingsObject buildingsObject);

    public void ClearBuildingsObject();

    public bool HasBuildingsObject();
}
