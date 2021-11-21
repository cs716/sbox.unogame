using System;
using System.Collections.Generic;
using Sandbox;

namespace UnoGame.Managers
{
	public class GameDeckManager
	{
		private IList<Models.Card> currentDeck { get; set; } 
		private List<Models.Card> playedPile { get; set; } = new();
		public GameDeckManager()
		{
			currentDeck = new List<Models.Card>();
		}

		public void ShuffleDeck()
		{
			int n = currentDeck.Count;
			Random rng = new Random();
			while (n > 1)
			{
				n--;
				int k = rng.Next( n );
				Models.Card value = currentDeck[k];
				currentDeck[k] = currentDeck[n];
				currentDeck[n] = value;
			}
		}

		public void HandleDeckout()
		{
			foreach (Models.Card card in playedPile)
			{
				currentDeck.Add( card );
			}
			playedPile.Clear();
			ShuffleDeck();
		}

		public int GetCardsRemaining()
		{
			return currentDeck.Count;
		}

		public void AddCardToPlayed(Models.Card card)
		{
			playedPile.Add( card );
		}

		public Models.Card GetNextCard(bool removeOnDraw=true)
		{
			if (currentDeck.Count == 0)
			{
				HandleDeckout();
			}
			Models.Card card = currentDeck[0];
			currentDeck.RemoveAt( 0 );
			return card;
		}

		public void CreateDeck()
		{
			currentDeck.Clear();

			// Create 1 of each color 0
			Models.Card r0 = new Models.Card( Models.Card.CardValue.ZERO, Models.Card.CardAction.NONE, Models.Card.CardColor.RED );
			Models.Card g0 = new Models.Card( Models.Card.CardValue.ZERO, Models.Card.CardAction.NONE, Models.Card.CardColor.GREEN );
			Models.Card b0 = new Models.Card( Models.Card.CardValue.ZERO, Models.Card.CardAction.NONE, Models.Card.CardColor.BLUE );
			Models.Card y0 = new Models.Card( Models.Card.CardValue.ZERO, Models.Card.CardAction.NONE, Models.Card.CardColor.YELLOW );
			currentDeck.Add( r0 );
			currentDeck.Add( g0 );
			currentDeck.Add( b0 );
			currentDeck.Add( y0 );

			for ( int n = 0; n <= 1; n++ ) // Add each of these twice
			{
				for ( int i = 1; i <= 9; i++ )
				{
					Models.Card r = new Models.Card( (Models.Card.CardValue)i, Models.Card.CardAction.NONE, Models.Card.CardColor.RED );
					Models.Card g = new Models.Card( (Models.Card.CardValue)i, Models.Card.CardAction.NONE, Models.Card.CardColor.GREEN );
					Models.Card b = new Models.Card( (Models.Card.CardValue)i, Models.Card.CardAction.NONE, Models.Card.CardColor.BLUE );
					Models.Card y = new Models.Card( (Models.Card.CardValue)i, Models.Card.CardAction.NONE, Models.Card.CardColor.YELLOW );
					currentDeck.Add( r );
					currentDeck.Add( g );
					currentDeck.Add( b );
					currentDeck.Add( y );
				}

				// 2x plus 2s for each color
				Models.Card p2r = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_TWO, Models.Card.CardColor.RED );
				Models.Card p2g = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_TWO, Models.Card.CardColor.GREEN );
				Models.Card p2b = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_TWO, Models.Card.CardColor.BLUE );
				Models.Card p2y = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_TWO, Models.Card.CardColor.YELLOW );
				currentDeck.Add( p2r );
				currentDeck.Add( p2g );
				currentDeck.Add( p2b );
				currentDeck.Add( p2y );

				// 2x reverse for each color
				Models.Card rr = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.REVERSE, Models.Card.CardColor.RED );
				Models.Card rg = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.REVERSE, Models.Card.CardColor.GREEN );
				Models.Card rb = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.REVERSE, Models.Card.CardColor.BLUE );
				Models.Card ry = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.REVERSE, Models.Card.CardColor.YELLOW );
				currentDeck.Add( rr );
				currentDeck.Add( rg );
				currentDeck.Add( rb );
				currentDeck.Add( ry );

				// 2x skip for each color
				Models.Card sr = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.SKIP, Models.Card.CardColor.RED );
				Models.Card sg = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.SKIP, Models.Card.CardColor.GREEN );
				Models.Card sb = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.SKIP, Models.Card.CardColor.BLUE );
				Models.Card sy = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.SKIP, Models.Card.CardColor.YELLOW );
				currentDeck.Add( sr );
				currentDeck.Add( sg );
				currentDeck.Add( sb );
				currentDeck.Add( sy );

				// 4 Wild Cards
				Models.Card wild1 = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.WILD, Models.Card.CardColor.NULL );
				Models.Card wild2 = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.WILD, Models.Card.CardColor.NULL );
				currentDeck.Add( wild1 );
				currentDeck.Add( wild2 );

				// 4 Draw 4s
				Models.Card draw41 = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_FOUR, Models.Card.CardColor.NULL );
				Models.Card draw42 = new Models.Card( Models.Card.CardValue.NULL, Models.Card.CardAction.DRAW_FOUR, Models.Card.CardColor.NULL );
				currentDeck.Add( draw41 );
				currentDeck.Add( draw42 );
			}
			ShuffleDeck(); // Shuffle
		}
	}
}
