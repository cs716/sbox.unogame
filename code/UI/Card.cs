using Sandbox.UI;
using Sandbox.UI.Construct;

namespace UnoGame.UI
{
	public partial class Card : Panel
	{
		public Models.Card card { get; private set; }
		public Card(Models.Card card, bool isOwnCard)
		{
			StyleSheet.Load( "UI/Card.scss" );
			this.card = card;

			if ( card.value != Models.Card.CardValue.NULL )
			{
				AddClass( "value_" + card.value.ToString() );
				Add.Label( ((int)card.value).ToString(), "num_top" );
				Add.Label( ((int)card.value).ToString(), "num_bottom" );
				Add.Label( ((int)card.value).ToString(), "num_middle" );
			}

			if ( card.action != Models.Card.CardAction.NONE )
			{
				AddClass( "action_" + card.action.ToString() );
			}
			AddClass( "color_" + card.color.ToString() );
			if ( isOwnCard )
				AddClass( "owned" );

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
