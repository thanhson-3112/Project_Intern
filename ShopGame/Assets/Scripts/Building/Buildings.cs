using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : BaseBuilding
{
    private State state;
    private Level1RecipeSO level1RecipeSO;

    public enum State
    {
        Base,
        Level1,
        Level2,
        Level3,
    }

    [SerializeField] private Level1RecipeSO[] level1RecipeSOArray;

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
                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level1RecipeSO.output , this);

                    state = State.Level2;

                    Debug.Log(/*######*/"Upgraded Level1");
                    break;
                case State.Level2:
                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level1RecipeSO.output, this);

                    state = State.Level3;
                    Debug.Log(/*######*/"Upgraded Level2");
                    break;
                case State.Level3:
                    GetBuildingsObject().DestroyObject();

                    BuildingsObject.SpawnBuildingObject(level1RecipeSO.output, this);

                    Debug.Log(/*######*/"Upgraded Level3");
                    break;
            }
        }
    }

    public void Interact()
    {

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
}
