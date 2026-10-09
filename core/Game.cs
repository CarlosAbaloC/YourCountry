using Godot;
using System;

public partial class Game : Node
{
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
		//var france = new Country("Francia");
		try
		{
			spain.AddCity(new City(spain, "Madrid", 3527924));
			spain.AddCity(new City(spain, "Barcelona", 1620343));
		}
		catch (ArgumentException ex)
		{
			GD.PrintErr(ex.Message);
		}
		//AddCity esta en country

		return new GameState(spain);
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
}
