using Godot;
using System;
using System.Collections.Generic;
public partial class Country
{
	// Expone una vista de solo lectura para evitar cambios externos en la lista.
	private readonly List<City> _cities = new();

	public string Name {get;}

	public IReadOnlyList<City> Cities => _cities;

	public Country(string name)
	{
		Name = name;
	}

	// Añade una ciudad que pertenece a este mismo país.
	public void AddCity(City city)
	{
		ArgumentNullException.ThrowIfNull(city);

		// La ciudad debe conservar una referencia a esta misma instancia de país.
		if(!ReferenceEquals(city.Country, this))
		{
			throw new ArgumentException(
				"La ciudad pertenece a un país distinto del país donde se intenta guardar.",
				nameof(city)
			);
		}
		GD.Print("País de la ciudad: " + city.Country.Name);
		GD.Print("País donde se guarda: " + Name);
		
		_cities.Add(city);
	}

}
