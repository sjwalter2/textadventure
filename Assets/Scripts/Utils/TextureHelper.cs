using UnityEngine;
using System.Collections;
public class TextureHelper : MonoBehaviour
{
	// overloaded method to create a texture with color, or if no color is passed, return a black texture
	public static Texture2D CreateTexture(int width, int height)
	{
		return CreateTexture(width, height, Color.black);
	}
	// Create and return a colored texture
	public static Texture2D CreateTexture(int width, int height, Color color)
	{
		Texture2D texture = new Texture2D(width, height);
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				texture.SetPixel(i, j, color);
			}
		}
		texture.Apply();
		return texture;
	}
	// Create and return an alphabetical texture
	public static Texture2D CreateLetterTexture(int width, int height, char letter)
	{
		Texture2D texture = new Texture2D(width, height);
		switch(letter)
		{
		case 'A':
			texture = Resources.Load("Sprites/A") as Texture2D;
			break;
		case 'B':
			texture = Resources.Load("Sprites/B") as Texture2D;
			break;
		case 'C':
			texture = Resources.Load("Sprites/C") as Texture2D;
			break;
		case 'D':
			texture = Resources.Load("Sprites/D") as Texture2D;
			break;
		case 'E':
			texture = Resources.Load("Sprites/E") as Texture2D;
			break;
		case 'F':
			texture = Resources.Load("Sprites/F") as Texture2D;
			break;
		case 'G':
			texture = Resources.Load("Sprites/G") as Texture2D;
			break;
		case 'H':
			texture = Resources.Load("Sprites/H") as Texture2D;
			break;
		case 'I':
			texture = Resources.Load("Sprites/I") as Texture2D;
			break;
		case 'J':
			texture = Resources.Load("Sprites/J") as Texture2D;
			break;
		case 'K':
			texture = Resources.Load("Sprites/K") as Texture2D;
			break;
		case 'L':
			texture = Resources.Load("Sprites/L") as Texture2D;
			break;
		case 'M':
			texture = Resources.Load("Sprites/M") as Texture2D;
			break;
		case 'N':
			texture = Resources.Load("Sprites/N") as Texture2D;
			break;
		case 'O':
			texture = Resources.Load("Sprites/O") as Texture2D;
			break;
		case 'P':
			texture = Resources.Load("Sprites/P") as Texture2D;
			break;
		case 'Q':
			texture = Resources.Load("Sprites/Q") as Texture2D;
			break;
		case 'R':
			texture = Resources.Load("Sprites/R") as Texture2D;
			break;
		case 'S':
			texture = Resources.Load("Sprites/S") as Texture2D;
			break;
		case 'T':
			texture = Resources.Load("Sprites/T") as Texture2D;
			break;
		case 'U':
			texture = Resources.Load("Sprites/U") as Texture2D;
			break;
		case 'V':
			texture = Resources.Load("Sprites/V") as Texture2D;
			break;
		case 'W':
			texture = Resources.Load("Sprites/W") as Texture2D;
			break;
		case 'X':
			texture = Resources.Load("Sprites/X") as Texture2D;
			break;
		case 'Y':
			texture = Resources.Load("Sprites/Y") as Texture2D;
			break;
		case 'Z':
			texture = Resources.Load("Sprites/Z") as Texture2D;
			break;
		case 'a':
			texture = Resources.Load("Sprites/A") as Texture2D;
			break;
		case 'b':
			texture = Resources.Load("Sprites/B") as Texture2D;
			break;
		case 'c':
			texture = Resources.Load("Sprites/C") as Texture2D;
			break;
		case 'd':
			texture = Resources.Load("Sprites/D") as Texture2D;
			break;
		case 'e':
			texture = Resources.Load("Sprites/E") as Texture2D;
			break;
		case 'f':
			texture = Resources.Load("Sprites/F") as Texture2D;
			break;
		case 'g':
			texture = Resources.Load("Sprites/G") as Texture2D;
			break;
		case 'h':
			texture = Resources.Load("Sprites/H") as Texture2D;
			break;
		case 'i':
			texture = Resources.Load("Sprites/I") as Texture2D;
			break;
		case 'j':
			texture = Resources.Load("Sprites/J") as Texture2D;
			break;
		case 'k':
			texture = Resources.Load("Sprites/K") as Texture2D;
			break;
		case 'l':
			texture = Resources.Load("Sprites/L") as Texture2D;
			break;
		case 'm':
			texture = Resources.Load("Sprites/M") as Texture2D;
			break;
		case 'n':
			texture = Resources.Load("Sprites/N") as Texture2D;
			break;
		case 'o':
			texture = Resources.Load("Sprites/O") as Texture2D;
			break;
		case 'p':
			texture = Resources.Load("Sprites/P") as Texture2D;
			break;
		case 'q':
			texture = Resources.Load("Sprites/Q") as Texture2D;
			break;
		case 'r':
			texture = Resources.Load("Sprites/R") as Texture2D;
			break;
		case 's':
			texture = Resources.Load("Sprites/S") as Texture2D;
			break;
		case 't':
			texture = Resources.Load("Sprites/T") as Texture2D;
			break;
		case 'u':
			texture = Resources.Load("Sprites/U") as Texture2D;
			break;
		case 'v':
			texture = Resources.Load("Sprites/V") as Texture2D;
			break;
		case 'w':
			texture = Resources.Load("Sprites/W") as Texture2D;
			break;
		case 'x':
			texture = Resources.Load("Sprites/X") as Texture2D;
			break;
		case 'y':
			texture = Resources.Load("Sprites/Y") as Texture2D;
			break;
		case 'z':
			texture = Resources.Load("Sprites/Z") as Texture2D;
			break;
		}
		return texture;
	}
	// Create and return a 1x1 texture, if no color is passed, then a black texture will be created
	public static Texture2D Create1x1Texture()
	{
		return Create1x1Texture(Color.black);
	}
	// Create and return a 1x1 texture with Color
	public static Texture2D Create1x1Texture(Color color)
	{
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0, 0, color);
		texture.Apply();
		return texture;
	}
}