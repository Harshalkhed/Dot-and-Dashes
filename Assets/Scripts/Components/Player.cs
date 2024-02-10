using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    //properties for the player's name, icon , color, and score
    public string Name { get; }
    public Sprite Icon { get; }
    public Color32 Color { get; }

    public int Score { get; set; } = 0;

    public Player(string name, Sprite icon, Color32 color)
    {
        Name = name;
        Icon = icon;
        Color = color;
    }
}