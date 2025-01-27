using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Upgrade
{
	public string title;
	public string description;
	public int cost;
	public string effect;
	public Sprite icon;

	public Upgrade(string title, string description, int cost, string effect, Sprite icon = null)
	{
		this.title = title;
		this.description = description;
		this.cost = cost;
		this.effect = effect;
		this.icon = icon;
	}

	public bool CanAfford(int currentFortynium)
	{
		return currentFortynium >= cost;
	}

	public void ApplyEffect()
	{
		Debug.Log($"Upgrade applied: {title} with effect: {effect}");
	}
}
