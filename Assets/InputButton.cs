using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public enum Type {UP, DOWN, LEFT, RIGHT, FIRE }
	public Type myType = Type.UP;

	public Viper ship = null;

	public void OnPointerDown(PointerEventData eventData)
	{
		switch(myType)
		{
			case Type.UP:
				ship.inputUp(true);
				break;
			case Type.DOWN:
				ship.inputDown(true);
				break;
			case Type.LEFT:
				ship.inputLeft(true);
				break;
			case Type.RIGHT:
				ship.inputRight(true);
				break;
			case Type.FIRE:
				ship.inputFire(true);
				break;

		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		switch(myType)
		{
			case Type.UP:
				ship.inputUp(false);
				break;
			case Type.DOWN:
				ship.inputDown(false);
				break;
			case Type.LEFT:
				ship.inputLeft(false);
				break;
			case Type.RIGHT:
				ship.inputRight(false);
				break;
			case Type.FIRE:
				ship.inputFire(false);
				break;
		}
	}
}
