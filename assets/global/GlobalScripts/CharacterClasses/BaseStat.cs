public class BaseStat {
	private int baseValue;  					//base value for the stat
	private int buffValue;						//how much the value affects combat info
	//will have more variables once we figure out how they will work
	//such as exp, skillpoints etc..

	public BaseStat(){
		baseValue = 30;
		buffValue = 0;

	}
	
#region setters and getters
	//may not need these yet
	public int BaseValue {
		get{ return baseValue;}
		set{ baseValue = value;}
		}

	public int BuffValue {
		get{ return buffValue;}
		set{ buffValue = value;}
		}
#endregion

	public int AdjustedBaseValue{
		get{return baseValue + buffValue;}
	}
}
