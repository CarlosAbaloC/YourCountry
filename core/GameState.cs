using Godot;
using System;

public class GameState
{
    public Country Country { get; }

    public GameState(Country country)
    {
        Country = country;
    }
}
