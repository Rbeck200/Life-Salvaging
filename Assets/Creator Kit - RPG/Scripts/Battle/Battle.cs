using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    private UnitStats _player;
    private UnitStats _enemy;
    private int skipamt;
    private bool actnPicked = false;

    PriorityQueue<Turn> turns = new PriorityQueue<Turn>();

    [SerializeField]
    private Button mainBtn, scndBtn;

    void Start()
    {
        //creates a new player and assigns it to the private variable.
        UnitStats player = new UnitStats(2, true);
        _player = player;
      
        UnitStats newEnemy = new UnitStats(player.lvl, false);
        _enemy = newEnemy;

        UnitStats First = _player;
        UnitStats Second = _enemy;

        if(_player.spd < _enemy.spd)
        {
            UnitStats Temp = First;
            First = Second;
            Second = Temp;
            
        }

        Turn playerTurn = new Turn(First, Second, turns.GetSize() + 1);
        turns.enqueue(playerTurn);
        Turn enemyTurn = new Turn(Second, First, turns.GetSize() + 1);
        turns.enqueue(enemyTurn);

        skipamt = turns.GetSize();

        while(_player.isDead() == false && _enemy.isDead() == false)
        {
            nextTurn();
        }

    }

    void nextTurn()
    {
        Turn current = turns.Dequeue();
        int rand;
        while (!actnPicked)
        {
            mainBtn.onClick.AddListener(delegate
            {
                rand = UnityEngine.Random.Range(1, 11);
                current.attackTurn(rand);
                actnPicked = true;
            });

            scndBtn.onClick.AddListener(delegate
            {
                rand = UnityEngine.Random.Range(1, 11);
                current.runTurn(rand);
                actnPicked = true;
            });
            break;
        }
        current.turnOrder += skipamt;
        turns.enqueue(current);

    }

    public void createButtons()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
