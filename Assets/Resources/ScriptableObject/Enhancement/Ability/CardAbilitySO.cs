using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "SO/EnhancementCard/AbilityLevel" +"")]
public class CardAbilitySO : CardSO {
	public int level = 1;
	public string explain;
	public CardAbilitySO(){
		typeCard = EnhancementType.LevelAbility;
	}
}
