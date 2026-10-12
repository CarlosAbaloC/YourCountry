using Godot;
using System;
using System.Collections.Generic;

public partial class Game : Node
{
	List<string> commandList = new List<string>()
	{
		"next day",
		"list cities",
		"all cities",
		"countries"

	};
	public GameState State { get; } = CreateInitialState();
	public GameTime Time {get; } = new();
	public CommandManager Commands {get; } = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print($"Juego iniciado. Día {Time.CurrentDay}");
		//Time.AdvanceDay();
		//GD.Print($"Juego iniciado. Día {Time.CurrentDay}");
		var num = 1;
		foreach (var city in State.Country.Cities)
		{
			GD.Print("Ciudad: " + num);
			GD.Print($"Ciudad: {city.Name}, Población: {city.Population}");
			num++;
		}
		//Console.WriteLine("¿Quieres pasar de día? Escribe Y o N y pulsa Enter.");



	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private static GameState CreateInitialState()
	{
		
		var spain = new Country("España");
		var france = new Country("Francia");
		//var france = new Country("Francia");
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
		//AddCity esta en country
		var state = new GameState(spain);
		state.Addcounty(france);
		return state;
	}

	public string HandleCommand(string text)
	{
		if(Commands.IsNextDayCommand(text, "next day"))
		{
			AdvanceDay();
			return $"Dia actual: {Time.CurrentDay}";
		}
		if(Commands.IsNextDayCommand(text, "list cities"))
		{
			string listCities = ListCities();
			return listCities;
		}
		if(Commands.IsNextDayCommand(text, "all cities"))
		{
			string allCities = AllCities();
			return allCities;
		}
		if(Commands.IsNextDayCommand(text, "help"))
		{
			var list = "";
			foreach(string command in commandList)
			{
				list += command + ", \n";
			}
			return $"Comandos disponibles: \n{list}";
		}
		return "Comando no reconocido.";
		
	}

	public string OnCitySearchSubmitted(string text)
	{
		foreach(var city in State.Country.Cities)
		{
			if(city.Name.Equals(text.Trim(), StringComparison.OrdinalIgnoreCase))
			{
				string response = $"""
				Nombre: {city.Name}
				Población: {city.Population}
				País: {city.Country.Name}
				Economia: {city.Economy}
				Salud: {city.Health}
				Tecnología: {city.Technology}
				Educación: {city.Education}
				""";
				return response;
			}
		}
		return "No se encontro la ciudad";
	}

	public void AdvanceDay()
	{
		Time.AdvanceDay();
		GD.Print($"Día {Time.CurrentDay}");
	}

	public string ListCities()
	{
		var num = 1;
		var text = "Lista de ciudades:\n";

		foreach (var city in State.Country.Cities)
		{
			GD.Print("Ciudad: " + num);
			text += $"Ciudad: {city.Name}, Población: {city.Population}";
			text += "\n";

			num++;
		}
		return text;
	}

		public string AllCities()
	{
		var num = 1;
		var text = "Lista de ciudades:\n";
		foreach (var state in State.Countries)
		{
			foreach (var city in state.Cities)
			{
				GD.Print("Ciudad: " + num);
				text += $"Ciudad: {city.Name}, Población: {city.Population}, Pais: {city.Country.Name}";
				text += "\n";

				num++;
			}
		}
		
		return text;
	}

	public void NewCity(string name, string countryName, int budget, int population)
	{
		if(!string.Equals(
			State.Country.Name,
			countryName.Trim(),
			StringComparison.OrdinalIgnoreCase
			))
		{
			GD.PrintErr($"El país {countryName} no coincide con el país del juego: {State.Country.Name}");
		}
		Country country = State.Country;
		country.AddCity(new City(country, name, population, budget, 0, 0, 0));
	}

}
