using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

//Ce fichier a pour but de gerer les donnees ainsi que la gestion en arriere plan du jeu
public class Manager : MonoBehaviour
{
	public class Ressources
	{
		public int quantity = 0;
	}
	public class Module
	{
		public Vector2 position = new(0f, 0f);
	}
	public static class Data
	{
		//liste des modules existants
		public static List<Module> Modules_list = new();

		//creation des ressources
		public static Ressources Oxygen = new();
		public static Ressources Food = new();
		public static Ressources Energy = new();
		public static Ressources Fortynium = new();
		public static Ressources Wallet = new();
		public static Ressources Humans = new();
	}
	private void Start()
	{
		// ressources de depart
		Data.Oxygen.quantity = 10;
		Data.Food.quantity = 10;
		Data.Energy.quantity = 10;
		Data.Humans.quantity = 10;
	}
	private void Update()
	{
	}
}
