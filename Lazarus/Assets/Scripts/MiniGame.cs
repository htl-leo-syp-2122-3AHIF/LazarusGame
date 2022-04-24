using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    // Start is called before the first frame update
    BattleManager _battleManager;
    void Start()
    {
        _battleManager = (BattleManager)GameObject.Find("GameManager").GetComponent("BattleManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (_battleManager != null)
        {
            if (_battleManager.CurrState == States.Player)
            {
                Destroy(gameObject);
            }
        }
    }
}
