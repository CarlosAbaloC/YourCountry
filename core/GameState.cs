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
        GD.Print("El país que se guarda es: ", country);
        Country = country;
        _countries.Add(country);

    }
    public void AddCountry(Country country)
	{
		ArgumentNullException.ThrowIfNull(country);

		GD.Print("País: " + country);
		
		_countries.Add(country);
	}
}
