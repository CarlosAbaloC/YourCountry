using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node
{
	private Game _game = null!;

	private LineEdit _commandInput = null!;
	private RichTextLabel _commandOutput = null!;
	private LineEdit _citySearchInput = null!;
	private RichTextLabel _citySearchOutput = null!;
	private LineEdit _cityNameInput = null!;
	private LineEdit _cityLocationInput = null!;
	private LineEdit _cityBudgetInput = null!;
	private LineEdit _countryNameInput = null!;
	private Button _createCityButton = null!;
	private RichTextLabel _countryListOutput = null!;
	private Button _listCountriesButton = null!;
	private Button _listCitiesButton = null!;

	public override void _Ready()
	{
		_commandInput = GetNode<LineEdit>("LineEdit");
		_commandOutput = GetNode<RichTextLabel>("RichTextLabel");
		_citySearchInput = GetNode<LineEdit>("LineEdit2");
		_citySearchOutput = GetNode<RichTextLabel>("RichTextLabel2");
		_cityNameInput = GetNode<LineEdit>("CityNameInput");
		_cityLocationInput = GetNode<LineEdit>("CityLocationInput");
		_cityBudgetInput = GetNode<LineEdit>("CityBudgetInput");
		_countryNameInput = GetNode<LineEdit>("CountryNameInput");
		_createCityButton = GetNode<Button>("CreateCityButton");
		_countryListOutput = GetNode<RichTextLabel>("CountryListOutput");
		_listCountriesButton = GetNode<Button>("ListCountriesButton");
		_listCitiesButton = GetNode<Button>("ListCitiesButton");

		_game = new Game();
		AddChild(_game);
		GD.Print("Nombre del juego: ", ProjectSettings.GetSetting("application/config/name"));

		_commandInput.TextSubmitted += OnCommandSubmitted;
		_commandOutput.Text = "Escribe un comando y pulsa Enter.";
		_citySearchInput.TextSubmitted += OnCitySearchSubmitted;
		_createCityButton.Pressed += OnCreateCityPressed;
		_listCountriesButton.Pressed += ListCountries;
		_listCitiesButton.Pressed += ListCities;
	}

	private void OnCommandSubmitted(string text)
	{
		_commandOutput.Text = _game.HandleCommand(text);
		_commandInput.Clear();
	}

	private void OnCitySearchSubmitted(string text)
	{
		_citySearchOutput.Text = _game.OnCitySearchSubmitted(text);
		_citySearchInput.Clear();
	}

	private void OnCreateCityPressed()
	{
		string cityName = _cityNameInput.Text.Trim();
		string location = _cityLocationInput.Text.Trim();
		int budget = int.Parse(_cityBudgetInput.Text.Trim());
		string countryName = _countryNameInput.Text.Trim();

		_game.NewCity(cityName, countryName, location, budget);
	}

	public void ListCountries()
	{
		string jsonText = FileAccess.GetFileAsString(
			"res://data/countries-states-cities-palestina.json"
		);

		// Interpreta el texto del archivo con el formato JSON.
		var parser = new Json();
		Error parseResult = parser.Parse(jsonText);

		// Si el JSON no es válido, muestra el detalle y detiene este método.
		if (parseResult != Error.Ok)
		{
			GD.PushError($"Error al analizar el JSON: {parser.GetErrorMessage()}");
			return;
		}

		// El objeto raíz contiene la lista de países y los metadatos.
		Variant jsonData = parser.Data;
		Godot.Collections.Dictionary root = jsonData.AsGodotDictionary();
		Godot.Collections.Array countries = root["countries"].AsGodotArray();
		var countryNames = new List<string>();

		// Cada elemento del array representa un país completo.
		foreach (Variant countryValue in countries)
		{
			Godot.Collections.Dictionary country = countryValue.AsGodotDictionary();
			string countryName = country["name"].AsString();
			GD.Print($"País: {countryName}");
			countryNames.Add(countryName);
		}

		_countryListOutput.Text = string.Join("\n", countryNames);
	}

	public void ListCities()
	{
		string jsonText = FileAccess.GetFileAsString(
			"res://data/countries-states-cities-palestina.json"
		);

		// Interpreta el texto del archivo con el formato JSON.
		var parser = new Json();
		Error parseResult = parser.Parse(jsonText);

		// Si el JSON no es válido, muestra el detalle y detiene este método.
		if (parseResult != Error.Ok)
		{
			GD.PushError($"Error al analizar el JSON: {parser.GetErrorMessage()}");
			return;
		}

		string countrySearchText = _countryNameInput.Text.Trim();
		// La lista de países está en la raíz; cada país contiene sus regiones.
		Variant jsonData = parser.Data;
		Godot.Collections.Dictionary root = jsonData.AsGodotDictionary();
		Godot.Collections.Array countries = root["countries"].AsGodotArray();
		var cityNames = new List<string>();

		foreach (Variant countryValue in countries)
		{
			Godot.Collections.Dictionary country = countryValue.AsGodotDictionary();
			string countryName = country["name"].AsString();

			// Compara el texto escrito con el nombre de cada país.
			if (!countryName.Equals(countrySearchText, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}

			// Cada región contiene su propia lista de localidades.
			Godot.Collections.Array regions = country["states"].AsGodotArray();

			foreach (Variant regionValue in regions)
			{
				Godot.Collections.Dictionary region = regionValue.AsGodotDictionary();
				GD.Print($"Región: {region["name"].AsString()}");
				Godot.Collections.Array cities = region["cities"].AsGodotArray();

				foreach (Variant cityValue in cities)
				{
					Godot.Collections.Dictionary city = cityValue.AsGodotDictionary();
					string cityName = city["name"].AsString();
					GD.Print($"Localidad: {cityName}");
					cityNames.Add(cityName);
				}
			}

			break;
		}

		_countryListOutput.Text = string.Join("\n", cityNames);
	}
}
