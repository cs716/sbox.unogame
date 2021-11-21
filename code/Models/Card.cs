﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoGame.Models
{
	public class Card
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
			NONE,
			DRAW_TWO,
			DRAW_FOUR,
			REVERSE,
			SKIP,
			WILD
		}

		public enum CardColor
		{
			RED=0,
			GREEN=1,
			BLUE=2,	
			YELLOW=3,
			NULL = 99
		}

		public CardValue value { get; private set; } = CardValue.NULL;
		public CardColor color { get; private set; } = CardColor.NULL;
		public CardAction action { get; private set; } = CardAction.NONE;


		public Card(CardValue value, CardAction action, CardColor color)
		{
			this.value = value;
			this.action = action;
			this.color = color;
		}
	}
}
