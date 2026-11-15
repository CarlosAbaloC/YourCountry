using Godot;
using System;

public partial class GameTime 
{
	public int CurrentDay {get; private set;} = 1;

	// Avanza el tiempo en un día, hay que cambiarlo a cuando haya un boton
	public void AdvanceDay()
	{
		CurrentDay++;
		GD.Print($"Avanzando al día {CurrentDay}");
	}
}
