using System;
using System.Collections.Generic;
using UnoGame.Models;
using Sandbox;
using UnoGame.UI;
using UnoGame.Helpers;

namespace UnoGame.Net
{
	public partial class UnoPlayer : Entity
	{
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
			Log.Info( Client.Name );
			Hand.Add(card);
			HandCount++;
			Log.Info( $"Calling AddCardToPlayerHand( To.Single( this ), {(int)card.value}, {(int)card.color}, {(int)card.action}); " );
			//AddCardToPlayerHand( To.Single( this ), (int)card.value, (int)card.color, (int)card.action );
			AddCardToPlayerHand( To.Single( this ) );
		}

		[ClientRpc]
		//int cardValue, int cardColor, int cardAction
		public void AddCardToPlayerHand()
		{
			Log.Info( "AddCardToHand 1" );
			/*Models.Card card = new Models.Card( (Enums.CardValue)cardValue, (Enums.CardAction)cardAction, (Enums.CardColor)cardColor );
			IEnumerable<PlayerHand> hands = Local.Hud.ChildrenOfType<PlayerHand>();
			foreach ( PlayerHand hand in hands )
			{
				if ( hand.position == PlayerHand.HandPosition.DOWN )
				{
					UI.Card cardPanel = new UI.Card( card, true );
					hand.AddChild( cardPanel );
				}
			}*/
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
