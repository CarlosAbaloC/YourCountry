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

    public void saveState(string idCountry, int day, IReadOnlyList<City> cities)
    {
        
        GD.Print("Guardando estado del juego...", idCountry, "dia: ", day);
        var citiesData = new Godot.Collections.Array();
        foreach (var city in cities)
        {
            var cityData = new Godot.Collections.Dictionary
            {
                ["name"] = city.Name,
                ["population"] = city.Population,
                ["health"] = city.Health,
                ["education"] = city.Education,
                ["economy"] = city.Economy
            };
            GD.Print($"Salud: {city.Health}, Población: {city.Population}, Educacion: {city.Education}, Economia: {city.Economy}");
            citiesData.Add(cityData);
        }

        var saveData = new Godot.Collections.Dictionary
        {
            ["id"] = idCountry,
            ["day"] = day,
            ["cities"] = citiesData
        };

        using var file = FileAccess.Open(
            "user://savegame.json",
            FileAccess.ModeFlags.Write
        );
        file.StoreString(Json.Stringify(saveData, "\t"));
    }
    public string loadState()
    {
        
        string jsonText = FileAccess.GetFileAsString(
			"user://savegame.json"
		);

        var parser = new Json();
        Error parseResult = parser.Parse(jsonText);
        if(parseResult != Error.Ok)
        {
            //Si da error entra aqui
            GD.PushError($"Error al analizar el JSON {parser.GetErrorMessage()}");
            return "No se ha podido cargar " + parser.GetErrorMessage();
        }
                
        return jsonText;

    }
}
