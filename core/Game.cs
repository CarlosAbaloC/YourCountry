using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node
{
	private readonly List<string> _commandList = new()
	{
		"next day",
		"list cities",
		"all cities",
		"help"

	};
	public GameState State { get; } = CreateInitialState();
	public GameTime Time {get; } = new();
	public CommandManager Commands {get; } = new();
	public override void _Ready()
	{
		GD.Print($"Juego iniciado. Día {Time.CurrentDay}");
		foreach (var city in State.Country.Cities)
		{
			GD.Print($"Ciudad: {city.Name}, Población: {city.Population}");
		}
	}

	public override void _Process(double delta)
	{
	}

	private static GameState CreateInitialState()
	{
		var spain = new Country("España");
		var france = new Country("Francia");
		try
		{
			spain.AddCity(new City(spain, "Madrid", 3527924));
			spain.AddCity(new City(spain, "Barcelona", 1620343));
			france.AddCity(new City(france, "París", 2140526));
		}
		catch (ArgumentException ex)
		{
			GD.PrintErr(ex.Message);
		}
		var state = new GameState(spain);
		state.AddCountry(france);
		return state;
	}

	public string HandleCommand(string text)
	{
		if(Commands.MatchesCommand(text, "next day"))
		{
			AdvanceDay();
			return $"Día actual: {Time.CurrentDay}";
		}
		if(Commands.MatchesCommand(text, "list cities"))
		{
			return ListCities();
		}
		if(Commands.MatchesCommand(text, "all cities"))
		{
			return AllCities();
		}
		if(Commands.MatchesCommand(text, "help"))
		{
			var commandText = "";
			foreach (string command in _commandList)
			{
				commandText += command + ",\n";
			}
			return $"Comandos disponibles:\n{commandText}";
		}
		return "Comando no reconocido.";
	}

	public string OnCitySearchSubmitted(string text)
	{
		foreach(var country in State.Countries)
		{
			foreach(var city in country.Cities)
			{
				if(city.Name.Equals(text.Trim(), StringComparison.OrdinalIgnoreCase))
				{
					string response = $"""
					Nombre: {city.Name}
					Ubicación: {city.Location}
					Población: {city.Population}
					País: {city.Country.Name}
					Economía: {city.Economy}
					Salud: {city.Health}
					Tecnología: {city.Technology}
					Educación: {city.Education}
					""";
					return response;
				}
			}

		}
		return "No se encontró la ciudad";
	}

	public void AdvanceDay()
	{
		Time.AdvanceDay();
		GD.Print($"Día {Time.CurrentDay}");
	}

	public string ListCities()
	{
		var cityNumber = 1;
		var output = "Lista de ciudades:\n";

		foreach (var city in State.Country.Cities)
		{
			GD.Print($"Ciudad {cityNumber}: {city.Name}");
			output += $"Ciudad: {city.Name}, Población: {city.Population}\n";
			cityNumber++;
		}
		return output;
	}

	public string AllCities()
	{
		var cityNumber = 1;
		var output = "Lista de ciudades:\n";
		foreach (var country in State.Countries)
		{
			foreach (var city in country.Cities)
			{
				GD.Print($"Ciudad {cityNumber}: {city.Name}");
				output += $"Ciudad: {city.Name}, Población: {city.Population}, País: {city.Country.Name}\n";
				cityNumber++;
			}
		}

		return output;
	}

	public void NewCity(string name, string countryName, string location, int budget)
	{
		foreach (Country country in State.Countries)
		{
			if (string.Equals(
				country.Name,
				countryName.Trim(),
				StringComparison.OrdinalIgnoreCase
			))
			{
				country.AddCity(new City(country, name, location, budget));
				return;
			}
		}

		GD.PrintErr($"No se encontró el país {countryName}.");
	}
}
