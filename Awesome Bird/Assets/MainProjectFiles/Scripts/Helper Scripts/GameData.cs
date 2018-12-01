using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData {

	private int coin_Score;
	private int best_Score;

	private bool[] birds;
	private int selected_Index;

	public int coinScore {
		get { 
			return coin_Score;
		}

		set {
			coin_Score = value;
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






































