using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    public Upgrade[] upgrades;
    public GameObject upgradeBlockPrefab;
    public Transform contentArea;
    public int currentFortynium;

    void Start()
    {
        InitializeUpgrades();
        PopulateUpgradeMenu();
    }

    void InitializeUpgrades()
    {
        upgrades = new Upgrade[]
        {
            new Upgrade("Solar Panel", "Generates energy.", 50, "+1 Energy/Step"),
            new Upgrade("Hydroponic Farm", "Increases food production.", 100, "+2 Food/Step"),
            new Upgrade("Oxygen Generator", "Increases oxygen production.", 75, "+1 Oxygen/Step"),
            new Upgrade("Fortynium Extractor", "Extracts Fortynium efficiently.", 150, "+5 Fortynium/Step"),
			new Upgrade("Recycling Plant", "Recycles waste materials.", 200, "+2 Fortynium/Step"),
			new Upgrade("Greenhouse", "Increases food production.", 150, "+3 Food/Step"),
			new Upgrade("Water Purifier", "Increases water production.", 100, "+2 Water/Step"),
			new Upgrade("Oxygen Scrubber", "Increases oxygen production.", 125, "+2 Oxygen/Step"),
			new Upgrade("Fortynium Refinery", "Refines Fortynium efficiently.", 250, "+10 Fortynium/Step"),
			new Upgrade("Compost Bin", "Increases food production.", 175, "+4 Food/Step"),
			new Upgrade("Water Reclaimer", "Increases water production.", 125, "+3 Water/Step"),
			new Upgrade("Oxygen Recycler", "Increases oxygen production.", 150, "+3 Oxygen/Step"),
			new Upgrade("Fortynium Smelter", "Smelts Fortynium efficiently.", 300, "+15 Fortynium/Step"),
			new Upgrade("Hydroponic Dome", "Increases food production.", 200, "+5 Food/Step"),
			new Upgrade("Water Treatment Plant", "Increases water production.", 150, "+4 Water/Step"),
			new Upgrade("Oxygen Generator Array", "Increases oxygen production.", 175, "+4 Oxygen/Step")
        };
    }

    void PopulateUpgradeMenu()
    {
        foreach (var upgrade in upgrades)
        {
            GameObject newBlock = Instantiate(upgradeBlockPrefab, contentArea);

            var titleText = newBlock.transform.Find("Title").GetComponent<TextMeshProUGUI>();
            var descriptionText = newBlock.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            var costText = newBlock.transform.Find("Cost").GetComponent<TextMeshProUGUI>();
            var buyButton = newBlock.transform.Find("BuyButton").GetComponent<Button>();

            titleText.text = upgrade.title;
            descriptionText.text = upgrade.description + "\nEffect: " + upgrade.effect;
            costText.text = "Cost: " + upgrade.cost + " Fortynium";

            buyButton.onClick.AddListener(() => TryPurchaseUpgrade(upgrade));
        }
    }

    void TryPurchaseUpgrade(Upgrade upgrade)
    {
        if (upgrade.CanAfford(currentFortynium))
        {
            currentFortynium -= upgrade.cost;
            upgrade.ApplyEffect();
        }
        else
        {
            Debug.Log("Not enough Fortynium to purchase this upgrade.");
        }
    }

}