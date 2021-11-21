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
			Log.Info( "AddCardToHand 2" );
			Log.Info( "SERVER? " + IsServer );
			Log.Info( card.value );
			Log.Info( card.action );
			Log.Info( card.color );
			Hand.Add(card);
			HandCount++;
			AddCardToPlayerHand( To.Single( this ), card );
		}

		[ClientRpc]
		public void AddCardToPlayerHand(Models.Card card)
		{
			Log.Info( "AddCardToHand 1" );
			IEnumerable<PlayerHand> hands = Local.Hud.ChildrenOfType<PlayerHand>();
			foreach ( PlayerHand hand in hands )
			{
				if ( hand.position == PlayerHand.HandPosition.DOWN )
				{
					UI.Card cardPanel = new UI.Card( card, true );
					hand.AddChild( cardPanel );
				}
			}
		}

		public void PlayCard(int index)
		{
			Hand.RemoveAt( index );
			HandCount--;
		}

		public IList<Models.Card> GetHand()
		{
			return Hand;
		}
	}
}
