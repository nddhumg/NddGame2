using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CardAbilitySO", menuName = "SO/EnhancementCard/Ability" +"")]
public class CardAbilitySO : ScriptableObject {
	public UnlockAbilityPlayer.NameAbilityUnlock nameAbility ;
	public int level;
	public string explain;
}
