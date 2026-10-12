using Godot;
using System;
using System.Collections.Generic;

public class GameState
{
    public Country Country { get; }
    private readonly List<Country> _countries = new();
    public IReadOnlyList<Country> Countries => _countries;
    public GameState(Country country)
    {
        ArgumentNullException.ThrowIfNull(country);
        GD.Print("El pais que se guarda es: ", country);
        Country = country;
        _countries.Add(country);

    }
    public void Addcounty(Country county)
	{
		ArgumentNullException.ThrowIfNull(county);

		GD.Print("Pais: " + county);
		
		_countries.Add(county);
	}
}
