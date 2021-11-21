
using Sandbox;
using UnoGame.UI;
using UnoGame.Managers;
using UnoGame.Net;
using System.Collections.Generic;
//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace UnoGame
{

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// </summary>
	public partial class Game : Sandbox.Game
	{
		public GameDeckManager DeckManager { get; set; } = new();

		public enum GameState
		{
			WAITING_FOR_PLAYERS,
			IDLE,
			WAITING_FOR_MOVE,
			WAITING_FOR_ANIMATION,
			WAITING_FOR_ANIMATION_COMPLETE,
			ROUND_OVER
		}

		[Net, Change]
		public GameState CurrentState { get; set; }
		public void OnCurrentStateChanged(GameState old, GameState newState)
		{
			Event.Run( "UnoGame.StateChanged", newState );
		}

		public Game()
		{
			if ( IsServer )
			{
				DeckManager.CreateDeck();

				CurrentState = GameState.WAITING_FOR_PLAYERS;
				Log.Info( "My Gamemode Has Created Serverside!" );

				// Create a HUD entity. This entity is globally networked
				// and when it is created clientside it creates the actual
				// UI panels. You don't have to create your HUD via an entity,
				// this just feels like a nice neat way to do it.
				new GameUI();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
			}
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			UnoPlayer player = new UnoPlayer();

			client.Pawn = player;

			base.ClientJoined( client );
		}

		public static Game Instance
		{
			get => Current as Game;
		}

		[ServerCmd]
		public static void ClientCardDrawRequest()
		{
			UnoPlayer player = ConsoleSystem.Caller.Pawn as UnoPlayer;
			Models.Card card = Instance.DeckManager.GetNextCard();
			player.AddCard( card );
		}
	}

}
