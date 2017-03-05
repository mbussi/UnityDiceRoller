using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dictionaries {
	public static Dictionary<string, string> actionDictionary = new Dictionary<string, string>()
	{
		{"black", ""},
		{"blue", ""},
		{"cyan", ""},
		{"green", ""},
		{"orange", ""},
		{"pink", ""},
		{"red", ""},
		{"scarlet", ""},
		{"white", ""},
		{"yellow", ""}
	};

	public static readonly Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>()
	{
		{"black", new Color(Color.black.r, Color.black.g, Color.black.b, .7f)},
		{"blue", new Color(Color.blue.r, Color.blue.g, Color.blue.b, .7f)},
		{"cyan", new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, .7f)},
		{"green", new Color(Color.green.r, Color.green.g, Color.green.b, .7f)},
		{"orange", new Color(1f, .65234f, 0f, .7f)},
		{"pink", new Color(1f, .4141f, .707f, .7f)},
		{"red", new Color(Color.red.r, Color.red.g, Color.red.b, .7f)},
		{"scarlet", new Color(1f, .1f, 0f, .7f)},
		{"white", new Color(Color.white.r, Color.white.g, Color.white.b, .7f)},
		{"yellow", new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, .7f)}
	};
	
	public static readonly Dictionary<Vector2, int> d4Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(0f, 180f), 1},
		{new Vector2(0f, 90f), 2},
		{new Vector2(0f, 270f), 3},
		{new Vector2(0f, 0f), 4}
	};
	
	public static readonly Dictionary<Vector2, int> d6Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(0f, 270f), 1},
		{new Vector2(0f, 180f), 2},
		{new Vector2(90f, 0f), 3},
		{new Vector2(270f, 0f), 4},
		{new Vector2(0f, 0f), 5},
		{new Vector2(0f, 90f), 6}
	};
	
	public static readonly Dictionary<Vector2, int> d8Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(35f, 315f), 1},
		{new Vector2(325f, 225f), 2},
		{new Vector2(35f, 225f), 3},
		{new Vector2(325f, 315f), 4},
		{new Vector2(35f, 135f), 5},
		{new Vector2(325f, 45f), 6},
		{new Vector2(35f, 45f), 7},
		{new Vector2(325f, 135f), 8}
	};
	
	public static readonly Dictionary<Vector2, int> d10Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(42f, 35f), 1},
		{new Vector2(318f, 289f), 2},
		{new Vector2(42f, 323f), 3},
		{new Vector2(318f, 359f), 4},
		{new Vector2(42f, 252f), 5},
		{new Vector2(318f, 73f), 6},
		{new Vector2(42f, 180f), 7},
		{new Vector2(318f, 145f), 8},
		{new Vector2(42f, 109f), 9},
		{new Vector2(318f, 215f), 10}
	};
	
	public static readonly Dictionary<Vector2, int> d12Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(328f, 360f), 1},
		{new Vector2(302f, 270f), 2},
		{new Vector2(0f, 122f), 3},
		{new Vector2(302f, 90f), 4},
		{new Vector2(32f, 0f), 5},
		{new Vector2(0f, 58f), 6},
		{new Vector2(0f, 238f), 7},
		{new Vector2(328f, 180f), 8},
		{new Vector2(58f, 270f), 9},
		{new Vector2(0f, 302f), 10},
		{new Vector2(58f, 90f), 11},
		{new Vector2(32f, 180f), 12}
	};
	
	public static readonly Dictionary<Vector2, int> d20Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(52.6f, 54f), 1},
		{new Vector2(307.4f, 306f), 2},
		{new Vector2(10.8f, 126f), 3},
		{new Vector2(10.8f, 270f), 4},
		{new Vector2(10.8f, 342f), 5},
		{new Vector2(10.8f, 198f), 6},
		{new Vector2(10.8f, 54f), 7},
		{new Vector2(307.4f, 162f), 8},
		{new Vector2(52.6f, 198f), 9},
		{new Vector2(307.4f, 90f), 10},
		{new Vector2(52.6f, 270f), 11},
		{new Vector2(307.4f, 18f), 12},
		{new Vector2(52.6f, 342f), 13},
		{new Vector2(349.2f, 234f), 14},
		{new Vector2(349.2f, 18f), 15},
		{new Vector2(349.2f, 162f), 16},
		{new Vector2(349.2f, 90f), 17},
		{new Vector2(349.2f, 306f), 18},
		{new Vector2(52.6f, 126f), 19},
		{new Vector2(307.4f, 234f), 20}
	};
	
	public static readonly Dictionary<Vector2, int> d100Dictionary = new Dictionary<Vector2, int>()
	{
		{new Vector2(42f, 35f), 10},
		{new Vector2(318f, 289f), 20},
		{new Vector2(42f, 323f), 30},
		{new Vector2(318f, 359f), 40},
		{new Vector2(42f, 252f), 50},
		{new Vector2(318f, 73f), 60},
		{new Vector2(42f, 180f), 70},
		{new Vector2(318f, 145f), 80},
		{new Vector2(42f, 109f), 90},
		{new Vector2(318f, 215f), 0}
	};
	
	public static readonly Dictionary<string, Dictionary <Vector2, int>> diceDictionaryDictionary = new Dictionary<string, Dictionary <Vector2, int>>()
	{
		{"superior_D4", d4Dictionary},
		{"superior_D6", d6Dictionary},
		{"superior_D8", d8Dictionary},
		{"superior_D10", d10Dictionary},
		{"superior_D12", d12Dictionary},
		{"superior_D20", d20Dictionary},
		{"superior_D100", d100Dictionary}
	};
}
