using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoGame.UI;

namespace UnoGame.Helpers
{
	public static class PlayerHandHelpers
	{
		public static void SortHandContents(PlayerHand hand)
		{
			hand.SortChildren( ( comp, comp2 ) =>
			{
				if ( comp is Card && comp2 is Card )
				{
					Card card1 = comp as Card;
					Card card2 = comp2 as Card;
					if ( card1 != null && card2 != null )
					{
						if ( (int)card1.card.color > (int)card2.card.color )
							return 1;
						else if ( (int)card1.card.color < (int)card2.card.color )
							return -1;
						else
						{
							if ( (int)card1.card.value > (int)card2.card.value )
								return 1;
							else if ( (int)card1.card.value < (int)card2.card.value )
								return -1;
							else
								return 0;
						}
					}
					else
						return -1;
				}
				else
					return -1;
			} );
			foreach ( Card child in hand.Children )
			{
				child.UpdatedZIndex();
			}
		}
	}
}
