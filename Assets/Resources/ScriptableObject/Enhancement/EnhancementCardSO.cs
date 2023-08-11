using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnhancementCard", menuName = "EnhancementCard" +"")]
public class EnhancementCardSO : ScriptableObject {
	public EnhancementCode nameCard = EnhancementCode.NoName;
	public EnhancementType typeCard = EnhancementType.Enhancement;
	public Sprite image ;
	public string explain; 
	public float attribute = 0 ;
}
