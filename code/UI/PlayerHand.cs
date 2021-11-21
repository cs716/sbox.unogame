using Sandbox.UI;
using UnoGame.Net;

namespace UnoGame.UI
{
	public partial class PlayerHand : Panel
	{
		public enum HandPosition
		{
			LEFT, RIGHT, UP, DOWN
		}

		public int owner { get; set; } // Network Ident of the owning entity

		public HandPosition position { get; private set; }
		public PlayerHand(HandPosition handPosition)
		{
			StyleSheet.Load( "UI/PlayerHand.scss" );
			this.position = handPosition;
			AddClass( handPosition.ToString() );
		}

		public override void Tick()
		{
			base.Tick();
		}
	}
}
