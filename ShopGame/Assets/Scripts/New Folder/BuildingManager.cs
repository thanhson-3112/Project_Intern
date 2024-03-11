using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpgradeManager : MonoBehaviour
{
    Building[] Buildings;

    [SerializeField] private Button increaseBuildingCountButton;
    [SerializeField] private int buildingCount = 1;

    [SerializeField] GameObject upgradeHorizontalLayout;
    [SerializeField] GameObject upgrade_prefab;
    

    public void Start()
    {
        Buildings = new Building[]
        {
        /*new Upgrade{Name = "Attack Speed", Description = "Attack Speed +2", Ratity = "Common",  Increase = 10, Sprite = Resources.Load<Sprite>("Upgrade_Card/Attack_Speed")},
        new Upgrade{Name = "Attack Damage", Description = "Attack Damage +2", Ratity = "Common", Increase = 20, Sprite = Resources.Load<Sprite>("Upgrade_Card/Attack_Damage")},
        new Upgrade{Name = "Attack Damage 2", Description = "Attack Damage +5", Ratity = "Rare",  Increase = 20, Sprite = Resources.Load<Sprite>("Upgrade_Card/Attack_Damage")},
        new Upgrade{Name = "Dash Force", Description = "Dash Force +2", Ratity = "Rare",  Increase = 20, Sprite = Resources.Load<Sprite>("Upgrade_Card/Dash_Force")},
        new Upgrade{Name = "Dash Force 2", Description = "Dash Force +5", Ratity = "Epic",  Increase = 20, Sprite = Resources.Load<Sprite>("Upgrade_Card/Dash_Force")}
*/
        };
        increaseBuildingCountButton.onClick.AddListener(IncreaseBuildingCount);
        ButtonsSet();

    }

    private void IncreaseBuildingCount()
    {
        // T?ng giá tr? c?a buildingCount khi button ???c nh?n
        buildingCount++;
        // G?i l?i hàm ButtonsSet() ?? c?p nh?t giao di?n d?a trên buildingCount m?i
        ButtonsSet();
    }


    public void ButtonsSet()
    {
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < Buildings.Length; i++)
        {
            availableUpgrades.Add(i);
        }
        ShuffleList(availableUpgrades);

        while (upgradeHorizontalLayout.transform.childCount < buildingCount)
        {
            Instantiate(upgrade_prefab, upgradeHorizontalLayout.transform);
        }

        /*Dictionary<string, Color> rarityColors = new Dictionary<string, Color>();
        rarityColors.Add("Common", new Color(1, 1, 1, 1));
        rarityColors.Add("Rare", new Color(0.5f, 1, 0.5f, 1));
        rarityColors.Add("Epic", new Color(0.75f, 0.25f, 0.75f, 1));*/

        for (int i = 0; i < buildingCount; i++)
        {
           Building building = Buildings[availableUpgrades[i]];

            GameObject buildingObject = upgradeHorizontalLayout.transform.GetChild(i).gameObject;
            /*Button upgradeButton = upgradeObject.GetComponent<Button>();
            upgradeButton.onClick.AddListener(() => { UpgradeChosen(upgrade.Name); });

            TextMeshProUGUI upgradeTextName = upgradeObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            upgradeTextName.text = upgrade.Name;

            TextMeshProUGUI upgradeTextDescription = upgradeObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
            upgradeTextDescription.text = upgrade.Description;

            *//*upgradeObject.transform.GetChild(1).GetComponent<Image>().color = rarityColors[upgrade.Ratity];*//*
            upgradeObject.transform.GetChild(2).GetComponent<Image>().sprite = upgrade.Sprite;*/
        }
    }

    private void UpgradeChosen(string upgradeChosen)
    {
        /*Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);


        switch (upgradeChosen)
        {
            case "Attack Speed":
                Debug.Log("Attack Speed");
                playerAttackSpeed.UpgradeAttackSpeed();
                break;
            case "Attack Damage":
                Debug.Log("Attack Damage");
                fireBallDamage.PlayerDamageUpgrade();
                break;
            case "Attack Damage 2":
                Debug.Log("Attack Damage 2");
                fireBallDamage.PlayerDamageUpgrade();
                break;
            case "Dash Force":
                Debug.Log("Dash Force");
                playerMovement.DashUpgrade();
                break;
            case "Dash Force 2":
                Debug.Log("Dash Force 2");
                playerMovement.DashUpgrade();
                break;
        }*/
    }

    private void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public class Building
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ratity { get; set; }
        public float Increase { get; set; }
        public Sprite Sprite { get; set; }
    }
}
