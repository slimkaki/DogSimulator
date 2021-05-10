// Todo o script de Stamina bar é de propriedade intelectual do autor Brackeys, video disponivel em: https://youtu.be/BLfNP4Sc_iA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

	public Slider slider;
	[SerializeField]
	public Image raio, barra, fill;
    GameManager gm;
	private void Start()
    {
        gm = GameManager.GetInstance();
		SetMaxStamina();
    }
	public void SetMaxStamina()
	{
		slider.maxValue = gm.stamina;
		slider.value = gm.stamina;

	}

    public void SetStamina(int stamina)
	{
		slider.value = stamina;

	}
	public void Update(){
		if (gm.gameState != GameManager.GameState.PAUSE || gm.gameState != GameManager.GameState.GAME) {
			raio.enabled = false;
			barra.enabled = false;
			fill.enabled = false;
		}
        if (gm.gameState != GameManager.GameState.GAME) return;

		raio.enabled = true;
		barra.enabled = true;
		fill.enabled = true;

		SetStamina(gm.stamina);
	}
}
