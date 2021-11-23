using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame.Helpers
{
	public static class Enums
	{
		public enum CardValue
		{
			ZERO = 0,
			ONE = 1,
			TWO = 2,
			THREE = 3,
			FOUR = 4,
			FIVE = 5,
			SIX = 6,
			SEVEN = 7,
			EIGHT = 8,
			NINE = 9,
			NULL = 99
		}

		public enum CardAction
		{
			NONE=0,
			DRAW_TWO=1,
			DRAW_FOUR=2,
			REVERSE=3,
			SKIP=4,
			WILD=5
		}

		public enum CardColor
		{
			RED = 0,
			GREEN = 1,
			BLUE = 2,
			YELLOW = 3,
			NULL = 99
		}
	}
}
