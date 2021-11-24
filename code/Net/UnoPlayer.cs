using System;
using System.Collections.Generic;
using UnoGame.Models;
using Sandbox;
using UnoGame.Net;
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
			this.Hand = new List<Models.Card>();
		}

		public void AddCard( Models.Card card )
		{
			// Confirmed this is 100% being called on the server side with previous debug outputs
			// Confirmed "Client" is my actual client that owns this pawn through previous debug outputs
			Hand.Add(card);
			HandCount++;
			AddCardToPlayerHand( To.Everyone );
		}

		[ClientRpc]
		public void AddCardToPlayerHand()
		{
			// Never prints this to console
			Log.Info( "Testing" );
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
