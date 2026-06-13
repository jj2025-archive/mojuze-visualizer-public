using System;
using Boo.Lang.Runtime;
using UnityEngine;

[Serializable]
public class Tooltip_Aorta : MonoBehaviour
{
	public string toolTipText;

	private string currentToolTipText;

	private GUIStyle guiStyleFore;

	private GUIStyle guiStyleBack;

	private Material mat1;

	private Material mat2;

	private Material[] theMaterials;

	private Color originalColor1;

	private Color originalColor2;

	public Tooltip_Aorta()
	{
		toolTipText = string.Empty;
		currentToolTipText = string.Empty;
	}

	public virtual void Start()
	{
		guiStyleFore = new GUIStyle();
		guiStyleFore.normal.textColor = Color.white;
		guiStyleFore.alignment = TextAnchor.UpperCenter;
		guiStyleFore.wordWrap = true;
		guiStyleFore.fontSize = 22;
		guiStyleBack = new GUIStyle();
		guiStyleBack.normal.textColor = Color.black;
		guiStyleBack.alignment = TextAnchor.UpperCenter;
		guiStyleBack.wordWrap = true;
		guiStyleBack.fontSize = 22;
	}

	public virtual void OnMouseEnter()
	{
		currentToolTipText = toolTipText;
		if (!RuntimeServices.EqualityOperator(mat1.color, null))
		{
			mat1.color = new Color(0.7f, 0.7f, 0.7f);
		}
		if (!RuntimeServices.EqualityOperator(mat2.color, null))
		{
			mat2.color = new Color(0.7f, 0.7f, 0.7f);
		}
	}

	public virtual void OnMouseExit()
	{
		currentToolTipText = string.Empty;
		if (!RuntimeServices.EqualityOperator(mat1.color, null))
		{
			mat1.color = originalColor1;
		}
		if (!RuntimeServices.EqualityOperator(mat2.color, null))
		{
			mat2.color = originalColor2;
		}
	}

	public virtual void onMouseButtonUp()
	{
	}

	public virtual void OnGUI()
	{
		if (currentToolTipText != string.Empty)
		{
			float x = Event.current.mousePosition.x;
			float y = Event.current.mousePosition.y;
			GUI.Label(new Rect(x - 5f, y - 4f, 400f, 60f), currentToolTipText, guiStyleBack);
			GUI.Label(new Rect(x - 5f, y - 4f, 400f, 60f), currentToolTipText, guiStyleFore);
		}
	}

	public virtual void Main()
	{
		theMaterials = renderer.materials;
		mat1 = theMaterials[0];
		mat2 = theMaterials[1];
		originalColor1 = mat1.color;
		originalColor2 = mat2.color;
	}
}
