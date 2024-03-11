using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseBuilding
{
    private State state;
    private Level1RecipeSO level1RecipeSO;
    private Level2RecipeSO level2RecipeSO;
    private Level3RecipeSO level3RecipeSO;

    public enum State
    {
        Base,
        Level1,
        Level2,
        Level3,
    }

    [SerializeField] private Level1RecipeSO[] level1RecipeSOArray;
    [SerializeField] private Level2RecipeSO[] level2RecipeSOArray;
    [SerializeField] private Level3RecipeSO[] level3RecipeSOArray;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Base;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasBuildingsObject())
        {
            switch (state)
            {
                case State.Base:

                    break;
                case State.Level1:
                    level1RecipeSO = Level1RecipeSOWithInput(GetBuildingsObject().GetBuildingsObjectSO());

                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level1RecipeSO.output , this);

                    state = State.Level2;

                    Debug.Log(/*######*/"Upgraded Level1");
                    break;
                case State.Level2:
                    level2RecipeSO = Level2RecipeSOWithInput(GetBuildingsObject().GetBuildingsObjectSO());

                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level2RecipeSO.output, this);

                    state = State.Level3;
                    Debug.Log(/*######*/"Upgraded Level2");
                    break;
                case State.Level3:
                    level3RecipeSO = Level3RecipeSOWithInput(GetBuildingsObject().GetBuildingsObjectSO());

                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level3RecipeSO.output, this);

                    Debug.Log(/*######*/"Upgraded Level3");
                    break;
            }
        }
    }

    private Level1RecipeSO Level1RecipeSOWithInput (BuildingsObjectSO inputBuildingsObjectSO)
    {
        foreach (Level1RecipeSO level1RecipeSO in level1RecipeSOArray)
        {
            if (level1RecipeSO.input == inputBuildingsObjectSO)
            {
                return level1RecipeSO;
            }
        }
        return null;
    }

    private Level2RecipeSO Level2RecipeSOWithInput(BuildingsObjectSO inputBuildingsObjectSO)
    {
        foreach (Level2RecipeSO level2RecipeSO in level2RecipeSOArray)
        {
            if (level2RecipeSO.input == inputBuildingsObjectSO)
            {
                return level2RecipeSO;
            }
        }
        return null;
    }

    private Level3RecipeSO Level3RecipeSOWithInput(BuildingsObjectSO inputBuildingsObjectSO)
    {
        foreach (Level3RecipeSO level3RecipeSO in level3RecipeSOArray)
        {
            if (level3RecipeSO.input == inputBuildingsObjectSO)
            {
                return level3RecipeSO;
            }
        }
        return null;
    }
}
