public class Vital : ModifiedStat {
	private int currentValue;

	public Vital(){
		currentValue = 100;
	}

	public int CurValue{
		get{
			if(currentValue > AdjustedBaseValue)			//so health doesnt go above max
				currentValue = AdjustedBaseValue;
			return currentValue;
		}
		set{currentValue= value;}
	}
}

public enum VitalName{
	Health,												//names for stats
	Mana
}