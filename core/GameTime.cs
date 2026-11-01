using Godot;
using System;

public partial class GameTime 
{
	public int CurrentDay {get; private set;} = 1;

	// Avanza el reloj del juego un día.
	public void AdvanceDay()
	{
		CurrentDay++;
		GD.Print($"Avanzando al día {CurrentDay}");
	}
}
