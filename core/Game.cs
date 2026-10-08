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
		Console.WriteLine("¿Quieres pasar de día? Escribe Y o N y pulsa Enter.");



	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
		}
		catch (ArgumentException ex)
		{
			GD.PrintErr(ex.Message);
		}
		//AddCity esta en country

		return new GameState(spain);
	}

	public void AdvanceDay()
	{
		Time.AdvanceDay();
		GD.Print($"Día {Time.CurrentDay}");
	}
}
