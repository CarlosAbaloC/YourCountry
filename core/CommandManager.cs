using Godot;
using System;

public partial class CommandManager
{
	public bool MatchesCommand(string command, string expectedCommand)
    {
        
        return string.Equals(
            command.Trim(), 
            expectedCommand, 
            StringComparison.OrdinalIgnoreCase);
    }
}
