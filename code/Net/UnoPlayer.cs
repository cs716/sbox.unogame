using System;
using System.Collections.Generic;
using UnoGame.Models;
using Sandbox;
using UnoGame.UI;

namespace UnoGame.Net
{
	public partial class UnoPlayer : Entity
	{
		[Net, Local]
		private IList<Models.Card> Hand { get; set; }
		[Net]
		public int HandCount { get; set; }

		public UnoPlayer()
		{
			Hand = new List<Models.Card>();
		}

		public void AddCard( Models.Card card )
		{
			Hand.Add(card);
			IEnumerable<PlayerHand> hands = Local.Hud.ChildrenOfType<PlayerHand>();
			foreach(PlayerHand hand in hands)
			{
				if (hand.position == PlayerHand.HandPosition.DOWN)
				{
					UI.Card cardPanel = new UI.Card( card, true );
					hand.AddChild( cardPanel );
				}
			}
			HandCount++;
		}

		public void PlayCard(int index)
		{
			Models.Card card = Hand[index];
			if ( card != null )
			{
				Hand.RemoveAt( index );
				HandCount--;
			}
			else
			{
				throw new KeyNotFoundException();
			}
		}

		public IList<Models.Card> GetHand()
		{
			return Hand;
		}
	}
}
