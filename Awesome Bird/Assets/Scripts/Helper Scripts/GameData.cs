using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData {

	private int diamond_Score;
	private int best_Score;

	private bool[] birds;
	private int selected_Index;

	public int DiamondScore {
		get { 
			return diamond_Score;
		}

		set {
			diamond_Score = value;
		}
	}

	public int BestScore {
		get { 
			return best_Score;
		}

		set { 
			best_Score = value;
		}
	}

	public bool[] Birds {
		get { 
			return birds; 
		}

		set {
			birds = value;
		}
	}

	public int SelectedIndex {
		get { 
			return selected_Index;
		}

		set { 
			selected_Index = value;
		}
	}

} // class






































