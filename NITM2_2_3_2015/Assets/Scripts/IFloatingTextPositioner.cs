using UnityEngine;
using System;

public interface IFloatingTextPositioner
{
	bool GetPosition(ref Vector2 position, GUIContent content, Vector2 size);
}

