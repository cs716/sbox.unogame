using Sandbox.UI;
using Sandbox.UI.Construct;
using UnoGame.Helpers;

namespace UnoGame.UI
{
	public partial class Card : Panel
	{

		public Enums.CardValue value { get; private set; } = Enums.CardValue.NULL;
		public Enums.CardColor color { get; private set; } = Enums.CardColor.NULL;
		public Enums.CardAction action { get; private set; } = Enums.CardAction.NONE;
		public Card(Models.Card card, bool isOwnCard)
		{
			StyleSheet.Load( "UI/Card.scss" );

			if ( card.value != Enums.CardValue.NULL )
			{
				AddClass( "value_" + card.value.ToString() );
				Add.Label( ((int)card.value).ToString(), "num_top" );
				Add.Label( ((int)card.value).ToString(), "num_bottom" );
				Add.Label( ((int)card.value).ToString(), "num_middle" );
			}

			if ( card.action != Enums.CardAction.NONE )
			{
				AddClass( "action_" + card.action.ToString() );
			}
			AddClass( "color_" + card.color.ToString() );
			if ( isOwnCard )
				AddClass( "owned" );

			this.value = card.value;
			this.color = card.color;
			this.action = card.action;

		}

		public override void OnParentChanged()
		{
			Style.Set( "z-index", (Parent.GetChildIndex( this ) + 50).ToString() );
			base.OnParentChanged();
		}

		public void UpdatedZIndex()
		{
			Style.Set( "z-index", (Parent.GetChildIndex( this ) + 50).ToString() );
		}
	}
}
