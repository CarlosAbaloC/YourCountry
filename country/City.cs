using Godot;
using System;

public partial class City
{
	private string name = "Ciudad";
	private int population = 0;
	private string location = "";
	private double economy = 0;
	private double health = 0;
	private double technology = 0;
	private double education = 0;
	public Country Country {get;}

	public City(Country country, string name, int population)
	{
		Country = country;
		this.name = name;
		this.population = population;
	}
	public City(Country country, string name, int population, double economy, double health)
	{
		Country = country;
		this.name = name;
		this.population = population;
		this.economy = economy;
		this.health = health;
	}

	public City(Country country, string name, int population, double economy, double health, double technology, double education)
	{
		Country = country;
		this.name = name;
		this.population = population;
		this.economy = economy;
		this.health = health;
		this.technology = technology;
		this.education = education;
	}
	public City(Country country, string name, string location, double economy)
	{
		Country = country;
		this.name = name;
		this.location = location;
		this.economy = economy;
	}


	public string Name
	{
		get { return name; }
		private set { name = value; }
	}
	public string Location
	{
		get { return location; }
		private set { location = value; }
	}
	public int Population
	{
		get { return population; }
		private set { population = value; }
	}	
	public double Economy
	{
		get { return economy; }
		private set { economy = value; }
	}		
	public double Health
	{
		get { return health; }
		private set { health = value; }
	}		
	public double Technology
	{
		get { return technology; }
		private set { technology = value; }
	}	
	public double Education
	{
		get { return education; }
		private set { education = value; }
	}	
}
