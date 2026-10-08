using Godot;
using System;
using System.Collections.Generic;
public partial class Country
{
	//Para que nadie pueda modificar esta lista
	private readonly List<City> _cities = new();

	public string Name {get;}

	public IReadOnlyList<City> Cities => _cities;

	public Country(string name)
	{
		Name = name;
	}

	//Añade la clase
	public void AddCity(City city)
	{
		ArgumentNullException.ThrowIfNull(city);

		//this hace referencia a todo el objeto, igual que city.country
		if(!ReferenceEquals(city.Country, this))
		{
			throw new ArgumentException(
				"La  ciudad tiene una ubicacion de pais distinta al lugar donde se guarda ", 
				nameof(city)
			);
		}
		GD.Print("Pais del city: " + city.Country);
		GD.Print("Pais en general: " + Name);
		
		_cities.Add(city);
	}

}
