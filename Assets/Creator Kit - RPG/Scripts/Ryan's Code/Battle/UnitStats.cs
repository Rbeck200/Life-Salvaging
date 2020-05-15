using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour{

	//sprite for character
	[SerializeField]
	private Image characterImage;

	//word visualization of hp
	[SerializeField]
	private Text damageText;

	//characters stats
	private int hp { get; set; }
	public int mp { get; set; }
	public int atk { get; set; }
	public int mgk { get; set; }
	public int def { get; set; }
	public int spd { get; set; }
	public int lvl { get; set; }

	//bool to denote player
	private bool _isPlayer = false;

	//bool to denote if dead or alive
	private bool dead = false;

	//thier experience points
	private int Exp = 0;

	//constructor
	public UnitStats(int level, bool isPlayer)
	{
		//give basic stats
		lvl = 1;
		hp = 10;
		mp = 10;
		atk = 2;
		mgk = 2;
		def = 1;
		spd = 3;

		//for however many levels you want to give give level squared and then factorial that down to zero
		for (int i = level; i > 0; i--)
		{
			Exp += (i * i);
		}
		//check to see if player if so extra buff
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
		//level up function
		lvlUp();

	}

	
	//take damage
	public void receiveDamage(int damage) {
		this.hp -= damage;
		damageText.text = hp.ToString();
	}

	//check to see if this is dead
	public bool isDead() {
		return this.dead;
	}

//gain experience
	public void receiveExperience(int experience) {
		this.Exp += experience;
	}
	
	//level up
	public void lvlUp()
	{
		//magic number to level up is level squared 
		int magicNum = lvl * lvl;
		//level up until you cant anymore.
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
