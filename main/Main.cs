using Godot;
using System;

public partial class Main : Node
{
	//? permite null
	private Game? _game;
	private LineEdit _commandInput = null!;
	private RichTextLabel _output = null!;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_commandInput = GetNode<LineEdit>("LineEdit");
		_output = GetNode<RichTextLabel>("RichTextLabel");
		

		var game = new Game();
		_game = game;
		AddChild(game);
		GD.Print("Nombre del juego es, THE WAY (Existe)" + ProjectSettings.GetSetting("application/config/name"));

		_commandInput.TextSubmitted += OnCommandSubmitted;
		_output.Text = "Escribe next day y pulsa enter";

	}

	private void OnCommandSubmitted(string text)
	{
		if(_game is null)
		{
			GD.PushError("Aun no se ha iniciado el juego");
			return;
		}
		if(string.Equals(text.Trim(), "next day", StringComparison.OrdinalIgnoreCase))
		{
			_game.AdvanceDay();
			_output.Text = $"Dia actual: {_game.Time.CurrentDay}";
		}
		else
		{
			_output.Text = "Comando no reconocido. Es next day";
		}
		_commandInput.Clear();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
