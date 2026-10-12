using Godot;
using System;

public partial class Main : Node
{
	//? permite null
	private Game? _game;
	//Null avisa de que los campos se asignan despues - 
	// ! Dice que cuando se inicie el elemento no sera null

	private LineEdit _commandInput = null!;
	private RichTextLabel _output = null!;
	private LineEdit _commandInput2 = null!;
	private RichTextLabel _output2 = null!;
	private LineEdit _LENameCity = null!;
	private LineEdit _LECityLocation = null!;
	private LineEdit _LECityBudget = null!;
	private LineEdit _LECCountry = null!;
	private Button _BtnCreateCity = null!;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_commandInput = GetNode<LineEdit>("LineEdit");
		_output = GetNode<RichTextLabel>("RichTextLabel");
		_commandInput2 = GetNode<LineEdit>("LineEdit2");
		_output2 = GetNode<RichTextLabel>("RichTextLabel2");	
		_LENameCity = GetNode<LineEdit>("LENameCity");
		_LECityLocation = GetNode<LineEdit>("LECityLocation");
		_LECityBudget = GetNode<LineEdit>("_LECityBudget");
		_LECCountry = GetNode<LineEdit>("_LECCountry");
		_BtnCreateCity = GetNode<Button>("BtnCreateCity");


		var game = new Game();
		_game = game;
		AddChild(game);
		GD.Print("Nombre del juego es, THE WAY (Existe)" + ProjectSettings.GetSetting("application/config/name"));

		_commandInput.TextSubmitted += OnCommandSubmitted;
		_output.Text = "Escribe el codigo que necesites y pulsa enter";
		_commandInput2.TextSubmitted += OnCitiesCommand;
		_BtnCreateCity.Pressed += OnAddCityPressed;

	}

	private void OnCommandSubmitted(string text)
	{
		// if(_game is null)
		// {
		// 	GD.PushError("Aun no se ha iniciado el juego");
		// 	return;
		// }
		// if(string.Equals(text.Trim(), "next day", StringComparison.OrdinalIgnoreCase))
		// {
		// 	_game.AdvanceDay();
		// 	_output.Text = $"Dia actual: {_game.Time.CurrentDay}";
		// }
		// else
		// {
		// 	_output.Text = "Comando no reconocido. Es next day";
		// }
		// _commandInput.Clear();
		_output.Text = _game.HandleCommand(text);
		_commandInput.Clear();
	}
	private void OnCitiesCommand(string text)
	{
		_output2.Text = _game.OnCitySearchSubmitted(text);
		_commandInput2.Clear();
	}

	private void OnAddCityPressed()
	{
		//_game.NewCity(
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
