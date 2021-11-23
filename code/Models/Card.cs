using Sandbox;
using UnoGame.Helpers;

namespace UnoGame.Models
{
	public partial class Card
	{
		public Enums.CardValue value { get; private set; } = Enums.CardValue.NULL;
		public Enums.CardColor color { get; private set; } = Enums.CardColor.NULL;
		public Enums.CardAction action { get; private set; } = Enums.CardAction.NONE;


		public Card( Enums.CardValue value, Enums.CardAction action, Enums.CardColor color)
		{
			this.value = value;
			this.action = action;
			this.color = color;
		}
	}
}
