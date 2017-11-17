using System;
using UnityEngine.EventSystems;

public class UpButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public Viper nave = null;
	public void OnPointerDown(PointerEventData eventData)
	{
		// Mover nave arriba
		nave.inputUp(true);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		// Dejar de mover nave
		nave.inputUp(false);
	}
}