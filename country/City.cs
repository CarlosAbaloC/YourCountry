using Godot;
using System;

public partial class City
{
	private string name = "Madriz";
	private int population = 100;
	private int economy = 100;
	private int health = 100;
	private int technology = 100;
	private int education = 100;
	public Country Country {get;}

	public City(Country country, string name, int population)
	{
		Country = country;
		this.name = name;
		this.population = population;
	}

	public City(Country country, string name, int population, int economy, int health, int technology, int education)
	{
		Country = country;
		this.name = name;
		this.population = population;
		this.economy = economy;
		this.health = health;
		this.technology = technology;
		this.education = education;
	}


	public string Name
	{
		get { return name; }
		private set { name = value; }
	}
	public int Population
	{
		get { return population; }
		private set { population = value; }
	}	
	public int Economy
	{
		get { return economy; }
		private set { economy = value; }
	}		
	public int Health
	{
		get { return health; }
		private set { health = value; }
	}		
	public int Technology
	{
		get { return technology; }
		private set { technology = value; }
	}	
	public int Education
	{
		get { return education; }
		private set { education = value; }
	}	
}
