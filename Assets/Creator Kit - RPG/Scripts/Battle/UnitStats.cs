using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour{

	[SerializeField]
	private Image characterImage;

	[SerializeField]
	private Text damageText;

	private int hp { get; set; }
	public int mp { get; set; }
	public int atk { get; set; }
	public int mgk { get; set; }
	public int def { get; set; }
	public int spd { get; set; }
	public int lvl { get; set; }

	private bool _isPlayer = false;

	private bool dead = false;

	private int Exp = 0;

	public UnitStats(int level, bool isPlayer)
	{
		lvl = 1;
		hp = 10;
		mp = 10;
		atk = 2;
		mgk = 2;
		def = 1;
		spd = 3;
		for (int i = level; i > 0; i--)
		{
			Exp += (i * i);
		}
		if(isPlayer == true)
		{
			_isPlayer = true;
			hp++;
			mp++;
			atk++;
			mgk++;
			def++;
			spd++;
		}
		lvlUp();

	}

	

	public void receiveDamage(int damage) {
		this.hp -= damage;
		damageText.text = hp.ToString();
	}

	public bool isDead() {
		return this.dead;
	}

	public void receiveExperience(int experience) {
		this.Exp += experience;
	}

	public void lvlUp()
	{

		int magicNum = lvl * lvl;
		while(Exp >= (magicNum))
		{
			lvl++;
			atk+= magicNum;
			mp += magicNum;
			mgk += magicNum;
			def += magicNum;
			spd += magicNum;
			magicNum = lvl * lvl;
		}
	}

}
