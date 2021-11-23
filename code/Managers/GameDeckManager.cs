using System;
using System.Collections.Generic;
using UnoGame.Helpers;
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
			Models.Card r0 = new Models.Card( Enums.CardValue.ZERO, Enums.CardAction.NONE, Enums.CardColor.RED );
			Models.Card g0 = new Models.Card( Enums.CardValue.ZERO, Enums.CardAction.NONE, Enums.CardColor.GREEN );
			Models.Card b0 = new Models.Card( Enums.CardValue.ZERO, Enums.CardAction.NONE, Enums.CardColor.BLUE );
			Models.Card y0 = new Models.Card( Enums.CardValue.ZERO, Enums.CardAction.NONE, Enums.CardColor.YELLOW );
			currentDeck.Add( r0 );
			currentDeck.Add( g0 );
			currentDeck.Add( b0 );
			currentDeck.Add( y0 );

			for ( int n = 0; n <= 1; n++ ) // Add each of these twice
			{
				for ( int i = 1; i <= 9; i++ )
				{
					Models.Card r = new Models.Card( (Enums.CardValue)i, Enums.CardAction.NONE, Enums.CardColor.RED );
					Models.Card g = new Models.Card( (Enums.CardValue)i, Enums.CardAction.NONE, Enums.CardColor.GREEN );
					Models.Card b = new Models.Card( (Enums.CardValue)i, Enums.CardAction.NONE, Enums.CardColor.BLUE );
					Models.Card y = new Models.Card( (Enums.CardValue)i, Enums.CardAction.NONE, Enums.CardColor.YELLOW );
					currentDeck.Add( r );
					currentDeck.Add( g );
					currentDeck.Add( b );
					currentDeck.Add( y );
				}

				// 2x plus 2s for each color
				Models.Card p2r = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_TWO, Enums.CardColor.RED );
				Models.Card p2g = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_TWO, Enums.CardColor.GREEN );
				Models.Card p2b = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_TWO, Enums.CardColor.BLUE );
				Models.Card p2y = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_TWO, Enums.CardColor.YELLOW );
				currentDeck.Add( p2r );
				currentDeck.Add( p2g );
				currentDeck.Add( p2b );
				currentDeck.Add( p2y );

				// 2x reverse for each color
				Models.Card rr = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.REVERSE, Enums.CardColor.RED );
				Models.Card rg = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.REVERSE, Enums.CardColor.GREEN );
				Models.Card rb = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.REVERSE, Enums.CardColor.BLUE );
				Models.Card ry = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.REVERSE, Enums.CardColor.YELLOW );
				currentDeck.Add( rr );
				currentDeck.Add( rg );
				currentDeck.Add( rb );
				currentDeck.Add( ry );

				// 2x skip for each color
				Models.Card sr = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.SKIP, Enums.CardColor.RED );
				Models.Card sg = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.SKIP, Enums.CardColor.GREEN );
				Models.Card sb = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.SKIP, Enums.CardColor.BLUE );
				Models.Card sy = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.SKIP, Enums.CardColor.YELLOW );
				currentDeck.Add( sr );
				currentDeck.Add( sg );
				currentDeck.Add( sb );
				currentDeck.Add( sy );

				// 4 Wild Cards
				Models.Card wild1 = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.WILD, Enums.CardColor.NULL );
				Models.Card wild2 = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.WILD, Enums.CardColor.NULL );
				currentDeck.Add( wild1 );
				currentDeck.Add( wild2 );

				// 4 Draw 4s
				Models.Card draw41 = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_FOUR, Enums.CardColor.NULL );
				Models.Card draw42 = new Models.Card( Enums.CardValue.NULL, Enums.CardAction.DRAW_FOUR, Enums.CardColor.NULL );
				currentDeck.Add( draw41 );
				currentDeck.Add( draw42 );
			}
			ShuffleDeck(); // Shuffle
		}
	}
}
