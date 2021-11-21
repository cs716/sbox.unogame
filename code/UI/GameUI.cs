using Sandbox.UI;
using UnoGame.UI.Components;
using Sandbox;
using System;
using System.Collections.Generic;
using UnoGame.Net;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace UnoGame.UI
{
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class GameUI : Sandbox.HudEntity<RootPanel>
	{
		private PlayerHand up;
		private PlayerHand left;
		private PlayerHand right;
		private PlayerHand down;

		public GameUI()
		{
			if ( IsClient )
			{
				RootPanel.StyleSheet.Load( "UI/RootPanel.scss" );
				// Load on screen components

				up = new PlayerHand( PlayerHand.HandPosition.UP );
				left = new PlayerHand( PlayerHand.HandPosition.LEFT );
				down = new PlayerHand( PlayerHand.HandPosition.DOWN );
				right = new PlayerHand( PlayerHand.HandPosition.RIGHT );
				StartGame();
			}
		}

		public void StartGame()
		{
			RootPanel.AddChild( up );
			RootPanel.AddChild( left );
			RootPanel.AddChild( down );
			RootPanel.AddChild( right );

			// Developer Buttons
			Components.Button button1 = new Components.Button();
			button1.Text = "Deal Card";
			button1.AddClass( "DrawCards" );
			button1.AddEventListener( "OnClick", () => Game.ClientCardDrawRequest() );
			RootPanel.AddChild( button1 );

			Components.Button button2 = new Components.Button();
			button2.Text = "Sort Hand";
			button2.AddClass( "SortHand" );
			button2.AddEventListener( "OnClick", () => Helpers.PlayerHandHelpers.SortHandContents( down ) );
			RootPanel.AddChild( button2 );
		}
	}

}
