using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Turn : MonoBehaviour, IComparable<Turn>
{

    private UnitStats _turnTaker { get; set;}
	private UnitStats _turnTarget { get; set; }

    private bool actnPicked = false;

    private Button attackBtn, runBtn;

    private int _turnOrder = 0;
	public int turnOrder {
        get {return _turnOrder; }
        set {_turnOrder = turnOrder; } 
    }

	public Turn(UnitStats turnTaker, UnitStats turntarget, int TurnOrder)
	{
        _turnTaker = turnTaker;
        _turnTarget = turntarget;
        _turnOrder = TurnOrder;
       
	}


    public void attackTurn(int num)
    {

    }

    public void runTurn(int num)
    {

    }

    public int CompareTo(Turn other)
    {
        if (other == null)
        {
            throw new Exception("Incompatable compare types.");
        }
        return turnOrder.CompareTo(other.turnOrder);
    }


}
